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
        if (other.gameObject.CompareTag("Player"))
        {
            if (transform.position.y - other.GetComponent<BoxCollider2D>().transform.position.y < 0 && (other.GetComponent<Rigidbody2D>().velocity.y < 0))
            {
                GetComponentInParent<Enemy>().takeDamage(100);
            }
        }
    }
}
