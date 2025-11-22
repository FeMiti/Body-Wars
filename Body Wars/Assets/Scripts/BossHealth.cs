using System;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    [Header("Boss Health Settings")]
    public float bossMaxHealth=100;
    public float bossCurrentHealth;

    [SerializeField] Animator animador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        bossCurrentHealth=bossMaxHealth;
    }

    public void BossTakeDamage(float bossDamageTaken)
    {
        bossCurrentHealth -= bossDamageTaken;
        animador.SetTrigger("bossHit");

        if(bossCurrentHealth <= 0)
        {
            bossCurrentHealth=0;
            Die();
        }
    }

    private void Die()
    {
        animador.SetTrigger("bossDies");
        Debug.Log("Matou o monstro uhul!!!");
    }
}
