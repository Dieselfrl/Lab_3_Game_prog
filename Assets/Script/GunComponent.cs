using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float chargeSpeed = 10f;
    private float chargeTime = 0f;
    
    void Update()
    {
        //Check button is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            chargeTime = 0f;
        }
        //Calculate time the button is held for
        if (Input.GetButton("Fire1"))
        {
            chargeTime = Mathf.Clamp(chargeTime + Time.deltaTime, 0f, 5f);
        }
        //Check for button release to instantiate the bullet
        if (Input.GetButtonUp("Fire1"))
        {
            // Instantiate bullet when button Fire1 is released
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            BulletComponent bulletComp = bullet.GetComponent<BulletComponent>();
            //Multiply charge speed with time button Fire1 was held down
            bulletComp.bulletSpeed += (chargeSpeed * chargeTime);
        }

    }
}

