using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class UI : MonoBehaviour
{

    [Header("Text")]
    public Text txtTimer;
    public Image heart1;         // represents onw player life
    public Image heart2;         // represents onw player life
    public Image heart3;         // represents onw player life
    public Sprite emptyheart;   // shows when player lost life
    public Sprite fullHeart;    // shown when full lives


    [Header("Popup Menus")]
    public GameObject panelGameOver;
    public GameObject levelCompleteMenu;
    public GameObject panelPause;
    public GameObject panelMobileUI;



}
