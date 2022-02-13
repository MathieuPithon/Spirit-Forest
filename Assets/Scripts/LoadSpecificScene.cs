using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;
    public Animator fadeSystem;

    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(LoadNextScene());
        }

    }

    public IEnumerator LoadNextScene()
    {
        fadeSystem.SetTrigger("FadeIn"); /**
        PlayerMovement.instance.enabled = false;
        GameObject.Find("Player").GetComponent<PlayerActions>().enabled = false;
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        GameObject.Find("Player").GetComponent<PlayerCombat>().enabled = false;
        PlayerMovement.instance.rb.velocity = Vector2.zero;
        PlayerMovement.instance.animator.SetFloat("Speed", 0);

       
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerMovement.instance.enabled = true;
        GameObject.Find("Player").GetComponent<PlayerActions>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerCombat>().enabled = true;
        **/
         yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
