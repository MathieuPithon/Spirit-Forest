using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public string level1;
    public string levelTutorial;
    public void StartGame()
    {
        SceneManager.LoadScene(level1);
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
