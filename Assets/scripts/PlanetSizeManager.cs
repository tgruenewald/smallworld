using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSizeManager : MonoBehaviour
{
    private static float growsp = .0025f;
    private static float grvgrow = 10f;
    private bool shouldShrink = false;
    private Vector3 DefaultSizeScaleVector = new Vector3(1.0f, 1.0f, 1.0f);
    private readonly Vector3 GrowthSize = new Vector3(growsp, growsp, 0.0f);
    public Transform SizeTransform = null;
    private float scalePercentage = 1.0f;
    public float ScalePercentage { get { return scalePercentage; } }

    // Use this for initialization
    void Start()
    {
        //SizeTransform = GetComponentInParent<Transform>();
        SizeTransform = this.transform.parent.gameObject.transform;
        //GravityEffector = GetComponent<PointEffector2D>();
        DefaultSizeScaleVector = SizeTransform.localScale;
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
            SizeTransform.localScale -= GrowthSize;
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
    }
}
