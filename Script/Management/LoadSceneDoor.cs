using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSceneDoor : MonoBehaviour
{
    public string sceneName;
    private Animator transitSystem;

    private void Awake()
    {
        transitSystem = GameObject.FindGameObjectWithTag("TransitSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(load());
            
        }
    }

    public IEnumerator load()
    {
        transitSystem.SetTrigger("TransitIn");
        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene(sceneName);
    }
}