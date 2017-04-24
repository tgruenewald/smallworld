using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public static class GameState
{
    private static GameObject player = null;
    public static GameObject introMusic = null;
	private static Transform planetSize = null;
	public static Planet planet1 = null;
	public static Planet planet2 = null;
	public static Planet planet3 = null;


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


