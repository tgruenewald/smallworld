using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_grow : MonoBehaviour {
	private static float growsp = .01f;
	private static float grvgrow = 10f;
    private bool shouldShrink = false;
    private readonly Vector3 DefaultSizeVector = new Vector3(1.0f, 1.0f, 1.0f);
    private readonly Vector3 GrowthSize = new Vector3(growsp, growsp, 0.0f);
    private Transform SizeTransform = null;
    private PointEffector2D GravityEffector = null;

    // Use this for initialization
    void Start ()
    {
        SizeTransform = GetComponent<Transform>();
        GravityEffector = GetComponent<PointEffector2D>();
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
    void Update ()
    {
        if(shouldShrink)
        {
            SizeTransform.localScale -= GrowthSize;
            GravityEffector.forceMagnitude -= grvgrow;
        }
        else if (SizeTransform.localScale != DefaultSizeVector)
        {
            SizeTransform.localScale += GrowthSize;
            GravityEffector.forceMagnitude += grvgrow;
        }
    }

}
