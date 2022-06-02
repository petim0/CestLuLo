using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Weapon weapon;

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.CompareTag("Player1")) {

            if (Input.GetKeyDown(KeyCode.L)) {
                weapon.isFiring = true;
                //weapon.Fire();
            }

            if (Input.GetKeyUp(KeyCode.L)) {
                weapon.isFiring = false;
            }
        } else if (this.gameObject.CompareTag("Player2")) {

            if (Input.GetKeyDown(KeyCode.F)) {
                weapon.isFiring = true;
                //weapon.Fire();
            }

            if (Input.GetKeyUp(KeyCode.F)) {
                weapon.isFiring = false;
            }
        }


    }

}
