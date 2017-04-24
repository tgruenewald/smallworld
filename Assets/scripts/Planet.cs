using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public enum PlanetSizeEnum
    {
        XS = 0,
        S = 1,
        M = 2,
        L = 3
    };
    //private PointEffector2D GravityEffector = null;
    public PlanetGravity PlanetGravity;
    public PlanetSizeManager PlanetSizeManager;
	GameObject planet1;
	GameObject planet2;
	GameObject planet3;

    // Use this for initialization
    void Start()
    {
        PlanetGravity = GetComponentInChildren<PlanetGravity>();
        PlanetSizeManager = GetComponentInChildren<PlanetSizeManager>();
		planet1 = GameObject.Find ("planet1");
		planet2 = GameObject.Find ("planet2");
		planet3 = GameObject.Find ("planet3");

    }
    
    // Update is called once per frame
    void Update()
    {
		if (GameState.rightLeg) {
			planet2.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("sprites/bgs/deadplanet2");
		}
		if (GameState.leftLeg) {
			planet1.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("sprites/bgs/deadplanet1");
		}
		if (GameState.head) {
			planet3.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("sprites/bgs/deadplanet3");
		}
        Player currentPlayer = GameState.GetPlayer();
        if(currentPlayer != null && PlanetGravity != null)
        {
            PlanetGravity.GravityEffector.enabled = (currentPlayer.CurrentPlanet == this.gameObject || currentPlayer.IsGrounded == false);
        }

        if(PlanetGravity != null && PlanetSizeManager != null)
        {
            PlanetGravity.ForceScale = PlanetSizeManager.ScalePercentage;
        }
    }

    public PlanetSizeEnum PlanetSize
    {
        get
        {
            float scale = PlanetSizeManager.ScalePercentage;
            if (scale >= 0.75f)
                return PlanetSizeEnum.L;
            else if (scale < 0.75f && scale >= 0.5f)
                return PlanetSizeEnum.M;
            else if (scale < 0.5f && scale >= 0.25f)
                return PlanetSizeEnum.S;
            else
                return PlanetSizeEnum.XS;
        }
    }

	public string getPlanetSizeText() {
		if (PlanetSizeManager == null) {
			return "";
		}
		switch (this.PlanetSize) {
		case PlanetSizeEnum.L:
			return "L";
		case PlanetSizeEnum.M:
			return "M";
		case PlanetSizeEnum.S:
			return "S";
		case PlanetSizeEnum.XS:
			return "XS";

		}
		return "";
	}
}
