using System;
using System.Collections;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    [Header("Boss Health Settings")]
    public float bossMaxHealth=100;
    public float bossCurrentHealth;

    [SerializeField] private Animator animador;
    [SerializeField] private ParticleSystem cabum;
    [SerializeField] private Transform sumiu;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] clips;
    //Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        bossCurrentHealth=bossMaxHealth;
    }

    public void BossTakeDamage(float bossDamageTaken)
    {
        bossCurrentHealth -= bossDamageTaken;
        PlayClip(0);

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

    public void Die()
    {
        StartCoroutine(DieRoutine());
    }

    IEnumerator DieRoutine()
    {
        animador.SetTrigger("bossDies");

        yield return new WaitForSeconds(3f);

        Vector3 someDaqui = sumiu.position;
        transform.position = someDaqui;

        PlayClip(1);
        cabum.Play();
        yield return new WaitForSeconds(3f);
        cabum.Stop();
    }

    private void PlayClip(int clip)
    {
        source.PlayOneShot(clips[clip]);
    }
}
