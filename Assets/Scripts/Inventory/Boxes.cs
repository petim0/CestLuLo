using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boxes : MonoBehaviour
{

    public static event HandleBoxCollected OnBoxCollected;
    public delegate void HandleBoxCollected(ItemData itemData);
    
    public List<ItemData> itemDataList = new List<ItemData>(3);

    public const int respawnTime = 10;

    private float inviTime = respawnTime;
    private bool touched = false;

    void Update()
    {
        if (touched) {
            inviTime -= Time.deltaTime;
            if (inviTime < 0) {
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                touched = false;
                inviTime = respawnTime;
            }
        }

    }

    public void Collect(Collider other) {
        //Debug.Log("Collected a box");
        ItemData finalData = GetRandomItemData();
        //Debug.Log("Collected a " + finalData.displayName);
        if (finalData.displayName != "Oil") {
            other.transform.parent.gameObject.GetComponent<PlayerController>().inventory.Add(finalData);
            other.transform.parent.gameObject.GetComponent<PlayerController>().inventory.Add(finalData);
        }
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
                if (touched == false) {
                    Collect(other);
                    touched = true;
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
    }

    // Returns a random item data from itemDataList
    public ItemData GetRandomItemData() {
        int randomIndex = UnityEngine.Random.Range(0, itemDataList.Count);
        //Debug.Log("Random index is " + randomIndex);
        return itemDataList[randomIndex];
    }
        
}
