using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienPickup : MonoBehaviour
{
    public enum AlienBodyPartType
    {
        LeftLeg,
        RightLeg,
        Head,
		None
    };

    public AlienBodyPartType AlienBodyPart;

	// Use this for initialization
	void Start ()
    {
		if (GameState.alienBodyParts.Contains (AlienBodyPart)) {
			GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<CapsuleCollider2D>().enabled = false;			
		}
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GameState.GetPlayer().PickedUpAlienBodyPart(this.AlienBodyPart);
    }

    public void Activate()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
