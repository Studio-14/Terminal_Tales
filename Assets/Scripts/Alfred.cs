using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Alfred : MonoBehaviour
{
    private float shotClock = 0f;
    
    private bool isShooting = true;

    private bool shootingTop = false;
    
    [SerializeField] float shootingCooldown = 1f;

    //AudioSource component on player
    private AudioSource audioSource;
    
    //Bullet prefab
    [SerializeField] GameObject Bullet;

    //Transform of Fire Point
    [SerializeField] Transform firePoint1;

    [SerializeField] Transform firePoint2;
    
    //Sound that plays when bullet is fired
    [SerializeField] public AudioClip firingSound;

    // Update is called once per frame
    void Update()
    {
        shotClock += Time.deltaTime;
        
        if (isShooting && shotClock >= shootingCooldown)
        {
            Fire();
            shotClock = 0f;
        }
    }
    
    //Creates a bullet in the scene and makes a firing noise.
    private void Fire()
    {
        //PlaySound(firingSound);

        if (shootingTop)
        {
            Instantiate(Bullet, firePoint1.position, firePoint1.rotation);
        }
        else
        {
            Instantiate(Bullet, firePoint2.position, firePoint2.rotation);
        }

        shootingTop = !shootingTop;
    }
}
