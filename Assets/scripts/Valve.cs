using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour {
	bool isOpen = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void activate() {
		isOpen = !isOpen;
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer> ();
		CircleCollider2D cir = gameObject.GetComponent<CircleCollider2D> ();
		Animator animator = gameObject.GetComponent<Animator> ();
		if (isOpen) {
			sr.sprite = Resources.Load<Sprite> ("valve/open_valve");
			cir.enabled = false;
			animator.SetBool ("isOpen", true);
		} else {
			sr.sprite = Resources.Load<Sprite> ("valve/close_valve");			
			cir.enabled = true;
			animator.SetBool ("isOpen", false);
		}
	}


}
