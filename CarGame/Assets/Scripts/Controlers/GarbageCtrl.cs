using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroys any gameobject that comes in contact with this except the palyer
/// For the Player level is restrated
/// </summary>

public class GarbageCtrl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameCtrl.instance.PlayerDied(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
