using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_grow : MonoBehaviour {
	float growsp = .01f;
	float grvgrow = 10f;
	//float kilsp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var size = GetComponent<Transform>();
		var grav = GetComponent<PointEffector2D>();
		if (Input.GetKey (KeyCode.G)) 
		{
			size.localScale = new Vector2 (size.localScale.x + growsp, size.localScale.y + growsp);
			grav.forceMagnitude -= grvgrow;
		}
		if (Input.GetKey (KeyCode.F)) 
		{
			size.localScale = new Vector2 (size.localScale.x - growsp, size.localScale.y - growsp);
			grav.forceMagnitude += grvgrow;
		}

	}
}
