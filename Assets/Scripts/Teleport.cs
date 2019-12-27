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

    //teleport the player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = new Vector3(teleportX, teleportY, teleportZ);
            
            //Drop items if there are any
            DropItem[] di = GetComponents<DropItem>();
            for (int i = 0; i < di.Length; i++)
            {
                di[i].Drop();
            }
        }
    }
}
