using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilWeapon : MonoBehaviour
{
    public bool isFiring;

    public Flaque flaque;

    public float fireRate;
    private float shotCounter;

    public Transform firePoint;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring){

            shotCounter -= Time.deltaTime;

            if (shotCounter <= 0) {
                shotCounter = fireRate;
                Flaque oil = Instantiate(flaque, firePoint.position, firePoint.rotation) as Flaque;
            }
        } else {
            shotCounter = 0;
        }
        
    }
    
}
