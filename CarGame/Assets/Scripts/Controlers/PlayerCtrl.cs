using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCtrl : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject ui;
    public bool SFXOn;
    //public GameCtrl gamectrl;


  


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void OnCollisionEnter(Collision other)
    {
        // To detect collision between player and Rock
        if (other.gameObject.CompareTag("Rock"))
        {
            // Here we will add dead explosion and sound
           
            Debug.Log("Player Died");
            
            GameCtrl.instance.PlayerDied(gameObject);  //  player died  fuction
            rb.velocity = Vector3.zero;

            // ui.SetActive(true);
            //gameObject.SetActive(false);

            

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Smoke"))
        {
            Debug.Log("Player Died");
            GameCtrl.instance.PlayerDied(gameObject);

            //rb.velocity = Vector3.zero;
            // ui.SetActive(true);
            Debug.Log("Smoke");
        } 
    }

    
   



}
