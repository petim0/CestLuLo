using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Weapon weapon;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            weapon.isFiring = true;
            //weapon.Fire();
        }

        if (Input.GetKeyUp("space")){
            weapon.isFiring = false;
        }
    }

}
