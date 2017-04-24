using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour {
	public bool isOpen = false; // hi
	public bool firstTime = true;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (firstTime) {
			firstTime = false;
			string id = gameObject.scene.name + gameObject.name;
			Debug.Log ("Valve:  " + id);
			if (GameState.gameDict.ContainsKey (id)) {
				Debug.Log ("=======Valve restoring gamestate");
				isOpen = GameState.gameDict [id].isOpen;
				perform_valve_action ();
			} else {
				Debug.Log ("Valve adding gamestate");
				GameState.gameDict.Add (id, this);
			}
		}

	}

	public void activate() {
		Debug.Log ("VALVE IS ACTIVE");

		isOpen = !isOpen;
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
