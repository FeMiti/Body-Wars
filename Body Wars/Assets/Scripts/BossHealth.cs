using System;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    [Header("Boss Health Settings")]
    public float bossMaxHealth=100;
    public float bossCurrentHealth;

    [SerializeField] private Animator animador;
    [SerializeField] private ParticleSystem cabum;
    [SerializeField] private Transform sumiu;
    //Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        bossCurrentHealth=bossMaxHealth;
    }

    public void BossTakeDamage(float bossDamageTaken)
    {
        bossCurrentHealth -= bossDamageTaken;

        if(bossCurrentHealth <= 0)
        {
            bossCurrentHealth=0;
            Die();
        }
        else
        {
            animador.SetTrigger("bossHit");
        }
    }

    private void Die()
    {
        animador.SetTrigger("bossDies");
        float timer=0f;
        float deadDuration=10f;

        while (timer < deadDuration)
        {
            timer+=Time.deltaTime;
        }

        Vector3 someDaqui=sumiu.position;
        transform.position=someDaqui;

        cabum.Play();

    }
}
