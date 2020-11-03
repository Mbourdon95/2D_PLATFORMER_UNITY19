using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitAssetsOnLoad : MonoBehaviour
{
    public GameObject[] transit;

    public static TransitAssetsOnLoad instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a déjà un TransitAssetsOnLoad dans la session");
        }
        instance = this;

        for (int i = 0; i < transit.Length; i++)
        {
            DontDestroyOnLoad(transit[i]);
        }
    }

    public void RemoveFromTransitAssetsOnLoad()
    {
        for (int i = 0; i < transit.Length; i++)
        {
            SceneManager.MoveGameObjectToScene(transit[i], SceneManager.GetActiveScene());
        }
    }

}
