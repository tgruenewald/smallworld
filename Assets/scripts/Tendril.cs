using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tendril : MonoBehaviour {

	public GameObject valve;
	bool hasExited = true;
	public Sprite highlight;
	Sprite old;
	float timeStamp = 0.0f;
	float coolDownPeriodInSeconds = 1.0f;
	// Use this for initialization
	void Start () {
//		hi = Resources.Load<Sprite>("valve_blue/tendril_blue_highlight");
		old = GetComponent<SpriteRenderer>().sprite;
		timeStamp = Time.time + coolDownPeriodInSeconds;
	}
	
	// Update is called once per frame
	void Update () {
		if (valve.GetComponent<Valve> ().isOpen) {
			GetComponent<SpriteRenderer> ().sprite = highlight;
		} else {
			GetComponent<SpriteRenderer> ().sprite = old;
		}
		
	}
	void OnTriggerEnter2D(Collider2D col){
		Debug.Log("entered");
		
		if (hasExited && timeStamp <= Time.time) {
			timeStamp = Time.time + coolDownPeriodInSeconds;

			//GetComponent<SpriteRenderer> ().sprite = highlight;
			valve.GetComponent<Valve> ().activate ();			
			hasExited = false;
		}

	}
	
	void OnTriggerExit2D(Collider2D col){
		Debug.Log("exited");
		GetComponent<SpriteRenderer> ().sprite = old;
//		Behaviour halo = (Behaviour) gameObject.GetComponent("Halo");
//		halo.enabled = false;
//		Animator animator = gameObject.GetComponent<Animator> ();
//		animator.SetBool("play", false);		
		hasExited = true;
	}	
}
