using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public static class GameState
{
    private static GameObject player = null;
    public static GameObject introMusic = null;
	private static Transform planetSize = null;
	public static Vector3 planet1;
	public static Vector3 planet2;
	public static Vector3 planet3;
	public static Dictionary<string, Valve> gameDict = new Dictionary<string, Valve> ();
	public static bool rightLeg = false;
	public static bool leftLeg = false;
	public static bool head = false;




	public static void SetPlayer(GameObject player){
		GameState.player = player;
	}



	public static Player GetPlayer(){
		if(player == null){
			Debug.Log ("Player is null in GetPlayer");
			player = GameObject.FindGameObjectWithTag("Player");

			if (player == null) {
				Debug.Log ("Player is STILL null in GetPlayer");
				return null;
			}
				
		}

		return player.GetComponent<Player>();
	}
}


