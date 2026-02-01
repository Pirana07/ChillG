using UnityEngine;
using System;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float maxHP = 10f;
    [SerializeField] float currentHP;
    public event Action OnEnemyDied;


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
        OnEnemyDied?.Invoke();
        Destroy(gameObject);
    }
}
