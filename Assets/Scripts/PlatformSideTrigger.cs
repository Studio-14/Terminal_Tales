using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSideTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player>().UpdateCorner();
            Debug.Log("Corner detected");
        }
    }
}
