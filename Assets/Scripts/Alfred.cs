using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Random = System.Random;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Alfred : Enemy
{
    private float shotClock = 0f; //measures how long it has been since Alfred last shot a bullet

    [FormerlySerializedAs("shootingCooldown")] [SerializeField] float shootingThreshold = 1f; //time that should pass between shots

    private float bossClock = 0f; //time that has passed since Alfred became a boss

    [SerializeField] private float bossThreshold = 10f; //time that Boss Mode should last

    private float deathCountdown = 3f; //time in seconds between boss death and ending cutscene

    private bool canGoBoss = true; //true if Alfred can be a boss

    private bool isAlive = true; //false if Alfred is dead

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

    //Fire points
    [SerializeField] Transform firePoint1 = null;
    [SerializeField] Transform firePoint2 = null;
    
    private bool isBoss = false; //tracks whether Alfred is currently a boss

    private int firePointChoice; //number that will be randomized to choose whether Alfred shoots up or down

    public int baseHealth; //stores Alfred's initial health. This is used to calculate how much his health bar is filled in
    
    //Startup
    //Assigns some variables
    void Start()
    {
        currentBullet = Bullet;
        sr = GetComponent<SpriteRenderer>();
        baseHealth = health;
    }
    
    // Update is called once per frame
    void Update()
    {
        //Increases shotClock
        shotClock += Time.deltaTime;
        
        //Fires if applicable
        if (shotClock >= shootingThreshold && isAlive)
        {
            Fire();
            shotClock = 0f;
        }

        //Activates Boss Mode if applicable
        if (health <= 20)
        {
            BossMode();
        }
        
        //Deactivates Boss Mode when necessary
        if (!canBeKilled)
        {
            bossClock += Time.deltaTime;

            if (bossClock >= bossThreshold)
            {
                NotBossMode();
            }
        }

        //kills Alfred
        if (health <= 0)
        {
            AlfredDeath();
        }

        //counts time since Alfred died
        if (!isAlive)
        {
            deathCountdown -= Time.deltaTime;
        }

        //moves to cutscene when necessary
        if (deathCountdown <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
    //Creates a bullet in the scene and makes a firing noise.
    private void Fire()
    {
        firePointChoice = UnityEngine.Random.Range(1, 3);
        
        if (!isBoss && firePointChoice == 1) //fires at the top half the time (unless it's the boss battle)
        {
            Instantiate(currentBullet, firePoint1.position, firePoint1.rotation);
        }
        else //fires at the bottom half the time (and always during the boss battle)
        {
            Instantiate(currentBullet, firePoint2.position, firePoint2.rotation);
        }
    }
    
    //Alfred goes nuts
    private void BossMode()
    {
        if (canGoBoss)
        {
            health = baseHealth;
            canBeKilled = false;
            shootingThreshold *= 1.3f;

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
        shootingThreshold /= 1.3f;

        sr.sprite = NormalSprite;
        currentBullet = Bullet;
        isBoss = false;
    }
    
    //Kills Alfred
    private void AlfredDeath()
    {
        isAlive = false;

        sr.enabled = false;
    }
}
