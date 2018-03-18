using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyLoader : MonoBehaviour {
	//public static GameObject EnemyManager;
	//public static GameObject GameManager;
	//public GameObject ImageTarget;


	// Use this for initialization
	void Awake () {
		if (gameManager.instance != null) {
			NewLoader.GameManager.transform.GetChild (1).gameObject.SetActive (true);
			NewLoader.GameManager.transform.GetChild (0).gameObject.SetActive (false);
		}else if (enemyManager.instance == null) {
				Debug.Log ("Made Enemy Manager");
				NewLoader.EnemyManager = (GameObject)Instantiate(Resources.Load("EnemyGameManager"));
				NewLoader.EnemyManager.SetActive (true);
			}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
