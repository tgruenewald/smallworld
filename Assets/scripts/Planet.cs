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

    // Use this for initialization
    void Start()
    {
        PlanetGravity = GetComponentInChildren<PlanetGravity>();
        PlanetSizeManager = GetComponentInChildren<PlanetSizeManager>();

    }
    
    // Update is called once per frame
    void Update()
    {
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
}
