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
        Cursor.visible=true;
        Cursor.lockState=CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void TryAgain()
    {
        ui.SetActive(true);
        deathMenu.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale=1f;
        Cursor.visible=false;
        Cursor.lockState=CursorLockMode.Locked;
        SceneManager.LoadSceneAsync(2);
    }

    public void GiveUp()
    {
        ui.SetActive(true);
        deathMenu.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale=1f;
        Cursor.visible=true;
        Cursor.lockState=CursorLockMode.None;
        SceneManager.LoadSceneAsync(4);
    }
}
