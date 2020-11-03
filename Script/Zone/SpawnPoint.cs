using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // On récup la position du joueur lors du changment de scene et on l'envoie au spawn point. 
    void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
    }
}