using UnityEngine;

public class WarriorFight : MonoBehaviour
{
    [SerializeField] float attackDamage = 1f;
    [SerializeField] CooldownTimer attackTimer;

    EnemyBehaviour currentEnemy;

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
        currentEnemy.TakeDamage(attackDamage);
    }

    //
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            currentEnemy = other.GetComponent<EnemyBehaviour>();
            attackTimer.ForceReady();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
            currentEnemy = null;
    }
}
