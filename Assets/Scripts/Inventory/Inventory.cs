using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    //public static event Action<List<InventoryItem>> OnInventoryChange;
    public InventoryManager inventoryManager;

    public List<InventoryItem> inventory = new List<InventoryItem>(1);
    private Dictionary<ItemData, InventoryItem> itemDictionary = new Dictionary<ItemData, InventoryItem>();


/*    private void OnEnable(){
        Boxes.OnBoxCollected += Add;
        Boxes.OnBoxCollected += Add;
        Boxes.OnBoxCollected += Add;

    }

    private void OnDisable(){
        Boxes.OnBoxCollected -= Add;
    }
*/
    public void Add(ItemData itemData) {
        if (itemDictionary.TryGetValue(itemData, out InventoryItem item)) {
            item.AddToStack();
            //Debug.Log($"{item.itemData.displayName} total stack is now {item.stackSize}");
            inventoryManager.DrawInventorySlot(inventory);
        } else {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            //Debug.Log($"{item.itemData.displayName} to the inventory for the first time");
            inventoryManager.DrawInventorySlot(inventory);
        }
    }

    public void Remove(ItemData itemData) {
        if (itemDictionary.TryGetValue(itemData, out InventoryItem item)    ) {
            item.RemoveFromStack();
            if (item.stackSize == 0) {
                inventory.Remove(item);
                itemDictionary.Remove(itemData);
            }
            inventoryManager.DrawInventorySlot(inventory);
        }
    }

}
