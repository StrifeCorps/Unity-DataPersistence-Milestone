using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }
	public string name;

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
	}

	class SaveData
	{
		
	}

	public void Save()
	{

	}

	public void Load()
	{

	}
}
