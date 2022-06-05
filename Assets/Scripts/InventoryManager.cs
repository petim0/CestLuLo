using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public GameObject slotPrefab;
    public List<InventorySlot> inventorySlots = new List<InventorySlot>(1);



    private void OnEnable(){
        Inventory.OnInventoryChange += DrawInventorySlot;
    }

    private void OnDisable(){
        Inventory.OnInventoryChange -= DrawInventorySlot;
    }

    void ResetInvetory(){
        foreach (Transform childTransform in transform) {
            Destroy(childTransform.gameObject);
        }
        inventorySlots = new List<InventorySlot>(1);
    }

    void DrawInventorySlot(List<InventoryItem> inventory){
        ResetInvetory();
        for (int i = 0; i < inventorySlots.Capacity; i++) {
            CreateInventorySlot();
        }

        for (int i = 0; i < inventory.Count; i++) {
            inventorySlots[i].DrawSlot(inventory[i]);
        }
    }

    void CreateInventorySlot(){
        GameObject slot = Instantiate(slotPrefab);
        slot.transform.SetParent(transform, false);
        
        InventorySlot newSlotComponent = slot.GetComponent<InventorySlot>();
        newSlotComponent.ClearSlot();

        inventorySlots.Add(newSlotComponent);
    }

}
