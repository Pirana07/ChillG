using Unity.VisualScripting;
using UnityEngine;

public class WarriorBehaviour : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] RebirthManager rebirthManager;
    [SerializeField] WarriorMovement warriorMovement;

    enum WarriorState
    {
        Idle,
        Chasing,
        Fighting,
        GoingBack,
    }

    [Header("warrior Settings")]
    [SerializeField] WarriorState warriorState;


    void Update()
    {
        switch (warriorState)
        {
            case WarriorState.Idle: warriorMovement.Patroling(); break;
            case WarriorState.Chasing: warriorMovement.Chasing(); break;
            case WarriorState.GoingBack: warriorMovement.Patroling(); break;


        }
    }

    //Enemy triggered Warrior
    public void AlertTarget(Transform target)
    {
        warriorState = WarriorState.Chasing;
        warriorMovement.currentTarget = target;
    }

    //Enemy escaped Warrior
    public void TargetLost()
    {
        warriorMovement.textBuble.SetActive(true);
        warriorState = WarriorState.GoingBack; //going to original pos
    }

}
