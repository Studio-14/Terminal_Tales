using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileWall : MonoBehaviour
{
    [SerializeField] private int strength = 10;
    [SerializeField] private int hits = 0;

    //Allows wall to take hits and be destroyed at a certain point
    public void takeHit()
    {
        hits++;
        if (hits >= strength)
        {
            Destroy(gameObject);
        }
    }
}
