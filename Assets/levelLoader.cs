﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	public static LevelLoader instance;

	// Use this for initialization
	void Awake () {
		if (instance != null && instance != this)
		{
			Destroy (gameObject);
			return; 
		}
		instance = this;
		DontDestroyOnLoad(gameObject);
	}
	
	public static void ResetLevel ()  
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
