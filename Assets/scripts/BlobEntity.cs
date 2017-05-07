using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobEntity : MonoBehaviour
{

    public AlienPickup Target;
    // Use this for initialization
    void Start()
    {
		if (GameState.alienBodyParts.Contains (Target.AlienBodyPart)) {
			GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<CapsuleCollider2D>().enabled = false;			
		}
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        Target.GetComponent<SpriteRenderer>().enabled = true;
        Target.GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
