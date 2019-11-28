using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Player player;
    private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        //Find a player in the scene
        player = FindObjectOfType<Player>();
        //Offset the camera between the player and the camera
        offset = new Vector3(0, 0, -9);
    }

    //LateUpdate() is ran after all other updates, such as Update() and FixedUpdate()
    void LateUpdate()
    {
        //Set the position to the same as the player, but with an offset calculated at the start.
        transform.position = player.transform.position + offset;
    }
}
