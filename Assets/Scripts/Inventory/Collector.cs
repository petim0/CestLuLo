using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    // OnTriggerEnter
    void OnTriggerEnter(Collider other)
    {

        ICollectible collectible = other.GetComponent<ICollectible>();
        // If the other object is a collectible
        //var coin = other.GetComponent<Coin>();
        Debug.LogWarning("COLLIDED");
        if (collectible != null)
        {
            Debug.Log("Collect");
            // Collect the collectible
            collectible.Collect();
        }
    }

}
