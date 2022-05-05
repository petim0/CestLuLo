using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement1 : MonoBehaviour
{
    Vector3 m_Movement;

 // Start is called before the first frame update
    void Start(){

}
   
 // Update is called once per frame
    void Update(){

        float up = (Input.GetKey(KeyCode.UpArrow)) ? 1 : 0;
        float down = (Input.GetKey(KeyCode.DownArrow)) ? 1 : 0;

        float right = Input.GetKey(KeyCode.RightArrow) ? 1 : 0;
        float left = Input.GetKey(KeyCode.LeftArrow) ? 1 : 0;

         m_Movement.Set(right - left, 0f, up - down) ;
         m_Movement.Normalize() ;
         transform.Translate(Time.deltaTime* m_Movement) ;
    }
}
