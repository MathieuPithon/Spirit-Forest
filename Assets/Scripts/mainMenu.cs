using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class mainMenu : MonoBehaviour
{
    public string MainLevel1;
    public string MainLevel2;
    public string levelTutorial;
    public AudioSource startGameSound;
    public AudioSource mainMenuMusic;
    public Animator fade;
    
    public void StartGame()
    {   
        fade.SetBool("Start", true);
        startGameSound.Play();
        mainMenuMusic.Stop();
        SceneManager.LoadScene(MainLevel1);
    }
       public void StartLevel2()
    {   
        fade.SetBool("Start", true);
        startGameSound.Play();
        mainMenuMusic.Stop();
        SceneManager.LoadScene(MainLevel2);
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
