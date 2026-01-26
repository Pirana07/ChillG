using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class WarriorMovement : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] WarriorBehaviour warriorBehaviour;
    [Header("Movement Settings")]
    [SerializeField] float warriorSpeed = 5f;
    [SerializeField] Vector2 waitTimeRange = new Vector2(1f, 3f);
    public bool warriorIsWaiting;
    [SerializeField] Animator warriorAnim;

    [Header("Target Settings")]
    [SerializeField] Transform[] patrolPoints;
    public Transform currentTarget;
    bool isChasingEnemy;

    [Header("Detail Settings")]
    public GameObject textBuble;


    void Start()
    {
        PickNewTarget();
    }


    /// <summary>
    /// Idle Patroling
    /// </summary>
    public void Patroling()
    {
        if (warriorIsWaiting || isChasingEnemy || currentTarget == null || patrolPoints.Length == 0)
            return;

        warriorAnim.SetBool("isMoving", true);
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, warriorSpeed * Time.deltaTime); //moving

        if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)//if reached destination
        {
            if (warriorIsWaiting) return;

            warriorIsWaiting = true;
            StartCoroutine(WaitAndPickNewTarget());
        }
    }

    /// <summary>
    /// Chasing enemy
    /// </summary>
    public void Chasing()
    {
        if (currentTarget == null)
            return;

        isChasingEnemy = true;
        warriorAnim.SetBool("isMoving", true);

        //move toward the current target
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, warriorSpeed * Time.deltaTime);

        // check if close enough to start attack
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.5f) 
        {
            //attack this enemy
            EnemyBehaviour enemy = currentTarget.GetComponent<EnemyBehaviour>();
            if (enemy != null)
            {
                WarriorFight fight = GetComponent<WarriorFight>();
                fight.SetEnemy(enemy);
            }
        }
    }



    /// <summary> 
    /// Going Back To Idle
    /// </summary>
    public void GoingBack()
    {
        isChasingEnemy = false;
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[0].position, warriorSpeed * Time.deltaTime); //moving
        warriorAnim.SetBool("isMoving", true);

        if (Vector3.Distance(transform.position, patrolPoints[0].position) < 0.1f)//if reached destination
        {
            StartCoroutine(WaitAndPickNewTarget());
            warriorBehaviour.BackToIDle();
        }
    }

    /// <summary>
    /// Wait For Patrol
    /// </summary>
    IEnumerator WaitAndPickNewTarget() //Bug
    {
        warriorIsWaiting = true;
        warriorAnim.SetBool("isMoving", false);
        yield return new WaitForSeconds(Random.Range(waitTimeRange.x, waitTimeRange.y)); //better than timer thing
        if (!isChasingEnemy) //Not to override enemy target
            PickNewTarget();

        warriorAnim.SetBool("isMoving", true);
        warriorIsWaiting = false;
        ShowTextBuble(false);
    }

    /// <summary>
    /// Picks Random Destination
    /// </summary>
    void PickNewTarget()
    {
        if (patrolPoints.Length == 0)
            return;

        Transform newTarget;
        do//same target doesn't repeat >:)
        {
            newTarget = patrolPoints[Random.Range(0, patrolPoints.Length)];
        }
        while (newTarget == currentTarget && patrolPoints.Length > 1);

        currentTarget = newTarget;
    }

    public void ShowTextBuble(bool shouldItShow) //Change
    {
        textBuble.SetActive(shouldItShow);
    }
}
