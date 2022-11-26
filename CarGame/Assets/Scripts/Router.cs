using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Router : MonoBehaviour
{
    public void ShowPausePanel()
    {
        GameCtrl.instance.ShowPausePanel();
    }

    public void HidePausePanel()
    {
        GameCtrl.instance.HidePausePanel();
        
    }

    public void ToggleMusic()
    {
        AudioCtrl.instance.ToggleMusic();
    }

    
   public void HideInstructions()
   {
        GameCtrl.instance.instruction.SetActive(false);
   }
}
