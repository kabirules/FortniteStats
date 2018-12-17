using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BestHTTP;
using System;
using m = Model;
using LitJson;

public class FortniteStatsManager : MonoBehaviour {

	public InputField userIDInputField;
	private string userId;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// GETUSERID
	public void GetUserId() {
		string url = "https://fortnite-public-api.theapinetwork.com/prod09/users/id?username=" + userIDInputField.text;
		HTTPRequest request = new HTTPRequest (new Uri (url), OnRequestGetUserIdFinished);
		request.Send ();
	}

	void OnRequestGetUserIdFinished(HTTPRequest request, HTTPResponse response)
	{
		m.UserId userIdResponse = JsonMapper.ToObject<m.UserId>(response.DataAsText);
		this.userId = userIdResponse.uid;
		Debug.Log(this.userId);
	}

	// GETSTATS
	public void GetStats() {
		string url = "https://fortnite-public-api.theapinetwork.com/prod09/users/public/br_stats?user_id=" + this.userId + "&platform=pc&window=alltime";
		HTTPRequest request = new HTTPRequest (new Uri (url), OnRequestGetStatsFinished);
		// request.SetHeader("Authorization","ea1e9f837f0a6b6679e4b90985cf5302");
		request.Send ();
	}

	void OnRequestGetStatsFinished(HTTPRequest request, HTTPResponse response)
	{
		m.UserStats userStatsResponse = JsonMapper.ToObject<m.UserStats>(response.DataAsText);
		Debug.Log(userStatsResponse.uid);
		Debug.Log(userStatsResponse.username);
		Debug.Log(userStatsResponse.stats.kills_solo);
		Debug.Log(userStatsResponse.totals.kills);
	}	
}
