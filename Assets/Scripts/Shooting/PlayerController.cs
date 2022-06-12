using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Weapon weapon;
    public DizzyWeapon dizzyWeapon;
    public OilWeapon oilWeapon;

    public Inventory inventory;

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.CompareTag("Player1")) {

            if (Input.GetKeyDown(KeyCode.F)) {
                if (inventory.inventory.Count > 0) {
                    InventoryItem item = inventory.inventory[0];
                    if (item.itemData.displayName == "Para") {
                        if (item.stackSize > 0) {
                            weapon.numberOfBullets = item.stackSize;
                            weapon.isFiring = true;
                            //inventory.Remove(item.itemData);
                        }
                    } else if (item.itemData.displayName == "Oil") {
                        if (item.stackSize > 0) {
                            oilWeapon.numberOfBullets = item.stackSize;
                            oilWeapon.isFiring = true;
                            //inventory.Remove(item.itemData);
                        }
                    } else if (item.itemData.displayName == "Dizzy") {
                        if (item.stackSize > 0) {
                            dizzyWeapon.numberOfBullets = item.stackSize;
                            dizzyWeapon.isFiring = true;
                            //inventory.Remove(item.itemData);
                        }
                    }
                }
            }

            if (Input.GetKeyUp(KeyCode.F)) {
                weapon.isFiring = false;
                oilWeapon.isFiring = false;
                dizzyWeapon.isFiring = false;
            }

        } else if (this.gameObject.CompareTag("Player2")) {

            if (Input.GetKeyDown(KeyCode.L)) {
                if (inventory.inventory.Count > 0) {
                    InventoryItem item = inventory.inventory[0];
                    if (item.itemData.displayName == "Para") {
                        if (item.stackSize > 0) {
                            weapon.numberOfBullets = item.stackSize;
                            weapon.isFiring = true;
                            //inventory.Remove(item.itemData);
                        }
                    } else if (item.itemData.displayName == "Oil") {
                        if (item.stackSize > 0) {
                            oilWeapon.numberOfBullets = item.stackSize;
                            oilWeapon.isFiring = true;
                            //inventory.Remove(item.itemData);
                        }
                    } else if (item.itemData.displayName == "Dizzy") {
                        if (item.stackSize > 0) {
                            dizzyWeapon.numberOfBullets = item.stackSize;
                            dizzyWeapon.isFiring = true;
                            //inventory.Remove(item.itemData);
                        }
                    }
                }
            }

            if (Input.GetKeyUp(KeyCode.L)) {
                weapon.isFiring = false;
                oilWeapon.isFiring = false;
                dizzyWeapon.isFiring = false;
            }
        }
    }

    public bool isEmpty() {
        return inventory.inventory.Count <= 0;
    }

}
