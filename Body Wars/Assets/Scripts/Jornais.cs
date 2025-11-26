using UnityEngine;
using UnityEngine.SceneManagement;

public class Jornais : MonoBehaviour
{
    [SerializeField] private GameObject startNews;

    void Start()
    {
        if(!startNews.activeSelf)
            startNews.SetActive(true);
    }
    public void GoToGame()
    {
        Cursor.visible=false;
        Cursor.lockState=CursorLockMode.Locked;
        SceneManager.LoadSceneAsync(2);
    }

    public void GoToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
