using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    public PointEffector2D GravityEffector;
    private float initialForce;
    public float ForceScale
    {
        get { return initialForce / GravityEffector.forceMagnitude; }
        set
        {
            GravityEffector.forceMagnitude = initialForce * value;
        }
    }
	// Use this for initialization
	void Start ()
    {
        GravityEffector = GetComponent<PointEffector2D>();
        initialForce = GravityEffector.forceMagnitude;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
