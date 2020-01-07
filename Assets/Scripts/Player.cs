using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    //Serializing fields allows editing within the Unity editor without making it a public variable.
    [SerializeField]
    private float movementSpeed = 2.5f;

    [SerializeField]
    private float jumpHeight = 6f;

    //Gets sprite renderer from player object.
    private SpriteRenderer sr;

    private bool isJumping, isGrounded, isSprinting, isRight = true;
    
    //Colors for the player's injury status
    private Color normal = new Color(0, 255, 0);
    private Color hurt = new Color(255, 0, 0);

    //Timer for resetting the player's color.
    private float hurtTimer;
    
    //Delay timer for shooting
    private float delayTimer;
    
    //Timer for jiggling the player
    private float jiggleTimer;
    
    //Declares what the dealy to shoot should be
    [SerializeField]
    private float shootingDelay = 0.4f;

    //Boolean that determines the injury status.
    public static bool isHurt;
    
    //Boolean to use for starting position.
    public static bool isStarting;

    //Sound that plays when jumping
    public AudioClip jumpSound;

    //AudioSource component on player
    private AudioSource audioSource;
    
    //Bullet prefab
    public GameObject Bullet;
    
    //Transform of Fire Point
    public Transform firePoint;
    
    //Sound that plays when bullet is fired
    public AudioClip firingSound;

    void Start()
    {
        //If the isStarting boolean is true, then set the start position to the object found.
        if (isStarting)
        {
            isStarting = false;
            StartPlatform startPlatform = FindObjectOfType<StartPlatform>();
            startPlatform.location();
        }
        //Sets the start position to what's in PlayerPrefs only if the scenes match.
        if (PlayerPrefsManager.getScene() == SceneManager.GetActiveScene().name)
        {
            //Gets the location from PlayerPrefsManager for saves. Ignores the z position and forces the player to always be on top.
            transform.position = new Vector3(PlayerPrefsManager.getLocation().x, PlayerPrefsManager.getLocation().y, -1f);
        }
        else
        {
            //Stores the active scene in PlayerPrefs in case the player dies.
            PlayerPrefsManager.setScene(SceneManager.GetActiveScene().name);
            PlayerPrefsManager.setLocation(transform.position);
        }
        //Finds the RigidBody component on the player
        rb = GetComponent<Rigidbody2D>();

        //Finds the SpriteRenderer component on the player
        sr = GetComponent<SpriteRenderer>();

        isJumping = false;
        isGrounded = true;
        isSprinting = false;

        //Gets AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    //Checks the lives every frame
    private void Update()
    {
        Lives();

        //If the isHurt boolean is true
        if (isHurt)
        {
            //Start counting the hurtTimer by real time.
            hurtTimer += Time.deltaTime;
            //Set the player's color to hurt.
            sr.color = hurt;

            //Once the timer is up
            if (hurtTimer >= 0.5f)
            {
                //Change the boolean back to false
                isHurt = false;
                //Set the color back to normal
                sr.color = normal;
                //Reset the hurt timer for when it is called again.
                hurtTimer = 0;
            }
        }

        //Timer that updates with time to allow the player to shoot
        delayTimer += Time.deltaTime;
    }

    void FixedUpdate()
    {
        //Floats that use the Unity input axes for movement.
        float horizontal = Input.GetAxis("Horizontal");

        //Flips the character if necessary.
        if (horizontal > 0 && !isRight)
        {
            Flip();
        }
        else if (horizontal < 0 && isRight)
        {
            Flip();
        }

        float jump = Input.GetAxis("Jump");

        //If the player wants to sprint, their speed will be doubled.
        if (Input.GetAxis("Sprint") >= 1f && !isSprinting)
        {
            isSprinting = true;
            movementSpeed = movementSpeed * 2f;
        }
        //If the player lets go, reset the speed back to normal.
        else if (Input.GetAxis("Sprint") <= 0f && isSprinting)
        {
            isSprinting = false;
            movementSpeed /= 2;
        }
        
        //Calls HandleMovement for horizontal movement
        HandleMovement(horizontal);
        
        //Might fix the stuck bug
        if (((horizontal - 0) > 0.5f) || (horizontal - 0) < -0.5f)
        {
            float forwardDistance = 0.001f;

            if (!isRight)
                forwardDistance *= -1;
            
            if (jiggleTimer <= 0.01f)
            {
                transform.Translate(forwardDistance, 0, 0);
            }

            jiggleTimer += Time.deltaTime;

            if (jiggleTimer >= 0.02f)
            {
                transform.Translate(-forwardDistance, 0, 0);
                jiggleTimer = 0f;
            }
        }

        //If the player is grounded and is not currently jumping, and the jump key is pressed, then call the Jump function.
        if (jump >= 1f && isGrounded && !isJumping)
        {
            Jumping();
        }

        //If the player presses the button to fire and the delay timer has been met, then fire the bullet and reset the timer.
        if (Input.GetAxis("Fire1") >= 1f && delayTimer >= shootingDelay)
        {
            delayTimer = 0f;
            Fire();
        }
    }

    public void Lives()
    {
        //If the player runs out of lives, load the game over scene.
        if (PlayerPrefsManager.getLives() <= 0)
        {
            Cursor.visible = true;
            SceneManager.LoadScene("GameOver");
        }
        //Once the player runs out of health, reset health and decrease lives.
        else if (PlayerPrefsManager.getHealth() <= 0 && PlayerPrefsManager.getLives() > 0)
        {
            PlayerPrefsManager.decreaseLives(1);
            PlayerPrefsManager.setHealth(100);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void HandleMovement(float horizontal)
    {
        //Moves the player in the direction that the axis calls for
        rb.velocity = new Vector2(horizontal * movementSpeed, rb.velocity.y);
    }

    void Jumping()
    {
        PlaySound(jumpSound);
        //Jumps the player up and sets booleans
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        isGrounded = false;
        isJumping = true;
    }

    //If the player leaves a platform but isn't jumping, still make sure to say they're not grounded
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }
    
    //Take damage function
    public static void takeDamage(int amount)
    {
        PlayerPrefsManager.decreaseHealth(amount);
        //Sets the hurt boolean to true for changing the player's color.
        isHurt = true;
    }

    //grounds the player
    public void Ground()
    {
        isGrounded = true;
        isJumping = false;
    }

    private void Flip()
    {
        //Inverts the boolean to prevent flipping too often.
        isRight = !isRight;
        //Rotates the player left or right.
        transform.Rotate(0f, 180f, 0f);
    }

    //Creates a bullet in the scene and makes a firing noise.
    private void Fire()
    {
        PlaySound(firingSound);
        Instantiate(Bullet, firePoint.position, firePoint.rotation);
    }

    //Sets the audioSource clip to the a and plays the sound.
    private void PlaySound(AudioClip sound)
    {
        audioSource.clip = sound;
        audioSource.Play();
    }
}
