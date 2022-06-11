using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public const int capacity = 1;
    public GameObject slotPrefab;
    public List<InventorySlot> inventorySlots = new List<InventorySlot>(capacity);


/*    private void OnEnable(){
        Inventory.OnInventoryChange += DrawInventorySlot;
    }

    private void OnDisable(){
        Inventory.OnInventoryChange -= DrawInventorySlot;
    }
*/
    void ResetInvetory(){
        foreach (Transform childTransform in transform) {
            Destroy(childTransform.gameObject);
        }
        inventorySlots = new List<InventorySlot>(capacity);
    }

    public void DrawInventorySlot(List<InventoryItem> inventory){
        ResetInvetory();
        for (int i = 0; i < inventorySlots.Capacity; i++) {
            CreateInventorySlot();
        }

        for (int i = 0; i < inventory.Count; i++) {
            inventorySlots[i].DrawSlot(inventory[i]);
        }
    }

    void CreateInventorySlot() {
        GameObject slot = Instantiate(slotPrefab);
        slot.transform.SetParent(transform, false);
        
        InventorySlot newSlotComponent = slot.GetComponent<InventorySlot>();
        newSlotComponent.ClearSlot();

        inventorySlots.Add(newSlotComponent);
    }

}
