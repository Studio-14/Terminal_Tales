using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    //Serializing fields allows editing within the Unity editor without making it a public variable.
    [SerializeField]
    private float movementSpeed = 2.5f;

    [SerializeField]
    private float jumpHeight = 6f;

    private bool isJumping, isGrounded, isSprinting;
   
    void Start()
    {
        //Finds the RigidBody component on the player
        rb = GetComponent<Rigidbody2D>();

        //TODO: Actual lives system. This forces 3 lives.
        if (PlayerPrefsManager.getLives() <= 0)
        {
            PlayerPrefsManager.setLives(3);
            PlayerPrefsManager.setHealth(100);
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

        //TODO: Lives system
        /*
        if (PlayerPrefsManager.getLives() <= 0)
        {
            
        }
        */
        
        //Once the player runs out of health, reset health and decrease lives.
        if (PlayerPrefsManager.getHealth() <= 0)
        {
            PlayerPrefsManager.setHealth(100);
            PlayerPrefsManager.decreaseLives(1);
        }
        
    }

    void HandleMovement(float horizontal)
    {
        //Moves the player in the direction that the axis calls for
        rb.velocity = new Vector2(horizontal * movementSpeed, rb.velocity.y);
    }

    void Jumping()
    {
        //Jumps the player up and sets booleans
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        isGrounded = false;
        isJumping = true;
    }
    
    //If the player collides with a platform, reset their jumping status
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
            isJumping = false;
        }
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
    }
}
