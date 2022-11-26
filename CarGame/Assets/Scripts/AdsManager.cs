using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class AdsManager : MonoBehaviour
{

    public static AdsManager instance = null;

    string GameID = "4511876";

   // bool testMode = true;    // false for actual game

    string VideoAdID = "Interstitial_Android";
    string BannerAdID = "Banner_Android";

    


    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        
        Advertisement.Initialize(GameID);
        StartCoroutine(ShowBannerAdWhenInitialized());

        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
    }

   public void DisplayVideoAds()
   {
     Advertisement.Show(VideoAdID);   
   }

    IEnumerator ShowBannerAdWhenInitialized()
    {
        while(!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);

        }
        Advertisement.Banner.Show(BannerAdID);
    }

}
