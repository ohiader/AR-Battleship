﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaodMenuScene : MonoBehaviour {

	public void LoadMenuScene()
	{
		Destroy(Music.music);
		SceneManager.LoadScene ("Menu");
	}
	public void LoadGameScene()
	{
		SceneManager.LoadScene ("GameScene");
	}

	public void Start()
	{
	}
}
