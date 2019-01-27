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
			if (SceneManager.GetActiveScene().name == "StoreItems") {
				SceneManager.LoadScene("Stats");
			} else if (SceneManager.GetActiveScene().name == "UpcomingItems") {
				SceneManager.LoadScene("Stats");
			} else {
				Application.Quit();
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
