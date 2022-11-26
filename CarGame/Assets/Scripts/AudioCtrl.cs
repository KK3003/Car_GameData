using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioCtrl : MonoBehaviour
{
    public static AudioCtrl instance;

    public Sprite imgMusicOn, imgMusicOff;
  
    public GameObject btnMusic;

    
    public GameObject BGMusic;

    public bool soundOn;
    public bool bgMusicOn;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            
        }

       if(GameDataSO.instance.gameData.playMusic)
        {
            BGMusic.SetActive(true);

            btnMusic.GetComponent<Image>().sprite = imgMusicOn;
        }
       else
        {
            BGMusic.SetActive(false);

            btnMusic.GetComponent<Image>().sprite = imgMusicOff;
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMusic()
    {
        if(GameDataSO.instance.gameData.playMusic)
        {
            BGMusic.SetActive(false);

            btnMusic.GetComponent<Image>().sprite = imgMusicOff;

            GameDataSO.instance.gameData.playMusic = false;

        }
        else
        {
            BGMusic.SetActive(true);

            btnMusic.GetComponent<Image>().sprite = imgMusicOn;

            GameDataSO.instance.gameData.playMusic = true;
        }
    }

    
}
