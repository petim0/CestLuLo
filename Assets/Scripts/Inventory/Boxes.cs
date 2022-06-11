using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boxes : MonoBehaviour
{

    public static event HandleBoxCollected OnBoxCollected;
    public delegate void HandleBoxCollected(ItemData itemData);
    
    public List<ItemData> itemDataList = new List<ItemData>(3);

    public const int respawnTime = 3;
    public int timer = respawnTime;

    public void Collect(Collider other) {
        //Debug.Log("Collected a box");
        ItemData finalData = GetRandomItemData();
        //Debug.Log("Collected a " + finalData.displayName);
        other.transform.parent.gameObject.GetComponent<PlayerController>().inventory.Add(finalData);
        other.transform.parent.gameObject.GetComponent<PlayerController>().inventory.Add(finalData);
        other.transform.parent.gameObject.GetComponent<PlayerController>().inventory.Add(finalData);

        OnBoxCollected?.Invoke(finalData);
    }

    public void OnTriggerEnter(Collider other)
    {
        string tag = other.transform.parent.gameObject.tag;
        //Debug.Log("Player collided with box");
        if (tag == "Player1" || tag == "Player2" || tag == "Player3") {}
        {
            //Debug.Log("Player collided with box");
            if (other.transform.parent.gameObject.GetComponent<PlayerController>().isEmpty())
            {
                if (timer > 0) {
                    Collect(other);
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
                respawnAfterTimer();

            }



        }
    }

    // Returns a random item data from itemDataList
    public ItemData GetRandomItemData() {
        int randomIndex = UnityEngine.Random.Range(0, itemDataList.Count);
        //Debug.Log("Random index is " + randomIndex);
        return itemDataList[randomIndex];
    }


    // Set the box to be active after a certain amount of time
    public void respawnAfterTimer() {
        if (timer <= 0) {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            timer = respawnTime;
        } else {
            timer--;
        }
    }
    
    
}
