using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/// <summary>
/// A Singleton class for creating a persistent DataCtrl gameobject
/// and helps in creating centralized database access code
/// </summary>
public class DataCtrl : MonoBehaviour
{
    public static DataCtrl instance = null;
    public GameData data;      // for accessing gamedata
    public bool devMode;

    string dataFilePath;        // path where data file is stored
    BinaryFormatter bf;         // helps save/load data in binary files


    

   

   


    public bool isUnlocked(int levelNumber)
    {
        //return data.levelData[levelNumber].isUnlocked;
        return GameDataSO.instance.gameData.levelData[levelNumber].isUnlocked;
    }

    public int getStars(int levelNumber)
    {
        // return data.levelData[levelNumber].starsAwarded;
        return GameDataSO.instance.gameData.levelData[levelNumber].starsAwarded;

    }

  
      

   

}
