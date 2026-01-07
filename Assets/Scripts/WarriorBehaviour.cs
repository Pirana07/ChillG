using UnityEngine;

public class WarriorBehaviour : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float warriorSpeed = 5;
    [SerializeField] float patrolDistance = 4f;
    Vector3 targetPosition;

    enum WarriorState
    {
        Idle,
        Attacking,
        Fighting,
        goingBack,
    }
    
    [Header("warrior Settings")]
    [SerializeField] WarriorState warriorState;
    // [SerializeField] Animator warriorAnim;

    void Start()
    {
        PickNewTarget();
    }

    void Update()
    {
        switch (warriorState)
        {
            case WarriorState.Idle:
                Patroling();
                break;
        }
    }

    void Patroling()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, warriorSpeed * Time.deltaTime);
    
        if (Vector3.Distance(transform.position, targetPosition) < 0.05f)
        {
            PickNewTarget();
        }
    }
    void PickNewTarget()
    {
        int direction = Random.Range(0, 2) * 2 - 1;
        targetPosition = transform.position + Vector3.up * patrolDistance * direction;
    }
}
