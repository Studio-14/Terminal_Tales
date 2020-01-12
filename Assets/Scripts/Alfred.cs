﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Random = System.Random;
using UnityEngine.SceneManagement;

public class Alfred : Enemy
{
    private float shotClock = 0f;
    
    private bool isShooting = true;

    [SerializeField] float shootingCooldown = 1f;

    private float bossCountdown = 0f;

    private float deathCountdown = 3f; //time in seconds between boss death and ending cutscene

    private bool canGoBoss = true;

    private bool isAlive = true;

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
    //Dead sprite
    [SerializeField] private Sprite DeadSprite = null;

    //Transform of Fire Point
    [SerializeField] Transform firePoint1 = null;

    [SerializeField] Transform firePoint2 = null;

    private bool isBoss = false;

    //SpriteRenderer component
    private SpriteRenderer sr;

    private int number;

    public int baseHealth;
    
    //Startup
    void Start()
    {
        currentBullet = Bullet;
        sr = GetComponent<SpriteRenderer>();

        baseHealth = health;
    }
    
    // Update is called once per frame
    void Update()
    {
        shotClock += Time.deltaTime;
        
        if (isShooting && shotClock >= shootingCooldown && isAlive)
        {
            Fire();
            shotClock = 0f;
        }

        if (health <= 20)
        {
            BossMode();
        }
        
        if (!canBeKilled)
        {
            bossCountdown += Time.deltaTime;

            if (bossCountdown >= 10f)
            {
                NotBossMode();
            }
        }

        if (health <= 0)
        {
            AlfredDeath();
        }

        if (!isAlive)
        {
            deathCountdown -= Time.deltaTime;
        }

        if (deathCountdown <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //todo use NextLevel.cs so that if another level is after an Alfred death, playerprefs are changed
        }
    }
    
    //Creates a bullet in the scene and makes a firing noise.
    private void Fire()
    {
        number = UnityEngine.Random.Range(1, 3);

        if (!isBoss && number == 1)
        {
            Instantiate(currentBullet, firePoint1.position, firePoint1.rotation);
        }
        else
        {
            Instantiate(currentBullet, firePoint2.position, firePoint2.rotation);
        }
    }
    
    //Alfred goes nuts
    private void BossMode()
    {
        if (canGoBoss)
        {
            health = 200;
            canBeKilled = false;
            shootingCooldown *= 1.3f;

            sr.sprite = BossSprite;
            currentBullet = BossBullet;
            canGoBoss = false;
            isBoss = true;
        }

    }
    
    //Alfred stops going nuts
    private void NotBossMode()
    {
        canBeKilled = true;
        shootingCooldown /= 1.3f;

        sr.sprite = NormalSprite;
        currentBullet = Bullet;
        isBoss = false;
    }
    
    //Kills Alfred
    private void AlfredDeath()
    {
        isAlive = false;

        sr.sprite = DeadSprite;
    }
}
