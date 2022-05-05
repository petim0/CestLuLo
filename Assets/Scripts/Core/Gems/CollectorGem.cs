using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorGem : MonoBehaviour
{
    public SpawnScript spawner;

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.transform.tag.CompareTo("Player1") == 1)
        {
            other.gameObject.GetComponentInParent<CollectorPlayer>().DiamondCollected();
            spawner.GetComponent<SpawnScript>().PlayAud();
            gameObject.SetActive(false);

        }
        else if(other.gameObject.transform.tag.CompareTo("Player2") == 1)
        {
            other.gameObject.GetComponentInParent<CollectorPlayer>().DiamondCollected();
            spawner.GetComponent<SpawnScript>().PlayAud();
            gameObject.SetActive(false);
        }
    }
}
