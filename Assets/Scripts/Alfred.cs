using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Random = System.Random;

public class Alfred : MonoBehaviour
{
    private float shotClock = 0f;
    
    private bool isShooting = true;

    private bool shootingTop = false;
    
    [SerializeField] float shootingCooldown = 1f;

    [SerializeField] private float bossCountdown = 0f;

    private bool canGoBoss = true;
    
    //AudioSource component on player
    private AudioSource audioSource;
    
    //Bullet prefab
    [SerializeField] private GameObject Bullet = null;
    //Boss bullet
    [SerializeField] private GameObject BossBullet = null;
    //Current bullet
    private GameObject currentBullet;
    
    //Regular sprite
    [SerializeField] private Sprite NormalSprite = null;
    //Boss sprite
    [SerializeField] private Sprite BossSprite = null;

    //Transform of Fire Point
    [SerializeField] Transform firePoint1 = null;

    [SerializeField] Transform firePoint2 = null;
    
    //Sound that plays when bullet is fired
    [SerializeField] public AudioClip firingSound;

    //Enemy component
    private Enemy enemyScript;
    
    //SpriteRenderer component
    private SpriteRenderer sr;
    
    //Startup
    void Start()
    {
        currentBullet = Bullet;
        enemyScript = GetComponent<Enemy>();
        sr = GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        shotClock += Time.deltaTime;
        
        if (isShooting && shotClock >= shootingCooldown)
        {
            Fire();
            shotClock = 0f;
        }

        if (enemyScript.health <= 20)
        {
            BossMode();
        }

        if (!enemyScript.canBeKilled)
        {
            bossCountdown += Time.deltaTime;

            if (bossCountdown >= 10f)
            {
                NotBossMode();
            }
        }
    }
    
    //Creates a bullet in the scene and makes a firing noise.
    private void Fire()
    {
        //PlaySound(firingSound);

        if (shootingTop)
        {
            Instantiate(currentBullet, firePoint1.position, firePoint1.rotation);
        }
        else
        {
            Instantiate(currentBullet, firePoint2.position, firePoint2.rotation);
        }

        shootingTop = !shootingTop;
    }
    
    //Alfred goes nuts
    private void BossMode()
    {
        if (canGoBoss)
        {
            enemyScript.health = 200;
            enemyScript.canBeKilled = false;

            sr.sprite = BossSprite;
            currentBullet = BossBullet;
            canGoBoss = false;
        }

    }
    
    //Alfred stops going nuts
    private void NotBossMode()
    {
        enemyScript.canBeKilled = true;

        sr.sprite = NormalSprite;
        currentBullet = Bullet;
    }
}
