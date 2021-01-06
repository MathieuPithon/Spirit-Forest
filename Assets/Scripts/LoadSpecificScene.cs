using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;
    public Animator fadeSystem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(LoadNextScene());
        }

    }

    public IEnumerator LoadNextScene()
    {
        fadeSystem.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
