using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorTimeGem : MonoBehaviour
{

    public SpawnScript spawner;
    public scenManager manager;

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.transform.tag.CompareTo("Player1") == 1 
            || other.gameObject.transform.tag.CompareTo("Player2") == 1)
        {
            other.gameObject.GetComponentInParent<CollectorPlayer>().DiamondCollected();
            spawner.GetComponent<SpawnScript>().PlayAud();
            gameObject.SetActive(false);
            if (PersistentManagerScript.Instance.player1Score > PersistentManagerScript.Instance.player2Score)
            {
                manager.IncreaseTime();
            }
            else if(PersistentManagerScript.Instance.player1Score < PersistentManagerScript.Instance.player2Score)
            {
                manager.DecreaseTime();
            }
        }
    }
}
