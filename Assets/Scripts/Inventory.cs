using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();  // List to hold items
    public int maxInventorySize = 10;  // Maximum items allowed in inventory

    public GameObject incompleteRocket;
    public GameObject completeRocket;

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

        if (items.Count <= 2)
        {
            //Debug.Log("Rocket Unable to Board: Missing Parts");
            completeRocket.SetActive(false);  // Disable gameobject1
            incompleteRocket.SetActive(true);   // Enable gameobject2
        }
        else if (items.Count >= 3)
        {
            //Debug.Log("Rocket Launching... Failure...Self-Destructing");
            completeRocket.SetActive(true);  // Disable gameobject1
            incompleteRocket.SetActive(false);   // Enable gameobject2
        }
        else if (items.Count >= 5)
        {
            //Debug.Log("Rocket Launching... TO EARTH!");
            completeRocket.SetActive(true);  // Disable gameobject1
            incompleteRocket.SetActive(false);   // Enable gameobject2
        }
    }
    // Displays inventory contents in the console
    public void ShowInventory()
    {
        foreach (Item item in items)
        {

            Debug.Log("Inventory:" + item.itemName);
        }
    }
}
