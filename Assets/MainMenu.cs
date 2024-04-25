using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsWindow;
    public string levelToLoad;

    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void SetActiveSettingsWindow(bool active)
    {
        settingsWindow.SetActive(active);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
