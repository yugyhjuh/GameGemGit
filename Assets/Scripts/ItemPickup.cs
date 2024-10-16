using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;  // Reference to the item to be picked up

    // OnTriggerEnter2D is for 2D; use OnTriggerEnter for 3D games
    void OnTriggerEnter2D(Collider2D other)
    {   
        Debug.Log("HEK");
        // Check if the player entered the trigger zone
        if (other.CompareTag("Player"))
        {
            Debug.Log("HOK");

            Inventory playerInventory = other.GetComponent<Inventory>();
            if (playerInventory != null)
            {
                Debug.Log("HAK");
                // Add the item to the player's inventory and destroy the pickup object
                bool wasAdded = playerInventory.AddItem(item);
                if (wasAdded)
                {
                    Destroy(gameObject);  // Destroy the pickup object
                }
            }
        }
    }
}
