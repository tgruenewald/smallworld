using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HudDisplay : MonoBehaviour {
	GameObject leftLeg;
	GameObject rightLeg;
	GameObject head;
	GameObject jetBlastsText;
    private Player gamePlayer;
	// Use this for initialization
	void Start ()
    {
		jetBlastsText = GameObject.Find ("JetBlastsRemaining");
        gamePlayer = GameState.GetPlayer();
		rightLeg = GameObject.Find ("RightLegDisplay");
		leftLeg = GameObject.Find ("LeftLegDisplay");
		head = GameObject.Find ("HeadDisplay");
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (jetBlastsText != null) {
			jetBlastsText.GetComponent<Text> ().text = "" + GameState.jetBlasts;
		}
        if (gamePlayer == null)
            return;

		if (gamePlayer.GetAlienBodyParts().Contains(AlienPickup.AlienBodyPartType.LeftLeg))
        {
			leftLeg.GetComponent<Image> ().enabled = true;
		}
        if (gamePlayer.GetAlienBodyParts().Contains(AlienPickup.AlienBodyPartType.RightLeg))
        {
			rightLeg.GetComponent<Image> ().enabled = true;
		}
        if (gamePlayer.GetAlienBodyParts().Contains(AlienPickup.AlienBodyPartType.Head))
        {
			head.GetComponent<Image> ().enabled = true;
		}
	}

	public void click() {
		Debug.Log ("========================CLICKED BUTTON======================");
	}
}
