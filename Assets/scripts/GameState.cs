﻿using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public static class GameState
{
    private static GameObject player = null;
    public static GameObject introMusic = null;
	private static Transform planetSize = null;
	public static Dictionary<string, Vector3> planetSizeDict = new Dictionary<string, Vector3> ();
	public static Dictionary<string, float> planetScaleDict = new Dictionary<string, float> ();
	public static HashSet<string> valveList = new HashSet<string> ();
	public static HashSet<AlienPickup.AlienBodyPartType> alienBodyParts  = new HashSet<AlienPickup.AlienBodyPartType>();
	public static bool freeze = false;
	public static int jetBlasts = 7;


	public static void SetPlayer(GameObject player)
    {
		GameState.player = player;
	}

	public static Player GetPlayer()
    {
		if(player == null)
        {
			Debug.Log ("Player is null in GetPlayer");
			player = GameObject.FindGameObjectWithTag("Player");
			if (player == null)
            {
				Debug.Log ("Player is STILL null in GetPlayer");
				return null;
			}
				
		}
		return player.GetComponent<Player>();
	}
}


