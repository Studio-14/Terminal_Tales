using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounding : MonoBehaviour
{
    //If the player jumps on top of the platform, ground the player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Foot Trigger"))
        {
            other.GetComponentInParent<Player>().Ground();
        }
    }
}
