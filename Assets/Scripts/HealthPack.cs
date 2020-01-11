using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] private int amountOfHealth = 0;

    private bool canHeal = true;
    
    //activate the health pack
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canHeal && other.tag == "Player")
        {
            PlayerPrefsManager.increaseHealth(amountOfHealth);
            canHeal = false;
            Destroy(gameObject);
        }
    }
}
