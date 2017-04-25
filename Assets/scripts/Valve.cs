using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour {
	public bool isOpen = false; // hi
	string id;
	// Use this for initialization
	void Start () {
		id = gameObject.scene.name + gameObject.name;
		if (GameState.valveList.Contains (id)) {
			isOpen = true;
		} else {
			isOpen = false;
		}
		perform_valve_action ();

	}

	// Update is called once per frame
	void Update () {

	}

	public void activate() {
		Debug.Log ("VALVE IS ACTIVE");

		isOpen = !isOpen;
		if (isOpen) {
			GameState.valveList.Add (id);
		} else {
			GameState.valveList.Remove (id);
		}
		perform_valve_action ();
	}
	private void perform_valve_action() {
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
