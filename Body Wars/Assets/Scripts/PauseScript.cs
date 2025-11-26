using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public bool isPaused=false;

    [SerializeField] GameObject ui;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] PlayerHealth morreu;
    [SerializeField] BossHealth ganhou;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused && morreu.playerCurrentHealth>0 && ganhou.bossCurrentHealth>0)
        {
            PauseGame();
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            ResumeGame();
        }       
    }

    public void PauseGame()
    {
        isPaused=true;
        ui.SetActive(false);
        pauseMenu.SetActive(true);
        AudioListener.pause = true;
        Cursor.visible=true;
        Cursor.lockState=CursorLockMode.None;
        Time.timeScale=0f;
    }

    public void ResumeGame()
    {
        isPaused=false;
        pauseMenu.SetActive(false);
        ui.SetActive(true);
        AudioListener.pause = false;
        Cursor.visible=false;
        Cursor.lockState=CursorLockMode.Locked;
        Time.timeScale=1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        Cursor.visible=true;
        Cursor.lockState=CursorLockMode.None;
        SceneManager.LoadSceneAsync(4);
    }
}
