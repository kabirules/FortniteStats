using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("escape")) {
			if (SceneManager.GetActiveScene().name == "Stats") {
				Application.Quit();
			} else {
				SceneManager.LoadScene("Stats");
			}
		}
	}

	public void OpenStats() {
		SceneManager.LoadScene("Stats");
	}

	public void OpenStoreItems() {
		SceneManager.LoadScene("StoreItems");
	}

	public void OpenUpcomingItems() {
		SceneManager.LoadScene("UpcomingItems");
	}		
}
