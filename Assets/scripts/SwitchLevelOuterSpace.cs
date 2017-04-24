using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SwitchLevelOuterSpace : MonoBehaviour {

	public string LevelToSwitchTo = string.Empty;
    public string SpawnPointToSpawnAt = string.Empty;
	public bool SwitchOnClick = false;

    public static Planet.PlanetSizeEnum NextDungeonSize { get; set; }

	void OnTriggerEnter2D(Collider2D coll)
	{
		Debug.Log ("SwitchLevelOuterSpace PLANET!!!!!!");
		if (SwitchOnClick)
			return;

        UpdateNextDungeonSize();
		SwitchLevelOuterSpace.SwitchToLevel(coll.gameObject, LevelToSwitchTo, SpawnPointToSpawnAt);
	}

	public static void SwitchToLevel(GameObject playerObject, string level, string spawnPointToSpawnAt)
	{
//		playerObject.GetComponent<Player> ().enabled = false;
//		playerObject.GetComponent<droplet> ().enabled = true;
        //GameState.GetPlayer().StopAllAudio();
		DestroyObject(playerObject);
		Player player = GameState.GetPlayer();
		player.NextTargetSpawnPoint = spawnPointToSpawnAt;
		Debug.Log("Scene: " + level);
        SceneManager.LoadScene(level);
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0) && SwitchOnClick)
		{
            UpdateNextDungeonSize();
			SwitchLevelOuterSpace.SwitchToLevel(GameState.GetPlayer().gameObject, LevelToSwitchTo, SpawnPointToSpawnAt);
			//SceneManager.LoadScene(LevelToSwitchTo);    
		}
	}

    private void UpdateNextDungeonSize()
    {
        var currentPlanet = this.GetComponentInParent<Planet>();
        if (currentPlanet != null)
            NextDungeonSize = currentPlanet.PlanetSize;
    }
}
