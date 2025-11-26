using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [Header("Player Health Setting")]
    public float playerMaxHealth=100;
    public float playerCurrentHealth;
    [SerializeField] private Animator animador;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private MenuDeath death;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        playerCurrentHealth=playerMaxHealth;
    }

    public void TakeDamage(float damageTaken)
    {
        playerCurrentHealth -= damageTaken;
        animador.SetTrigger("receiveHit");
        PlayClip(0);

        if(playerCurrentHealth <= 0)
        {
            playerCurrentHealth=0;
            Die();
        }
    }

    private void Die()
    {
        animador.SetTrigger("dies");
        death.Die();
    }


    private void PlayClip(int clip)
    {
        source.PlayOneShot(clips[clip]);
    }
}
