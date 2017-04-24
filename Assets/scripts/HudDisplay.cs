using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HudDisplay : MonoBehaviour {
	GameObject leftLeg;
	GameObject rightLeg;
	GameObject head;
	// Use this for initialization
	void Start () {
		rightLeg = GameObject.Find ("RightLegDisplay");
		leftLeg = GameObject.Find ("LeftLegDisplay");
		head = GameObject.Find ("HeadDisplay");
	}
	
	// Update is called once per frame
	void Update () {
		if (GameState.leftLeg) {
			leftLeg.GetComponent<Image> ().enabled = true;
		}
		if (GameState.rightLeg) {
			rightLeg.GetComponent<Image> ().enabled = true;
		}
		if (GameState.head) {
			head.GetComponent<Image> ().enabled = true;
		}
	}
}
