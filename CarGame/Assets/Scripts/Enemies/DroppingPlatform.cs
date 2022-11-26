using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the dropping platform 
/// </summary>
/// 


public class DroppingPlatform : MonoBehaviour
{
    Rigidbody rb;
    public float DroppingDelay;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("StartDropping", DroppingDelay);
        }

        
    }

    void StartDropping()
    {
        rb.isKinematic = false;
    }
}
