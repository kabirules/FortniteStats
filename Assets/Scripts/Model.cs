using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Model : MonoBehaviour {

	public class UserId {
		public string uid { get; set; }
		public string username { get; set; }
		public string[] platforms { get; set; }
		public string[] seasons { get; set; }
		/*
		{
			"uid": "4735ce9132924caf8a5b17789b40f79c",
			"username": "Ninja",
			"platforms": [
				"pc"
			],
			"seasons": [
				"season7",
				"season6",
				"season5",
				"season4"
			]
		}
		*/
	}

	public class Stats {
		// SOLO STATS
		public Int32 kills_solo { get; set; }
		public Int32 matchesplayed_solo { get; set; }
		public Double winrate_solo { get; set; }
		public Int32 score_solo { get; set; }
		// DUO STATS
		public Int32 kills_duo { get; set; }
		public Int32 matchesplayed_duo { get; set; }
		public Double winrate_duo { get; set; }
		public Int32 score_duo { get; set; }
		// SQUAD STATS
		public Int32 kills_squad { get; set; }
		public Int32 matchesplayed_squad { get; set; }
		public Double winrate_squad { get; set; }
		public Int32 score_squad { get; set; }
	}

	public class Totals {
		public Int32 kills { get; set; }
		public Int32 matchesplayed { get; set; }
		public Double winrate { get; set; }
		public Int32 score { get; set; }
	}	

	public class UserStats {
		public string uid { get; set; }
		public string username { get; set; }
		public Stats stats { get; set; }
		public Totals totals { get; set; }
		/*
		{
			"cached": true,
			"uid": "4735ce9132924caf8a5b17789b40f79c",
			"username": "Ninja",
			"platform": "pc",
			"timestamp": 1544911933,
			"window": "alltime",
			"stats": {
				"kills_solo": 38494,
				"placetop1_solo": 1814,
				"placetop10_solo": 2458,
				"placetop25_solo": 2961,
				"matchesplayed_solo": 5225,
				"kd_solo": 11.29,
				"winrate_solo": 34.72,
				"score_solo": 1736401,
				"minutesplayed_solo": 24386,
				"lastmodified_solo": 1544899923,
				"kills_duo": 28747,
				"placetop1_duo": 1696,
				"placetop5_duo": 2082,
				"placetop12_duo": 2466,
				"matchesplayed_duo": 4128,
				"kd_duo": 11.82,
				"winrate_duo": 41.09,
				"score_duo": 1749293,
				"minutesplayed_duo": 17407,
				"lastmodified_duo": 1544900281,
				"kills_squad": 26019,
				"placetop1_squad": 1388,
				"placetop3_squad": 1667,
				"placetop6_squad": 1948,
				"matchesplayed_squad": 3948,
				"kd_squad": 10.16,
				"winrate_squad": 35.16,
				"score_squad": 1681113,
				"minutesplayed_squad": 8298,
				"lastmodified_squad": 1544910301
			},
			"totals": {
				"kills": 93260,
				"wins": 4898,
				"matchesplayed": 13301,
				"minutesplayed": 50091,
				"hoursplayed": 835,
				"score": 5166807,
				"winrate": 36.82,
				"kd": 11.1,
				"lastupdate": 1544899923
			}
		}		
		 */
	}

//////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////

	public class StoreItems {
		public string date_layout { get; set; }
		public string date { get; set; }
		public string vbucks { get; set; }
		public Items[] items  { get; set; }
	}

	public class Items {
		public string itemid { get; set; }
		public string name { get; set; }
		public string cost { get; set; }
		public Item item { get; set; }
	}

	public class Item {	
		public string image { get; set; }
		public string captial { get; set; }
		public string type { get; set; }
		public string rarity { get; set; }
	}
	/*
	{
		"date_layout": "day-month-year",
		"lastupdate": 1546301124,
		"language": "en",
		"date": "01-01-19",
		"rows": 10,
		"vbucks": "https://fortnite-public-files.theapinetwork.com/fortnite-vbucks-icon.png",
		"items": [
			{
				"itemid": "bac52c7-d6c39d5-ec60147-709d929",
				"name": "DJ Bop",
				"cost": "2000",
				"featured": 1,
				"refundable": 1,
				"lastupdate": 1546301124,
				"youtube": null,
				"item": {
					"image": "https://fortnite-public-files.theapinetwork.com/outfit/20ed4cc30bb4976f25cde8d0bc136288.png",
					"images": {
						"transparent": "https://fortnite-public-files.theapinetwork.com/outfit/20ed4cc30bb4976f25cde8d0bc136288.png",
						"background": "https://fortnite-public-files.theapinetwork.com/image/bac52c7-d6c39d5-ec60147-709d929.png",
						"information": "https://fortnite-public-files.theapinetwork.com/image/bac52c7-d6c39d5-ec60147-709d929/item.png",
						"featured": {
							"transparent": "https://fortnite-public-files.theapinetwork.com/featured/bac52c7-d6c39d5-ec60147-709d929.png"
						}
					},
					"captial": "outfit",
					"type": "outfit",
					"rarity": "legendary",
					"obtained_type": "vbucks"
				}
			},
		]
	}
	*/
}
