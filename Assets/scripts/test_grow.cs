using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_grow : MonoBehaviour {
	float growsp = .01f;
	float grvgrow = 10f;
	//GameObject trig = GameObject.Find("Testy");
	//float kilsp;

	// Use this for initialization
	void Start () {

	}
	void OnTriggerEnter2D(Collider2D Testy)
	{ 
		if (Testy.gameObject.tag != "player") 
		{
			return;
		}
		Debug.Log ("hi");
		var size = GetComponent<Transform>();
		var grav = GetComponent<PointEffector2D>();
		size.localScale = new Vector2 (size.localScale.x + growsp, size.localScale.y + growsp);
		grav.forceMagnitude -= grvgrow;
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
