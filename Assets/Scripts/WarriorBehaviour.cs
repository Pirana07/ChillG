using Unity.VisualScripting;
using UnityEngine;

public class WarriorBehaviour : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] RebirthManager rebirthManager;
    [SerializeField] WarriorMovement warriorMovement;

    public enum WarriorState
    {
        Idle,
        Chasing,
        Fighting,
        GoingBack,
    }

    [Header("warrior Settings")]
    public WarriorState warriorState;


    void Update()
    {
        switch (warriorState)
        {
            case WarriorState.Idle: warriorMovement.Patroling(); break;
            case WarriorState.Chasing: warriorMovement.Chasing(); break;
            case WarriorState.GoingBack: warriorMovement.GoingBack(); break;
        }
    }

    //Enemy triggered Warrior
    public void AlertTarget(Transform target)
    {
        warriorState = WarriorState.Chasing;
        warriorMovement.currentTarget = target;
        warriorMovement.warriorIsWaiting = false;
    }

    //Enemy escaped Warrior
    public void TargetLost()
    {
        warriorMovement.ShowTextBuble();
        warriorState = WarriorState.GoingBack; //going to original pos
    }
    public void BackToIDle()
    {
        warriorState = WarriorBehaviour.WarriorState.Idle;
    }

}
