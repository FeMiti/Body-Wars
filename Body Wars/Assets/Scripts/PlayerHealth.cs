using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    [Header("Player Health Setting")]
    public float playerMaxHealth=100;
    public float playerCurrentHealth;
    [SerializeField] private Animator animador;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] clips;
    [SerializeField] GameObject ui;
    [SerializeField] GameObject deathMenu;

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
        float timer=0;
        float tempoAnim=1f;

        while (timer < tempoAnim)
        {
            timer+=Time.deltaTime;
        }

        ui.SetActive(false);
        deathMenu.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale=0f;
    }

    private void TryAgain()
    {
        ui.SetActive(true);
        deathMenu.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale=1f;
        SceneManager.LoadSceneAsync(1);
    }

    private void GiveUp()
    {
        ui.SetActive(true);
        deathMenu.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale=1f;
        SceneManager.LoadSceneAsync(0);
    }


    private void PlayClip(int clip)
    {
        source.PlayOneShot(clips[clip]);
    }
}
