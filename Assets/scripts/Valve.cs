using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour {
	bool isOpen = false; // hi

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void activate() {
		Debug.Log ("VALVE IS ACTIVE");
		isOpen = !isOpen;
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer> ();
		Collider2D cir = gameObject.GetComponent<CapsuleCollider2D> ();
		Animator animator = gameObject.GetComponent<Animator> ();
		if (isOpen) {
			cir.enabled = false;
			animator.SetBool ("isOpen", true);
			Debug.Log ("opening.....");
		} else {
			cir.enabled = true;
			animator.SetBool ("isOpen", false);
			Debug.Log ("closeing.....");
		}
	}


}
