using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAD : MonoBehaviour
{
   public void showAd()
    {
        AdsManager.instance.DisplayVideoAds();
    }
}
