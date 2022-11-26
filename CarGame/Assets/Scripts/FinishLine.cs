using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject player;
    Rigidbody rg;

    private void Start()
    {
        rg = player.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            rg.velocity = Vector3.zero;
            rg.Sleep();
            Invoke("ShowLevelCompleteMenu", 1f);
        }
    }

    void ShowLevelCompleteMenu()
    {
        Debug.Log("Complete");
        GameCtrl.instance.LevelComplete();
    }
}
