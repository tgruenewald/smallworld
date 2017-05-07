using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSizeManager : MonoBehaviour
{
    private static float growsp = .0025f;
    private static float grvgrow = 10f;
    private bool shouldShrink = false;
	private static Vector3 DefaultSizeScaleVector = new Vector3(0.0f, 0.0f, 0.0f);
    private readonly Vector3 GrowthSize = new Vector3(growsp, growsp, 0.0f);
    public Transform SizeTransform = null;
    private float scalePercentage = 1.0f;
    public float ScalePercentage { get { return scalePercentage; } }

    // Use this for initialization
    void Start()
    {
		if (DefaultSizeScaleVector.x == 0.0f) {
			Debug.Log ("Should get called once");
			DefaultSizeScaleVector = this.transform.parent.gameObject.transform.localScale;
		}
		Debug.Log ("Starting planet:  " + this.transform.parent.name);
        //SizeTransform = GetComponentInParent<Transform>();
//        SizeTransform = this.transform.parent.gameObject.transform;
		SizeTransform = this.transform.parent.gameObject.transform;
		if (!GameState.planetSizeDict.ContainsKey (this.transform.parent.name)) {
			// then save the current size
			GameState.planetSizeDict.Add (this.transform.parent.name, new Vector3 (SizeTransform.localScale.x, SizeTransform.localScale.y, SizeTransform.localScale.z));
		} else {
			// then get the last planet scale.
			SizeTransform.localScale = GameState.planetSizeDict [this.transform.parent.name];
			Debug.Log ("Restoring size to  planet:  " + this.transform.parent.name + ": " + SizeTransform.localScale);
		}

		if (!GameState.planetScaleDict.ContainsKey (this.transform.parent.name)) {
			// then save the current size
			GameState.planetScaleDict.Add (this.transform.parent.name, scalePercentage);
		} else {
			// then get the last planet scale.
			scalePercentage = GameState.planetScaleDict [this.transform.parent.name];
			Debug.Log ("Restoring scalePercentage to  planet:  " + this.transform.parent.name + ": " + scalePercentage);
		}

        //GravityEffector = GetComponent<PointEffector2D>();
        //DefaultSizeScaleVector = SizeTransform.localScale;
    }
    void OnTriggerEnter2D(Collider2D Testy)
    {
        if (Testy.gameObject.tag != "Player")
            return;
        shouldShrink = true;
    }

    void OnTriggerExit2D(Collider2D Testy)
    {
        if (Testy.gameObject.tag != "Player")
            return;
        shouldShrink = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (shouldShrink)
        {
			if (SizeTransform.localScale.x > 1.5) {
				SizeTransform.localScale -= GrowthSize;
				GameState.planetSizeDict[this.transform.parent.name] = SizeTransform.localScale;
				//Debug.Log ("planet size " + SizeTransform.localScale);				
			}

            //if (PlanetGravity != null)
            //    PlanetGravity.GravityEffector.forceMagnitude -= grvgrow;
            //GravityEffector.forceMagnitude -= grvgrow;
        }
        else if (SizeTransform.localScale != DefaultSizeScaleVector)
        {
            Vector3 distanceToNormalSize = DefaultSizeScaleVector - SizeTransform.localScale;
            Vector3 moveDistance = new Vector3(Mathf.Min(GrowthSize.x, distanceToNormalSize.x), Mathf.Min(GrowthSize.y, distanceToNormalSize.y), 0.0f);
            SizeTransform.localScale += moveDistance;
            //if (PlanetGravity != null)
            //    PlanetGravity.GravityEffector.forceMagnitude += grvgrow;
            //GravityEffector.forceMagnitude += grvgrow;
        }
        scalePercentage = SizeTransform.localScale.x / DefaultSizeScaleVector.x; //x or y, it shouldn't matter
		GameState.planetScaleDict[this.transform.parent.name] = scalePercentage;
    }
}
