using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tendril : MonoBehaviour {

	public GameObject valve;
	bool hasExited = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		Debug.Log("entered");
		
		if (hasExited) {
			Animator animator = gameObject.GetComponent<Animator> ();
			animator.SetBool("play", true);
			valve.GetComponent<Valve> ().activate ();			
			hasExited = false;
		}

	}
	
	void OnTriggerExit2D(Collider2D col){
		Debug.Log("exited");
		Animator animator = gameObject.GetComponent<Animator> ();
		animator.SetBool("play", false);		
		hasExited = true;
	}	
}
