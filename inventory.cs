using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<Item> items; // The list of items in the inventory
    public int maxItems = 10; // The maximum number of items that can be in the inventory
    public ItemDatabase itemDatabase; // Reference to the item database

    void Start()
    {
        items = new List<Item>();
    }

    public void AddItem(int itemID)
    {
        Item itemToAdd = itemDatabase.GetItem(itemID);

        if (items.Count < maxItems)
        {
            items.Add(itemToAdd);
            Debug.Log("Added " + itemToAdd.name + " to inventory.");
        }
        else
        {
            Debug.Log("Inventory full. Cannot add " + itemToAdd.name + ".");
        }
    }

    public void RemoveItem(int itemID)
    {
        Item itemToRemove = itemDatabase.GetItem(itemID);

        if (items.Contains(itemToRemove))
        {
            items.Remove(itemToRemove);
            Debug.Log("Removed " + itemToRemove.name + " from inventory.");
        }
        else
        {
            Debug.Log("Inventory does not contain " + itemToRemove.name + ".");
        }
    }

    public bool ContainsItem(int itemID)
    {
        Item itemToCheck = itemDatabase.GetItem(itemID);
        return items.Contains(itemToCheck);
    }

    public void DisplayInventory()
    {
        string itemList = "";
        for (int i = 0; i < items.Count; i++)
        {
            itemList += items[i].name;
            if (i < items.Count - 1)
            {
                itemList += ", ";
            }
        }
        Debug.Log("Inventory: " + itemList);
    }

    public int GetItemCount(int itemID)
    {
        int count = 0;
        for (int i =
