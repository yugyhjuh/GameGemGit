using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    public Item item;  // Reference to the ScriptableObject item
    public Image uiImage;  // Reference to the UI Image that will display the item icon

    // OnTriggerEnter2D is for 2D; use OnTriggerEnter for 3D games
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player entered the trigger zone
        if (other.CompareTag("Player"))
        {
            Inventory playerInventory = other.GetComponent<Inventory>();
            if (playerInventory != null)
            {
                // Add the item to the player's inventory and destroy the pickup object
                bool wasAdded = playerInventory.AddItem(item);
                if (wasAdded)
                {
                    // Display the item icon in the UI image
                    DisplayItemIcon();

                    // Destroy the pickup object after adding to inventory
                    Destroy(gameObject);
                }
            }
        }
    }

    // Function to display the item icon in the UI image
    void DisplayItemIcon()
    {
        // Check if the item has an icon and assign it to the UI image
        if (item.icon != null)
        {
            uiImage.sprite = item.icon;  // Set the UI Image's sprite to the item's icon
            uiImage.enabled = true;      // Make the UI Image visible
        }
    }
}
