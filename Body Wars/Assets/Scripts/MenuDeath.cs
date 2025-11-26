using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDeath : MonoBehaviour
{
    [SerializeField] GameObject ui;
    [SerializeField] GameObject deathMenu;

    public void Die()
    {
        StartCoroutine(DeathRoutine());
    }

    IEnumerator DeathRoutine()
    {
        // Espera em tempo real
        yield return new WaitForSecondsRealtime(0.85f);

        ui.SetActive(false);
        deathMenu.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0f;
    }

    public void TryAgain()
    {
        ui.SetActive(true);
        deathMenu.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale=1f;
        SceneManager.LoadSceneAsync(1);
    }

    public void GiveUp()
    {
        ui.SetActive(true);
        deathMenu.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale=1f;
        SceneManager.LoadSceneAsync(0);
    }
}
