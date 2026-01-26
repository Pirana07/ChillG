using UnityEngine;

public class WarriorFight : MonoBehaviour
{
    [SerializeField] float attackDamage = 1f;
    [SerializeField] CooldownTimer attackTimer;
    [SerializeField] Animator warriorAnim;

    EnemyBehaviour currentEnemy;
    WarriorBehaviour warriorBehaviour;

    void Awake()
    {
        warriorBehaviour = GetComponentInParent<WarriorBehaviour>();
    }

    void Update()
    {
        if (currentEnemy == null)
            return;

        // Combat Logic(time based)
        attackTimer.Tick(Time.deltaTime);
        if (attackTimer.IsReady(0f))
        {
            Attack();
            attackTimer.Reset(1f);
        }
    }

    void Attack()
    {
        if (currentEnemy == null)
            return;

        currentEnemy.TakeDamage(attackDamage);
    }

    //
    public void SetEnemy(EnemyBehaviour enemy)
    {
        if (currentEnemy == null)
        {
            currentEnemy = enemy;
            attackTimer.ForceReady();
        }
    }

    public void EnemyLost()
    {
        if (currentEnemy != null)
        {
            warriorBehaviour.TargetLost(currentEnemy.transform);
            currentEnemy = null;
        }
    }
}
