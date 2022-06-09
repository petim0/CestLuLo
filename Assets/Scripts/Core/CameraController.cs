using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;        //Public variable to store a reference to the player game object

    public float Turnspeed = 2.0f;



    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.


        transform.position = Vector3.Lerp(transform.position, player.transform.position, 1f);
        transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, 1f);

    }
}
