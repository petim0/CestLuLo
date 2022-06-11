using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other) {
        Debug.Log("Player collided with oil");
        
        string tag = other.transform.parent.gameObject.tag;
        if (tag == "Player1" || tag == "Player2" ) {
            other.transform.parent.gameObject.GetComponent<PlayerEffectsManager>().Slide();
            //other.transform.parent.gameObject.GetComponent<MoveWithKeyboardBehavior>().InverseControl();
        } else if (tag == "Player3"){
            other.transform.parent.gameObject.GetComponent<followPath>().Slide(this.gameObject.transform.position);
        }
    }


    public void OnTriggerExit(Collider other) {
        string tag = other.transform.parent.gameObject.tag;
        if (tag == "Player1" || tag == "Player2" ) {
            other.transform.parent.gameObject.GetComponent<PlayerEffectsManager>().StopSliding();
        } else if (tag == "Player3")
        {
            other.transform.parent.gameObject.GetComponent<followPath>().StopSliding();
        }
    }
}
