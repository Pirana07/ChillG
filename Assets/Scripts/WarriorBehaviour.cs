using System.Collections;
using UnityEngine;

public class WarriorBehaviour : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] RebirthManager rebirthManager;
    
    [Header("Movement Settings")]
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] float warriorSpeed = 5f;
    [SerializeField] Vector2 waitTimeRange = new Vector2(1f, 3f);
    Transform currentTarget;
    public bool warriorIsWaiting;

    enum WarriorState
    {
        Idle,
        Attacking,
        Fighting,
        goingBack,
    }

    [Header("warrior Settings")]
    [SerializeField] WarriorState warriorState;
    [SerializeField] Animator warriorAnim;

    void Start()
    {
        PickNewTarget();
    }

    void Update()
    {
        switch (warriorState)
        {
            case WarriorState.Idle: Patroling(); break;
        }
    }

    void Patroling()
    {
        if (warriorIsWaiting || currentTarget == null || patrolPoints.Length == 0)
            return;

        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, warriorSpeed * Time.deltaTime); //moving

        if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)//if reached destination
        {
            StartCoroutine(WaitAndPickNewTarget());
        }
    }

    IEnumerator WaitAndPickNewTarget()
    {
        warriorIsWaiting = true;
        warriorAnim.SetBool("isMoving", false);
        yield return new WaitForSeconds(Random.Range(waitTimeRange.x, waitTimeRange.y)); //better than timer thing
        warriorAnim.SetBool("isMoving", true);

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
        do//same targets doesn't repeat >:)
        {
            newTarget = patrolPoints[Random.Range(0, patrolPoints.Length)];
        }
        while (newTarget == currentTarget && patrolPoints.Length > 1);

        currentTarget = newTarget;
    }
}
