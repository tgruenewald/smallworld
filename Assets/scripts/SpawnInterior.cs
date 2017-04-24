using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInterior : MonoBehaviour {

	public droplet player;
	// Use this for initialization
	void Start () {
		//GameObject rb = Instantiate (player, this.gameObject.transform.position, this.gameObject.transform.rotation);
		player.SpawnAt (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
