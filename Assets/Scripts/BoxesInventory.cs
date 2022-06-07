using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxesInventory : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        PlayerInventory player = other.GetComponent<PlayerInventory>();

        if (other.CompareTag("Player1") != null || other.CompareTag("Player2") != null
            || other.CompareTag("Player3") != null)
        {
            gameObject.SetActive(false);

        }
    }
}
