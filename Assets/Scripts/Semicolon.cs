using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Semicolon : MonoBehaviour
{

    //If the player jumps on top of the semicolon, kill the semicolon.
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.CompareTag("Player"))
        if (other.gameObject.CompareTag("Foot Trigger")) 
        {
            //if (transform.position.y - other.GetComponent<BoxCollider2D>().transform.position.y < 0 && (other.GetComponent<Rigidbody2D>().velocity.y < 0))
            if (other.GetComponentInParent<Rigidbody2D>().velocity.y < 0)
            {
                //TODO: Fix health taking from player later.
                PlayerPrefsManager.increaseHealth(10);
                GetComponentInParent<Enemy>().takeDamage(100);
            }
        }
    }
}
