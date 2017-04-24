using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SwitchLevel : MonoBehaviour {

	public string LevelToSwitchTo = string.Empty;
    public string SpawnPointToSpawnAt = string.Empty;
	public bool SwitchOnClick = false;

    public static Planet.PlanetSizeEnum NextDungeonSize { get; set; }

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (SwitchOnClick)
			return;

        UpdateNextDungeonSize();
        SwitchLevel.SwitchToLevel(coll.gameObject, LevelToSwitchTo, SpawnPointToSpawnAt);
	}

	public static void SwitchToLevel(GameObject playerObject, string level, string spawnPointToSpawnAt)
	{
		GameState.SetPlayer(playerObject);
        GameState.GetPlayer().NextTargetSpawnPoint = spawnPointToSpawnAt;
        //GameState.GetPlayer().StopAllAudio();
        SceneManager.LoadScene(level);
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0) && SwitchOnClick)
		{
            UpdateNextDungeonSize();
            SwitchLevel.SwitchToLevel(GameState.GetPlayer().gameObject, LevelToSwitchTo, SpawnPointToSpawnAt);
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
