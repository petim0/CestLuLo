using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMouvement : MonoBehaviour
{
    Vector3 m_Movement;

 // Start is called before the first frame update
    void Start(){

}
   
 // Update is called once per frame
    void Update(){

        float up = (Input.GetKey(KeyCode.W)) ? 1 : 0;
        float down = (Input.GetKey(KeyCode.S)) ? 1 : 0;

        float right = Input.GetKey(KeyCode.D) ? 1 : 0;
        float left = Input.GetKey(KeyCode.A) ? 1 : 0;

         m_Movement.Set(right - left, 0f, up - down) ;
         m_Movement.Normalize() ;
         transform.Translate(Time.deltaTime* m_Movement) ;
    }
}
