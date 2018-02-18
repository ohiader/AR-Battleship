using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {
	public static GameObject GameManager;
	public static GameObject EnemyManager;
	public static GameObject Music;
	/*public static bool sceneFlag = true;*/
	//public GameObject ImageTarget;


	// Use this for initialization
	void Awake () {
			//if (sceneFlag) {
		if (enemyManager.instance != null) {
			GameManager.transform.GetChild (0).GetChild (1).gameObject.SetActive (false);
			GameManager.transform.GetChild (0).GetChild (0).gameObject.SetActive (true);
		} else {
			if (gameManager.instance == null) {
				Debug.Log ("Made Game Manager");
				GameManager = (GameObject)Instantiate (Resources.Load ("ARCamera-MasterClone"));
				GameManager.SetActive (true);
				GameManager.transform.GetChild (0).GetChild (1).gameObject.SetActive (false);
			}
		}
		GameManager.transform.GetChild (0).GetChild (1).gameObject.SetActive (false);
		GameManager.transform.GetChild (0).GetChild (0).gameObject.SetActive (true);
			
		if (ToggleSettings.scaleToggle) {
			GameManager.transform.GetChild (0).GetChild (2).gameObject.transform.localScale = new Vector3 (0.007727273f * 3.0f, 0.06181818f, 0.007727273f * 3.0f);
		}
		/*} else {
			if (enemyManager.instance == null) {
				Debug.Log("Made Enemy Manager");
				Instantiate (EnemyManager, new Vector3 ((float) 0.0, (float) 0.5, (float) 0.0), Quaternion.identity);
			}
		}*/
	}

	// Update is called once per frame
	void Update()
	{
		/*if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("placeShips")) {
			sceneFlag = true;
		} else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("enemyBoard")) {
			sceneFlag = false;
		} else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("playerBoard")) {
			sceneFlag = true;
		}*/
	}
	public void LoadMenuScene()
	{
		Destroy(Music);
		//Destroy(Loader.GameManager);
		Application.LoadLevel("Menu");
	}
}
