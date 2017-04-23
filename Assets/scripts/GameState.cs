using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public static class GameState
{
    private static GameObject player = null;
    public static GameObject introMusic = null;

	public static void SetPlayer(GameObject player){
		GameState.player = player;
	}

	public static Player GetPlayer(){
		if(player == null){
			player = GameObject.FindGameObjectWithTag("Player");
			if(player == null)
				return null;
		}

		return player.GetComponent<Player>();
	}
}


