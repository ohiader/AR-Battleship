using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpWindow : MonoBehaviour {

	public GameObject window;
	public Text messageField;

	public void Show()
	{
	//	messageField.text = message;
		window.SetActive (true);
	}

	public void Level(string level)
	{
		Application.LoadLevel(level);
	}

	public void Hide(){
		window.SetActive (false);
	}
}
