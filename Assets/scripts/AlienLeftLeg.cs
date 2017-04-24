using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienLeftLeg : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		GetComponent<SpriteRenderer> ().enabled = false;
		GetComponent<CapsuleCollider2D> ().enabled = false;
		GameState.leftLeg = true;

	}
}
