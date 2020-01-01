using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Serialization;

public class Teleport : MonoBehaviour
{
    [SerializeField] float teleportX = 0;
    [SerializeField] float teleportY = 0;
    [SerializeField] float teleportZ = -1;

    private bool hasTeleportedBefore;

    //teleport the player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = new Vector3(teleportX, teleportY, teleportZ);

            //Checks if the player has teleported before to prevent the spawning of a key again.
            if (!hasTeleportedBefore)
            {
                //Drop items if there are any
                DropItem[] di = GetComponents<DropItem>();
                for (int i = 0; i < di.Length; i++)
                {
                    di[i].Drop();
                }

                hasTeleportedBefore = true;
            }
        }
    }
}
