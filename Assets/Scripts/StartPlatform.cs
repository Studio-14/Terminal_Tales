using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatform : MonoBehaviour
{

    private float yOffset = 0.8f;

    //Function that sets the player's spawn to a location automatically.
    public void location()
    {
        Vector3 currentLoc = transform.position;

        Vector3 loc = new Vector3(currentLoc.x, currentLoc.y + yOffset, -1f);
        
        PlayerPrefsManager.setLocation(loc);
    }
}
