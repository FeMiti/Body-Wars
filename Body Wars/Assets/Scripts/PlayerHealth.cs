using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [Header("Player Health Setting")]
    public float playerMaxHealth=100;
    public float playerCurrentHealth;

    [SerializeField] private Animator animador;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        playerCurrentHealth=playerMaxHealth;
    }

    public void TakeDamage(float damageTaken)
    {
        playerCurrentHealth -= damageTaken;
        animador.SetTrigger("receiveHit");

        if(playerCurrentHealth <= 0)
        {
            playerCurrentHealth=0;
            Die();
        }
    }

    private void Die()
    {
        animador.SetTrigger("dies");
        Debug.Log("Morreu, seu bunda.");
    }
}
