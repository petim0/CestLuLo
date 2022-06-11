using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DizzyWeapon : MonoBehaviour
{
    public bool isFiring;

    public DizzyBullet bullet;
    public float bulletSpeed;

    public Inventory inventory;
    public int numberOfBullets;

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
        if (isFiring) {

            shotCounter -= Time.deltaTime;

            if (0 < numberOfBullets) {
                if (shotCounter <= 0) {
                    shotCounter = fireRate;
                    DizzyBullet newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as DizzyBullet;
                    newBullet.speed = bulletSpeed;
                    inventory.Remove(inventory.inventory[0].itemData);
                    numberOfBullets--;
                }
            } else {
                isFiring = false;
            }

        } else {
            shotCounter = 0;
        }
        
    }
    
}
