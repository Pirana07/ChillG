using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float maxHP = 10f;
    [SerializeField] float currentHP;

    void Awake()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
