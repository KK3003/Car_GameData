using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles coin behaviour when player interacts with coin
/// </summary>



public class CoinCtrl : MonoBehaviour
{
    public enum CoinFX
    {
        Vanish,
        Fly
    }

    public CoinFX coinFX;
    public static CoinCtrl instance;
    


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (coinFX == CoinFX.Vanish)
            {
                SFXCtrl.instance.ShowCoinSparkle(other.gameObject.transform.position);
                GameCtrl.instance.UpdateCoinCount();
                Debug.Log("COIN");
                Destroy(gameObject);
            }
        }
    }
}
