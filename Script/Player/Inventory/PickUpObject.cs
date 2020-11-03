using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameObject.CompareTag("berry"))
            {
                Inventory.myOwnInventory.AddBerry(1);
                CurrentSceneMangement.instance.berriesPick++;
            }

            if (gameObject.CompareTag("Megaberry"))
            {
                Inventory.myOwnInventory.AddBerry(5);
                CurrentSceneMangement.instance.AddBerry(5);
            }

            if (gameObject.CompareTag("gem"))
            {
                Inventory.myOwnInventory.AddGem(1);
                CurrentSceneMangement.instance.gemsPick++;
            }

            if (gameObject.CompareTag("Megagem"))
            {
                Inventory.myOwnInventory.AddGem(5);
                CurrentSceneMangement.instance.AddGem(5);
            }

            Destroy(gameObject);
        }
    }
}
