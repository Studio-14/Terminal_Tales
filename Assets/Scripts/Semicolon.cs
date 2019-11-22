using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semicolon : MonoBehaviour
{

    //If the player jumps on top of the semicolon, kill the semicolon.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.transform.position.y >= gameObject.GetComponent<BoxCollider2D>().size.y)
            {
                GetComponent<Enemy>().takeDamage(100);
            }
        }
    }
}
