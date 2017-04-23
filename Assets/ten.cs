using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ten : MonoBehaviour {

	public GameObject val;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("entering tendril trigger");
		val.GetComponent<val> ().activate ();


	}
}
