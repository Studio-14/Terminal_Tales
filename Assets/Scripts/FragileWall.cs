using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileWall : MonoBehaviour
{
    public int strength = 10;
    public int hits = 0;

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
