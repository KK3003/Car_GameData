using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingStone : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* private void OnTriggerEnter(Collider other)
     {
         if(other.gameObject.CompareTag("Player"))
         {
            // Debug.Log("entered");
             rb.isKinematic = false;
         }
     }*/

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Debug.Log("entered");
            rb.isKinematic = false;
        }
    }


}
