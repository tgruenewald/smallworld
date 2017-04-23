using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    
    //private PointEffector2D GravityEffector = null;
    public PlanetGravity PlanetGravity;
    public PlanetSize PlanetSize;

    // Use this for initialization
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        Player currentPlayer = GameState.GetPlayer();
        if(currentPlayer != null && PlanetGravity != null)
        {
            PlanetGravity.GravityEffector.enabled = (currentPlayer.CurrentPlanet == this.gameObject || currentPlayer.IsGrounded == false);
        }

        if(PlanetGravity != null && PlanetSize != null)
        {
            PlanetGravity.ForceScale = PlanetSize.ScalePercentage;
        }
    }

}
