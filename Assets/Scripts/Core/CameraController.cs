using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;        //Public variable to store a reference to the player game object

    public float Turnspeed = 2.0f;


    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start () 
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
 



    }

    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.


        transform.position = Vector3.Lerp(transform.position, player.transform.position,1f );
        transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, 1f);
    
      //  transform.position = player.transform.position + offset;
     //   transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, Time.deltaTime * Turnspeed);   
     //  transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * Turnspeed);
        }

        /*
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        
        // transform.LookAt(player.transform.position, Vector3.up);
        Turnto = player.transform.rotation;

        transform.rotation = Quaternion.Slerp(transform.rotation, Turnto, Time.deltaTime * Turnspeed);
 

        /*
      
        //transform.eulerAngles +=  rotateValue * camSpeed;
}
}

{
    public Transform camTarget;
    public float pLerp = .01f;
    public float rLerp = .02f;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, camTarget.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rLerp);
    }
    */
}
