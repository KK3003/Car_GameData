using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingCtrl : MonoBehaviour
{
    public string PlayStoreURL;
    public string PlayStoreAccount;

    public void GooglePlay()
    {
        Application.OpenURL(PlayStoreURL);
    }

    public void GooglePlayAccount()
    {
        Application.OpenURL(PlayStoreAccount);
    }
}
