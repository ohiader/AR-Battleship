using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLoader : MonoBehaviour {

	public static GameObject GameManager;
	public static GameObject EnemyManager;
	public static GameObject Music;
	public GameObject dashboard;

	void Awake () {
		if (enemyManager.instance != null) {
			GameManager.transform.GetChild (1).gameObject.SetActive (false);
			GameManager.transform.GetChild (0).gameObject.SetActive (true);
		} else {
			if (gameManager.instance == null) {
				Debug.Log ("Made Game Manager");
				GameManager = (GameObject)Instantiate (Resources.Load ("ImageTarget"));
				GameManager.SetActive (true);
				GameManager.transform.GetChild (1).gameObject.SetActive (false);
			}
		}
		GameManager.transform.GetChild (1).gameObject.SetActive (false); // hide enemy board
		GameManager.transform.GetChild (0).gameObject.SetActive (true); // show player board

		if (GameObject.Find ("Stage").GetComponent<MeshRenderer> () == null) {
			GameObject.Find ("Stage").GetComponent<MeshRenderer> ().gameObject.SetActive (true);
		}

		if (ToggleSettings.scaleToggle) {
			GameManager.transform.GetChild (2).gameObject.transform.localScale = new Vector3 (1.1f * 3.0f, 0.2f, 1.1f * 3.0f);
		}

		if (SceneManager.GetActiveScene ().name == "enemyBoard") {
			if (ToggleSettings.UiToggle) {
				dashboard = GameObject.Find ("Dashboard");
				dashboard.SetActive (true);
			} else if (!ToggleSettings.UiToggle) {
				dashboard = GameObject.Find ("Dashboard");
				dashboard.SetActive (false);
			}
		}
	}

	public void LoadMenuScene()
	{
		Destroy(Music);
		//Destroy(Loader.GameManager);
		SceneManager.LoadScene("Menu");
	}
}
