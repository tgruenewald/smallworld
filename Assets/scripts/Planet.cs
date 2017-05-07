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
    public AlienPickup.AlienBodyPartType AlienBodyPart;
    public Sprite DeadSprite;

    private SpriteRenderer ourSpriteRenderer;

    // Use this for initialization
    void Start()
    {
        PlanetGravity = GetComponentInChildren<PlanetGravity>();
        PlanetSizeManager = GetComponentInChildren<PlanetSizeManager>();
        ourSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        var player = GameState.GetPlayer();
        if(player != null && ourSpriteRenderer != null)
        {
			if(player.GetAlienBodyParts() != null && player.GetAlienBodyParts().Contains(AlienBodyPart) && ourSpriteRenderer.sprite != DeadSprite)
            {
                ourSpriteRenderer.sprite = DeadSprite;
            }
        }
		//if (GameState.rightLeg) {
		//	planet2.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("sprites/bgs/deadplanet2");
		//}
		//if (GameState.leftLeg) {
		//	planet1.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("sprites/bgs/deadplanet1");
		//}
		//if (GameState.head) {
		//	planet3.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("sprites/bgs/deadplanet3");
		//}
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
            else 
                return PlanetSizeEnum.S;
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
