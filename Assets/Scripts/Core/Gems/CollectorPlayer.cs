using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorPlayer : MonoBehaviour
{
    public bool getDiamond { get; private set; }
    public GameObject gameobject;
    
    public void Start()
    {
        getDiamond = false;
    }

    public void DiamondCollected()
    {
        getDiamond = true;
    }

    public void NotCollectedYet()
    {
        getDiamond = false;
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.collider.transform.parent.gameObject.CompareTag("Player1") && getDiamond)
        {
            PersistentManagerScript.Instance.player2Score += 2;
            PersistentManagerScript.Instance.player1Score -= 2;
            NotCollectedYet();
        }
        else if(other.collider.transform.parent.gameObject.CompareTag("Player2") && getDiamond)
        {
            PersistentManagerScript.Instance.player1Score += 2;
            PersistentManagerScript.Instance.player2Score -= 2;
            NotCollectedYet();
        }
    }


}
