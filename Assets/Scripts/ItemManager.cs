using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour {

	// Use this for initialization
	public RawImage rawImage1;
	public Text text1;	
	public Text text2;
	public Text text3;
	public Text text4;
	void Start () {
		rawImage1.color = Color.black;
		string name = PlayerPrefs.GetString("ITEM_NAME");
		string image = PlayerPrefs.GetString("ITEM_URL");
		string cost = PlayerPrefs.GetString("COST");
		string type = PlayerPrefs.GetString("TYPE");
		string rarity = PlayerPrefs.GetString("RARITY");
		StartCoroutine(setImage(image, rawImage1));
		text1.text = name;
		text2.text = cost + " V-Bucks";
		text3.text = type;
		text4.text = rarity;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator setImage(string url, RawImage rawImage) {
		UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
		yield return request.SendWebRequest();
		if (request.isNetworkError || request.isHttpError) {
			Debug.Log(request.error);
		} else {
			rawImage.texture = ((DownloadHandlerTexture) request.downloadHandler).texture;
			rawImage.color = Color.white;
		}
	}	
}
