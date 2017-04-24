using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        var player = GameState.GetPlayer();
		GameObject cachePlayer = GameObject.Find ("CachedPlayer");
		player.SpawnAt (cachePlayer);
        Vector3 scale = GetDesiredDungeonSize(SwitchLevel.NextDungeonSize);
//        GameObject[] gameObjs = FindObjectsOType<GameObject>();
//        GameObject emptyParent = new GameObject("RootParent");
//        foreach(var gameObj in gameObjs)
//        {
//            //Make sure the gameObj is the root of that particular heirarchy
//            if (gameObj.transform.root.gameObject != gameObj || (player != null && gameObj == player.gameObject))
//                continue;
//
//            gameObj.transform.parent = emptyParent.transform;
//        }
		GameObject planetParent = GameObject.FindGameObjectWithTag("PlanetInterior");

		planetParent.transform.localScale = scale;
        //Camera.main.orthographicSize *= GetDesiredDungeonScaleFloat(SwitchLevel.NextDungeonSize);

        //player.gameObject.transform.localScale = scale;
//        player.transform.up = Vector3.up;
//        player.GetComponent<Rigidbody2D>().freezeRotation = true;
//        player.Respawn();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private float GetDesiredDungeonScaleFloat(Planet.PlanetSizeEnum parentPlanetSize)
    {
        float factor = 1.0f;
		Debug.Log ("Planet size = " + parentPlanetSize);
        switch (parentPlanetSize)
        {
            case Planet.PlanetSizeEnum.L:
                factor = 6.0f;
                break;
            case Planet.PlanetSizeEnum.M:
                factor = 4.0f;
                break;
            case Planet.PlanetSizeEnum.S:
                factor = 1.2f;
                break;
            case Planet.PlanetSizeEnum.XS:
                factor = 0.5f;
                break;
        }
        return factor;
    }

    private Vector3 GetDesiredDungeonSize(Planet.PlanetSizeEnum parentPlanetSize)
    {
        float factor = GetDesiredDungeonScaleFloat(parentPlanetSize);
        return new Vector3(factor, factor, 1.0f);
    }
}
