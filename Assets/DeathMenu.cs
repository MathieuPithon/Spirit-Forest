using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public string Menu;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleEndMenu(){
         gameObject.SetActive (true);
         Time.timeScale = 0;
    }

    public void Restart(){

        Debug.Log("retry");
       /* SceneManager.LoadScene("Menu"); 
        SceneManager.LoadScene(Menu);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); */
    }

    public void Quitter(){

        Debug.Log("testQuit");
        //Application.Quit();
    }
}
