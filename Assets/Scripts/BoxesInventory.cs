using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxesInventory : MonoBehaviour
{
    public GameObject gameObject;

    public void OnTriggerEnter(Collider other)
    {
        PlayerInventory player = other.GetComponent<PlayerInventory>();

        if (player != null)
        {
            gameObject.SetActive(false);
        }
    }
}
