using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Data")]
public class GameDataSO : ScriptableObject
{
	public GameData gameData;
	public static GameDataSO instance;

    private void OnEnable()
    {
		instance = this;
        LoadData();
    }

    private void OnDisable()
    {
        SaveData();
    }

	public void LoadData()
	{
		if (File.Exists(Application.persistentDataPath + "/GameData.dat"))
		{
			try
			{
				BinaryFormatter bf = new BinaryFormatter();
				FileStream file = File.Open(Application.persistentDataPath + "/GameData.dat", FileMode.Open);
				if (file.Length == 0)
					return;
				gameData = (GameData)bf.Deserialize(file);
				file.Close();
			}
			catch (Exception e)
			{
				Debug.Log("Game Data load exception " + e);
			}
		}
	}

	public void SaveData()
	{
		try
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create(Application.persistentDataPath + "/GameData.dat");
			if (gameData == null)
				return;
			bf.Serialize(file, gameData);
			file.Close();
		}
		catch (Exception e)
		{

			Debug.Log("Game Data Save exception " + e);
		}

	}
}
