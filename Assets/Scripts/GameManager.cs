using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }
	public string currentPlayer;
	public string playerName;
	public int playerScore;


	// Start is called before the first frame update
	private void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}
		
		Instance = this;
		DontDestroyOnLoad(gameObject);

		Load();
	}

	[Serializable]
	class SaveData
	{
		public string name;
		public int score;
	}

	public void Save()
	{
		SaveData data = new SaveData();
		data.name = currentPlayer;
		data.score = playerScore;

		string json = JsonUtility.ToJson(data);

		File.WriteAllText(Application.persistentDataPath + "savefile.json", json);
	}

	public void Load()
	{
		string path = Application.persistentDataPath + "savefile.json";

		if (File.Exists(path))
		{
			string json = File.ReadAllText(path);
			SaveData data = JsonUtility.FromJson<SaveData>(json);

			playerName = data.name;
			playerScore = data.score;
		}

		//Debug.Log(path);
	}
}
