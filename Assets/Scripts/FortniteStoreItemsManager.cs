using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BestHTTP;
using System;
using m = Model;
using LitJson;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class FortniteStoreItemsManager : MonoBehaviour {

	private Int32 MAX_ITEMS = 8;
	public RawImage rawImage1;
	public RawImage rawImage2;
	public RawImage rawImage3;
	public RawImage rawImage4;
	public RawImage rawImage5;
	public RawImage rawImage6;
	public RawImage rawImage7;
	public RawImage rawImage8;
	private List<RawImage> rawImagesArray = new List<RawImage>();

	public Text text1;
	public Text text2;
	public Text text3;
	public Text text4;
	public Text text5;
	public Text text6;
	public Text text7;
	public Text text8;
	private List<Text> textsArray = new List<Text>();

	private List<m.Items> itemsArray = new List<m.Items>();


	// Use this for initialization
	void Start () {
		rawImage1.color = Color.black;
		rawImage2.color = Color.black;
		rawImage3.color = Color.black;
		rawImage4.color = Color.black;
		rawImage5.color = Color.black;
		rawImage6.color = Color.black;
		rawImage7.color = Color.black;
		rawImage8.color = Color.black;
		rawImagesArray.Add(rawImage1);
		rawImagesArray.Add(rawImage2);
		rawImagesArray.Add(rawImage3);
		rawImagesArray.Add(rawImage4);
		rawImagesArray.Add(rawImage5);
		rawImagesArray.Add(rawImage6);
		rawImagesArray.Add(rawImage7);
		rawImagesArray.Add(rawImage8);
		textsArray.Add(text1);
		textsArray.Add(text2);
		textsArray.Add(text3);
		textsArray.Add(text4);
		textsArray.Add(text5);
		textsArray.Add(text6);
		textsArray.Add(text7);
		textsArray.Add(text8);
		this.GetStoreItems();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetStoreItems() {
		string sceneName = SceneManager.GetActiveScene().name;
		string url = "https://fortnite-public-api.theapinetwork.com/prod09/";
		// Call different url's depending on scene
		if (sceneName == "StoreItems") {
			url = url + "store/get";
		} else { // "UpcomingItems"
			url = url + "upcoming/get";
		}
		HTTPRequest request = new HTTPRequest (new Uri (url), OnRequestGetStoreItemsFinished);
		request.Send ();
	}

	void OnRequestGetStoreItemsFinished(HTTPRequest request, HTTPResponse response)
	{
		m.StoreItems storeItemsResponse = JsonMapper.ToObject<m.StoreItems>(response.DataAsText);
		Debug.Log(storeItemsResponse.date);
		Debug.Log(storeItemsResponse.items[0].item.image);
		Debug.Log(storeItemsResponse.items.Length);
		for (int i=0; i < storeItemsResponse.items.Length && i < MAX_ITEMS; i++) {
			itemsArray.Add(storeItemsResponse.items[i]);
			StartCoroutine(setImage(storeItemsResponse.items[i].item.image, rawImagesArray[i]));
			textsArray[i].text = storeItemsResponse.items[i].name;
		}
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

	public void AssignItem(Int32 itemNumber) {
		PlayerPrefs.SetString("ITEM_NAME", itemsArray[itemNumber].name);
		PlayerPrefs.SetString("ITEM_URL", itemsArray[itemNumber].item.image);
		PlayerPrefs.SetString("COST", itemsArray[itemNumber].cost);
		PlayerPrefs.SetString("TYPE", itemsArray[itemNumber].item.type);
		PlayerPrefs.SetString("RARITY", itemsArray[itemNumber].item.rarity);
		SceneManager.LoadScene("Item");
		Debug.Log(itemsArray[itemNumber].name);
	}	

}
