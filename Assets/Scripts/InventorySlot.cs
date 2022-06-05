using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour
{

    public Image icon;
    public TextMeshProUGUI labelText;
    public TextMeshProUGUI nbrText;

    public void ClearSlot() {
        icon.enabled = false;
        labelText.enabled = false;
        nbrText.enabled = false;
    }

    public void DrawSlot(InventoryItem item) {
        if (item == null) {
            ClearSlot();
            return;
        }
        icon.enabled = true;
        labelText.enabled = true;
        nbrText.enabled = true;

        icon.sprite = item.itemData.icon;
        labelText.text = item.itemData.displayName;
        nbrText.text = item.stackSize.ToString();

    }

}
