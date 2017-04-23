using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour {

	public Animator animator;
	bool isOpen = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void activate() {
		isOpen = !isOpen;
		if (isOpen) {
			SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer> ();
			sr.sprite = Resources.Load<Sprite> ("open_valve.png");
		} else {
			SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer> ();
			sr.sprite = Resources.Load<Sprite> ("close_valve.png");			
		}
	}

	public Animator getAnimation() {
		return animator;
	}
}
