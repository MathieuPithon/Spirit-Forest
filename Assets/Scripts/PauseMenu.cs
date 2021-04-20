﻿using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool gameIsPaused = false;
    private string mainMenu;
    public PlayerActions action;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else{
                Paused();
            }
        }
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Resume();
    }
    public void Paused()
    {
        PlayerMovement.instance.enabled = false;
        GameObject.Find("Player").GetComponent<PlayerActions>().enabled = false;
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        GameObject.Find("Player").GetComponent<PlayerCombat>().enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }
    public void Resume()
    {
        PlayerMovement.instance.enabled = true;
        GameObject.Find("Player").GetComponent<PlayerActions>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerCombat>().enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }
}
