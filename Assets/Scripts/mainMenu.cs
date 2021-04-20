using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public string MainLevel1;
    public string levelTutorial;
    public void StartGame()
    {
        SceneManager.LoadScene(MainLevel1);
    }
    public void StartTutorial()
    {
        SceneManager.LoadScene(levelTutorial);
    }
    public void SettingsButton()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
