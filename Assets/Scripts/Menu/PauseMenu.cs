using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool gameIsPaused = false;
    public string mainMenu;
    public GameObject player;
    public Rigidbody2D rb;

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
        player.GetComponent<PlayerActions>().enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerCombat>().enabled = false;
        player.GetComponent<AudioSource>().enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }
    public void Resume()
    {
        PlayerMovement.instance.enabled = true;
        rb.constraints = ~RigidbodyConstraints2D.FreezePosition;
        player.GetComponent<PlayerActions>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerCombat>().enabled = true;
        player.GetComponent<AudioSource>().enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }
}
