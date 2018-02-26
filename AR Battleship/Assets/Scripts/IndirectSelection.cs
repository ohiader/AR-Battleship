using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IndirectSelection : MonoBehaviour {

	public static GameObject target = null;

	GameObject selected = null;
	GameObject player1 = null;
	GameObject old = null;

	public Material inactive = null;
	public Material active = null;
	public Material miss = null;
	public Material boom = null;

	public static bool chosenSpot = false;

	void Update () {
		if (!ToggleSettings.selectionToggle || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("placeShips") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("playerBoard")) {
			return;
		}

		RaycastHit hit;

		Vector3 forward = transform.TransformDirection (Vector3.forward) * 30;
		Debug.DrawRay (transform.position, forward, Color.green);

		if (Physics.Raycast (transform.position, (forward), out hit)) {
			Debug.Log (hit.collider.gameObject.name);
			if (hit.collider.gameObject.name.Contains ("gridPoint")) {
				selected = hit.collider.gameObject;
				if (old == null) {
					old = selected;
				}
				if (selected != old) {
					//Debug.Log ("AAAAAAAAA");
					if (!old.GetComponent<Renderer> ().material.name.Contains("miss") && !old.GetComponent<Renderer> ().material.name.Contains ("hit")) {
						old.GetComponent<Renderer> ().material = inactive;
					}
					if (!selected.GetComponent<Renderer> ().material.name.Contains("miss") && !selected.GetComponent<Renderer> ().material.name.Contains ("hit")) {
						selected.GetComponent<Renderer> ().material = active;
					}

					old = selected;
				}
				print(gameObject.name);
				for (int i = 0; i < 10; i++) {
					for (int j = 0; j < 10; j++) 
					{
						player1 = enemyManager.enemyBoard[i, j];
						if (selected.name.Equals(player1.name)) {
							Debug.Log ("here");
								//enemyManager.flag = true;
								chosenSpot = true;
								enemyManager.enemyBoard[i, j].GetComponent<Renderer>().material = active;
								target = enemyManager.enemyBoard [i, j];
								Debug.Log ("Targeted: " + target.name);

							if (selected.GetComponent<Renderer>().material.name.Contains("miss")) { // if (gameObject.GetComponent<Renderer>().material.Equals(active)) 
								//enemyManager.flag = false;
								enemyManager.enemyBoard[i, j].GetComponent<Renderer> ().material = miss;
								Debug.Log ("here2");

							}
							else if (selected.GetComponent<Renderer>().material.name.Contains ("hit")) { // if (gameObject.GetComponent<Renderer>().material.Equals(active)) 
								//enemyManager.flag = false;
								enemyManager.enemyBoard[i, j].GetComponent<Renderer> ().material = boom;
								Debug.Log ("here3");

							}

							/*if (enemyManager.flag == true) {
								if (selected.GetComponent<Renderer>().material.name.Contains("miss"))  {
									enemyManager.enemyBoard[i, j].GetComponent<Renderer> ().material = miss;
								} else if (selected.GetComponent<Renderer>().material.name.Contains("hit"))  {
									enemyManager.enemyBoard[i, j].GetComponent<Renderer> ().material = boom;
								} else {
									enemyManager.enemyBoard[i, j].GetComponent<Renderer> ().material = inactive;
								}
							} else { // if 
								//The "inactive" material (or grid material) just needs to have the same name as this
								if (selected.GetComponent<Renderer>().material.name.Contains("grid")) {
									enemyManager.flag = true;
									chosenSpot = true;
									enemyManager.enemyBoard[i, j].GetComponent<Renderer>().material = active;
									targetedShip = enemyManager.enemyBoard [i, j];

								} else if (selected.GetComponent<Renderer>().material.name.Contains("miss")) { // if (gameObject.GetComponent<Renderer>().material.Equals(active)) 
									enemyManager.flag = false;
									enemyManager.enemyBoard[i, j].GetComponent<Renderer> ().material = miss;
								}
								else if (selected.GetComponent<Renderer>().material.name.Contains ("hit")) { // if (gameObject.GetComponent<Renderer>().material.Equals(active)) 
									enemyManager.flag = false;
									enemyManager.enemyBoard[i, j].GetComponent<Renderer> ().material = boom;
								}
							}*/
						}
					}
				}
			}
		}
	}
}
