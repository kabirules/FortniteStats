using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BestHTTP;
using System;
using m = Model;
using LitJson;
using UnityEngine.Networking;

public class FortniteStoreItemsManager : MonoBehaviour {

	public RawImage rawImage1;
	public RawImage rawImage2;
	public RawImage rawImage3;

	// Use this for initialization
	void Start () {
		rawImage1.color = Color.black;
		rawImage2.color = Color.black;
		rawImage3.color = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetStoreItems() {
		string url = "https://fortnite-public-api.theapinetwork.com/prod09/store/get";
		HTTPRequest request = new HTTPRequest (new Uri (url), OnRequestGetStoreItemsFinished);
		request.Send ();
	}

	void OnRequestGetStoreItemsFinished(HTTPRequest request, HTTPResponse response)
	{
		m.StoreItems storeItemsResponse = JsonMapper.ToObject<m.StoreItems>(response.DataAsText);
		Debug.Log(storeItemsResponse.date);
		Debug.Log(storeItemsResponse.items[0].item.image);
		Debug.Log(storeItemsResponse.items.Length);
		StartCoroutine(setImage(storeItemsResponse.items[0].item.image, rawImage1));
		StartCoroutine(setImage(storeItemsResponse.items[1].item.image, rawImage2));
		StartCoroutine(setImage(storeItemsResponse.items[2].item.image, rawImage3));
	}

	IEnumerator setImage(string url, RawImage rawImage) {
		UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
		yield return request.SendWebRequest();
		if (request.isNetworkError || request.isHttpError) 
			Debug.Log(request.error);
		else
			rawImage.texture = ((DownloadHandlerTexture) request.downloadHandler).texture;
			rawImage.color = Color.white;
		}	

}
