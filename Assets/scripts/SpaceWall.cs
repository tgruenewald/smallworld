using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpaceWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
        //Debug.Log(string.Format("{0} touched space wall {1}", coll.gameObject.name, this.name));
        if (coll.gameObject.tag != "Player")
            return;
		BigOldResetButton.Reset ();
	}
}
