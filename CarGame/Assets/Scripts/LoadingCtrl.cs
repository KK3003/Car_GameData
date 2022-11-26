using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// shows loading screen
/// </summary>
public class LoadingCtrl : MonoBehaviour
{
    
    public static LoadingCtrl instance;
    public GameObject panelLoading;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ShowLoading()
    {
        panelLoading.SetActive(true);
    }
}
