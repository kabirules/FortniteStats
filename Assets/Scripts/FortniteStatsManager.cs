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

	public Text kills_solo;
	public Text matchesplayed_solo;
	public Text winrate_solo;
	public Text score_solo;

	public Text kills_duo;
	public Text matchesplayed_duo;
	public Text winrate_duo;
	public Text score_duo;	

	public Text kills_squad;
	public Text matchesplayed_squad;
	public Text winrate_squad;
	public Text score_squad;		

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

		kills_solo.text = userStatsResponse.stats.kills_solo.ToString();
		matchesplayed_solo.text = userStatsResponse.stats.matchesplayed_solo.ToString();
		winrate_solo.text = userStatsResponse.stats.winrate_solo.ToString();
		score_solo.text = userStatsResponse.stats.score_solo.ToString();

		kills_duo.text = userStatsResponse.stats.kills_duo.ToString();
		matchesplayed_duo.text = userStatsResponse.stats.matchesplayed_duo.ToString();
		winrate_duo.text = userStatsResponse.stats.winrate_duo.ToString();
		score_duo.text = userStatsResponse.stats.score_duo.ToString();

		kills_squad.text = userStatsResponse.stats.kills_squad.ToString();
		matchesplayed_squad.text = userStatsResponse.stats.matchesplayed_squad.ToString();
		winrate_squad.text = userStatsResponse.stats.winrate_squad.ToString();
		score_squad.text = userStatsResponse.stats.score_squad.ToString();		
	}	
}
