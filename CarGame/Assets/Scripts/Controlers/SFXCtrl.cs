using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Handles the Particle effects and other special effects for the game
/// </summary>

public class SFXCtrl : MonoBehaviour
{
    public static SFXCtrl instance; // allows to acces meyhods from this class without creating object
    public SFX sfx;


    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// shows the coin sparckle effect
    /// </summary>
    /// <param name="pos"></param>
    public void ShowCoinSparkle(Vector3 pos)
    {
        Instantiate(sfx.sfx_coin_pickup, pos, Quaternion.identity);
    }
}
