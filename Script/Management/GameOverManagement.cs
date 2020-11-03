using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOverManagement : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject settings, optionOpen, retryOpen;
    public static bool onBreak = false;

    public static GameOverManagement instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Déjà GameOverManagement dans la scène");
            return;
        }
        instance = this;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SetActiveSettings();
        }
        
    }
    public void OnPlayerDeath()
    {
        EventSystem.current.SetSelectedGameObject(null);
        if (CurrentSceneMangement.instance.playerHere)
        {
            TransitAssetsOnLoad.instance.RemoveFromTransitAssetsOnLoad();
        }
        EventSystem.current.SetSelectedGameObject(retryOpen);
        gameOver.SetActive(true);
    }

    public void RetryButton()
    {
        Inventory.myOwnInventory.RemoveBerry(CurrentSceneMangement.instance.berriesPick);
        Inventory.myOwnInventory.RemoveGem(CurrentSceneMangement.instance.gemsPick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        DataPlayerChange.instance.Respawn();
        gameOver.SetActive(false);
    }

    public void MenuButton()
    {
        TransitAssetsOnLoad.instance.RemoveFromTransitAssetsOnLoad();
        onBreak = false;
        BreakUnBreak();
        SceneManager.LoadScene(0);
    }

    public void SetActiveSettings()
    {
        if (gameOver.activeSelf)
        {
            return;
        }
        
        if (settings.activeSelf)
        {
            onBreak = false;
            BreakUnBreak();
            EventSystem.current.SetSelectedGameObject(null);         
            settings.SetActive(false);
            return;
        }
        onBreak = true;
        BreakUnBreak();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionOpen);
        settings.SetActive(true);
    }

    public void BreakUnBreak()
    {
        if (onBreak)
        {
            Time.timeScale =0;
            return;
        }
        Time.timeScale=1;

    }
}
