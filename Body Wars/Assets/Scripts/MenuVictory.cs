using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuVictory : MonoBehaviour
{

    [SerializeField] GameObject ui;
    [SerializeField] GameObject victoryMenu;
    public void Win()
    {
        ui.SetActive(false);
        victoryMenu.SetActive(true);
        AudioListener.pause = true;
        Cursor.visible=true;
        Cursor.lockState=CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void Again()
    {
        ui.SetActive(true);
        victoryMenu.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale=1f;
        Cursor.visible=false;
        Cursor.lockState=CursorLockMode.Locked;
        SceneManager.LoadSceneAsync(2);
    }

    public void Continue()
    {
        ui.SetActive(true);
        victoryMenu.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale=1f;
        SceneManager.LoadSceneAsync(3);
    }
}
