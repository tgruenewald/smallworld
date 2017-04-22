using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_movement : MonoBehaviour {
	public float speed;
	public float strength;
	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3 (0.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
//		float face = transform.rotation.z;
//		float x = transform.position.x;
//		float y = transform.position.y;
//		float direction = face + 90.0f;
//		if (Input.GetKey(KeyCode.D)) 
//		{
//			
//			float newX = x + direction * .001f;
//			transform.position = new Vector2 (newX, y);
//		}

		if (Input.GetKey(KeyCode.D)) 
		{
			transform.position += transform.right * speed;
//			var V =  GetComponent<Rigidbody2D>();
//			Vector3 direction = V.rotation * Vector3.right;
//			//var direction = transform.rotation;
//			//direction.z += 90;
//
//
//			//V.AddForce(V.rotation * 0.001f);
//
//			GetComponent<Rigidbody2D> ().AddForce (transform.forward * 25);
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			transform.position -= transform.right * speed;
		}
		if (Input.GetKey (KeyCode.W)) 
		{
			transform.position += transform.up * strength;
		}
	}
}
