using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFallingObj : MonoBehaviour
{
    public GameObject enemy;
   

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Ground"))
        {
           // Debug.Log("Triggered");
            DestroyObject();
        }

        
    }



    void DestroyObject()
    {
        Destroy(enemy,5);

    }
}
