using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // To load scene specified in the string
    public void LoadScene(string sceneName)
    {
       
       SceneManager.LoadScene(sceneName);
    }


    // To load the current scene
    public void LoadCurrentScene()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void  setLives3()
    {
        GameDataSO.instance.gameData.lives = 3;
    }
}
