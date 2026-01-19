using System.Collections;
using UnityEngine;

public class WarriorMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float warriorSpeed = 5f;
    [SerializeField] Vector2 waitTimeRange = new Vector2(1f, 3f);
    public bool warriorIsWaiting;
    [SerializeField] Animator warriorAnim;

    [Header("Target Settings")]
    [SerializeField] Transform[] patrolPoints;
    public Transform currentTarget;
    [Header("Detail Settings")]
    public GameObject textBuble;


    void Start()
    {
        PickNewTarget();
    }

    public void Patroling()
    {
        if (warriorIsWaiting || currentTarget == null || patrolPoints.Length == 0)
            return;

        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, warriorSpeed * Time.deltaTime); //moving

        if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)//if reached destination
        {
            StartCoroutine(WaitAndPickNewTarget());
        }
    }
    public void Chasing()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, warriorSpeed * Time.deltaTime); //Chasing
        warriorAnim.SetBool("isMoving", true);
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)//if reached destination
            warriorAnim.SetBool("isMoving", false);
        return;
    }


    IEnumerator WaitAndPickNewTarget() //Bug
    {
        warriorIsWaiting = true;
        warriorAnim.SetBool("isMoving", false);
        yield return new WaitForSeconds(Random.Range(waitTimeRange.x, waitTimeRange.y)); //better than timer thing
        warriorAnim.SetBool("isMoving", true);
        textBuble.SetActive(false); 

        PickNewTarget();
        warriorIsWaiting = false;
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
}
