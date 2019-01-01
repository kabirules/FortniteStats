using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BestHTTP;
using System;
using m = Model;
using LitJson;

public class FortniteStoreItemsManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
	}

}
