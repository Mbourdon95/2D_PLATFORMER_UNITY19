using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSceneMangement : MonoBehaviour
{

    public bool playerHere = false;
    public int berriesPick, gemsPick;
    public static CurrentSceneMangement instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Déjà CurrentSceneMangement dans la scène");
            return;
        }
        instance = this;
    }
    public void AddBerry(int _berry)
    {
        berriesPick += _berry;
    }
    public void AddGem(int _gem)
    {
        gemsPick += _gem;
    }


}
