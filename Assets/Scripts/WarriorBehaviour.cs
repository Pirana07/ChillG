using Unity.VisualScripting;
using System.Collections.Generic;
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
        // Fighting,
        GoingBack,
    }

    [Header("warrior Settings")]
    public WarriorState warriorState;

    List<Transform> enemiesInZone = new List<Transform>();
    Transform currentEnemy;


    void Update()
    {
        switch (warriorState)
        {
            case WarriorState.Idle: warriorMovement.Patroling(); break;
            case WarriorState.Chasing: warriorMovement.Chasing(); break;
            // case WarriorState.Fighting: Debug.Log("Fighting!"); break;
            case WarriorState.GoingBack: warriorMovement.GoingBack(); break;
        }
    }

    //enemy entered zone
    public void AlertTarget(Transform target)
    {
        if (!enemiesInZone.Contains(target))
            enemiesInZone.Add(target);

        // if already have a target, ignore new enemy
        if (currentEnemy != null)
            return;

        // lock this enemy
        currentEnemy = target;

        warriorState = WarriorState.Chasing;
        warriorMovement.currentTarget = currentEnemy;
        warriorMovement.warriorIsWaiting = false;
        warriorMovement.ShowTextBuble(false);
    }

    //enemy left zone
    public void TargetLost(Transform target)
    {
        enemiesInZone.Remove(target);

        //only react if the lost target was the current locked enemy
        if (target != currentEnemy)
            return;

        currentEnemy = null;

        if (enemiesInZone.Count > 0)
        {
            // take next enemy 
            currentEnemy = enemiesInZone[0];
            warriorMovement.currentTarget = currentEnemy;
            warriorState = WarriorState.Chasing;
        }
        else
        {
            //nomore enemies
            warriorMovement.ShowTextBuble(true);
            warriorState = WarriorState.GoingBack;
        }
    }

    public void BackToIDle()
    {
        warriorState = WarriorState.Idle;
    }

    // public void StartAttack()
    // {
    //     warriorState = WarriorBehaviour.WarriorState.Fighting;
    // }


}
