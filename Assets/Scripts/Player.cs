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

    private bool isJumping, isGrounded, isSprinting;
    
    //Colors for the player's injury status
    private Color normal = new Color(0, 255, 0);
    private Color hurt = new Color(255, 0, 0);

    //Timer for resetting the player's color.
    private float hurtTimer;

    //Boolean that determines the injury status.
    public static bool isHurt;

    //Sound that plays when jumping
    public AudioClip jumpSound;

    //AudioSource component on player
    private AudioSource audioSource;

    void Start()
    {
        //Gets the location from PlayerPrefsManager for saves. Ignores the z position and forces the player to always be on top.
        //TODO: Maybe only manually set the position if it isn't 0,0,0 and reset the position when completing a level.
        transform.position = new Vector3(PlayerPrefsManager.getLocation().x, PlayerPrefsManager.getLocation().y, -1f);
        //Finds the RigidBody component on the player
        rb = GetComponent<Rigidbody2D>();

        //Finds the SpriteRenderer component on the player
        sr = GetComponent<SpriteRenderer>();
        
        //Stores the active scene in PlayerPrefs in case the player dies.
        PlayerPrefsManager.setScene(SceneManager.GetActiveScene().name);
        
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
    }

    void FixedUpdate()
    {
        //Floats that use the Unity input axes for movement.
        float horizontal = Input.GetAxis("Horizontal");
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

        //If the player is grounded and is not currently jumping, and the jump key is pressed, then call the Jump function.
        if (jump >= 1f && isGrounded && !isJumping)
        {
            Jumping();
        }
    }

    public void Lives()
    {
        //TODO: Lives system
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
        //Sets the audioSource clip to the jump sound and plays the jump sound.
        audioSource.clip = jumpSound;
        audioSource.Play();
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
}
