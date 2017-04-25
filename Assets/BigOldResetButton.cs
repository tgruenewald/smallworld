using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BigOldResetButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void onClick() {
		Debug.Log ("============================================================");
		var otherPlayers = GameObject.FindObjectsOfType<Player>();
		Debug.Log(string.Format("Amount of player in scene: {0}", otherPlayers.Length));
		for(int i = 0; i < otherPlayers.Length; ++i)
		{
			var otherPlayer = otherPlayers[i];
			Destroy(otherPlayer.gameObject);
		}
		SceneManager.LoadScene("outer_space"); 		
	}
}
