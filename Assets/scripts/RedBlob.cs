using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBlob : MonoBehaviour {

	public AlienLeftLeg rightLeg;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		GetComponent<SpriteRenderer> ().enabled = false;
		GetComponent<CapsuleCollider2D> ().enabled = false;
		rightLeg.GetComponent<SpriteRenderer> ().enabled = true;
		rightLeg.GetComponent<CapsuleCollider2D> ().enabled = true;
	}
}
