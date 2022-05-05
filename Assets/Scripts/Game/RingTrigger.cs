using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTrigger : MonoBehaviour
{


    public AudioSource soundWinPoint;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {


        if (other.transform.parent.gameObject.CompareTag("ghost"))
        {
            GhostSheepBehavior ghostBehaviour = other.transform.parent.gameObject.GetComponent<GhostSheepBehavior>();

            if (!ghostBehaviour.getIsGhost())
            {
                GameObject player = ghostBehaviour.findClosestPlayer();
                if (player.CompareTag("Player1"))
                {
                    PersistentManagerScript.Instance.player1Score++;
                }
                else if (player.CompareTag("Player2"))
                {
                    PersistentManagerScript.Instance.player2Score++;
                }

                soundWinPoint.Play();

                Debug.Log(other.transform.parent.gameObject.tag + " triggers.");
            }

            
        }
    }
}
