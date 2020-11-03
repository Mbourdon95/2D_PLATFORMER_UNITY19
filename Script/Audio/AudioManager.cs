using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public List<AudioClip> playlists;
    public AudioSource music;
    private int index = 0;

    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
        music.clip = playlists[index];
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!music.isPlaying)
        {
            Replay();
            
        }
    }

    void NextMusic()
    {
        index = (index + 1) % playlists.Count;
        music.clip = playlists[index];
        music.Play();
    }
    void Replay()
    {
        music.clip = playlists[index];
        music.Play();
    }
}
