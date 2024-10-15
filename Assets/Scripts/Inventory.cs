using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();  // List to hold items
    public int maxInventorySize = 10;  // Maximum items allowed in inventory

    // Adds an item to the inventory
    public bool AddItem(Item newItem)
    {
        if (items.Count < maxInventorySize)
        {
            items.Add(newItem);
            Debug.Log("Added item: " + newItem.itemName);
            return true;
        }
        else
        {
            Debug.Log("Inventory is full.");
            return false;
        }
    }

    // Removes an item from the inventory
    public void RemoveItem(Item itemToRemove)
    {
        if (items.Contains(itemToRemove))
        {
            items.Remove(itemToRemove);
            Debug.Log("Removed item: " + itemToRemove.itemName);
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            ShowInventory();
        }
    }
    // Displays inventory contents in the console
    public void ShowInventory()
    {
        Debug.Log("Inventory: ");
        foreach (Item item in items)
        {
            Debug.Log(item.itemName);
        }
    }
}
