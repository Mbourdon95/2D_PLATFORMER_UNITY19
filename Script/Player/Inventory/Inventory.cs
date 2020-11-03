using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public int berryCount;
    public int gemCount;

    public Text countBerries;
    public Text countGem;

    public static Inventory myOwnInventory;
    

    private void Awake()
    {
        if (myOwnInventory != null)
        {
            Debug.LogWarning("Il y a déjà un inventaire dans la session");
        }
        myOwnInventory = this;
    }


    public void RemoveBerry(int _count)
    {
        berryCount -= _count;
        countBerries.text = berryCount.ToString();
    }

    public void RemoveGem(int _count)
    {
        gemCount -= _count;
        countGem.text = gemCount.ToString();
    }

    public void AddBerry(int _count)
    {
        berryCount += _count;
        countBerries.text = berryCount.ToString();
    }
    public void AddGem(int _count)
    {
        gemCount += _count;
        countGem.text = gemCount.ToString();
    }
}
