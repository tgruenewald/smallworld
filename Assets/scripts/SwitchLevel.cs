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
		Debug.Log ("ENTERING PLANET!!!!!!");
		if (SwitchOnClick)
			return;

        UpdateNextDungeonSize();
		SwitchLevel.SwitchToLevel(coll.gameObject, LevelToSwitchTo, SpawnPointToSpawnAt, this.GetComponentInParent<Planet>());
	}

	public static void SwitchToLevel(GameObject playerObject, string level, string spawnPointToSpawnAt, Planet planet)
	{
		GameState.SetPlayer(playerObject);

        GameState.GetPlayer().NextTargetSpawnPoint = spawnPointToSpawnAt;
		playerObject.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
		GameState.freeze = true;
        //GameState.GetPlayer().StopAllAudio();
		Debug.Log("Scene: " + level);
        SceneManager.LoadScene(level);
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0) && SwitchOnClick)
		{
            UpdateNextDungeonSize();
			SwitchLevel.SwitchToLevel(GameState.GetPlayer().gameObject, LevelToSwitchTo, SpawnPointToSpawnAt, this.GetComponentInParent<Planet>());
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
