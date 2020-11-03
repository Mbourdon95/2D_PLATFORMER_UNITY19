using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{


    public string loadScene;
    public GameObject settingWindow, optionOpen,optionClose,firstOption,LevelOpen,LevelClose;

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Settings();
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(loadScene);
    }

    public void ChooseLevel()
    {
        EventSystem.current.SetSelectedGameObject(null);

        if (true)
        {
            EventSystem.current.SetSelectedGameObject(LevelClose);
        }
        
        EventSystem.current.SetSelectedGameObject(LevelOpen);

    }
    public void Settings()
    {
        EventSystem.current.SetSelectedGameObject(null);
        if (settingWindow.activeSelf)
        {
            settingWindow.SetActive(false);
            EventSystem.current.SetSelectedGameObject(optionClose);
            return;
        }
        settingWindow.SetActive(true);
        EventSystem.current.SetSelectedGameObject(optionOpen);

    }
    public void Quit()
    {
        Application.Quit();
    }
}
