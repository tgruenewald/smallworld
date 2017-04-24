using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SwitchLevel : MonoBehaviour {

	public string LevelToSwitchTo = string.Empty;
    public string SpawnPointToSpawnAt = string.Empty;
	public bool SwitchOnClick = false;

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (SwitchOnClick)
			return;

		SwitchLevel.SwitchToLevel(coll.gameObject, LevelToSwitchTo, SpawnPointToSpawnAt);
	}

	public static void SwitchToLevel(GameObject playerObject, string level, string spawnPointToSpawnAt)
	{
		GameState.SetPlayer(playerObject);
        playerObject.GetComponent<Player>().NextTargetSpawnPoint = spawnPointToSpawnAt;
        //GameState.GetPlayer().StopAllAudio();
        SceneManager.LoadScene(level);
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0) && SwitchOnClick)
		{
            SwitchLevel.SwitchToLevel(GameState.GetPlayer().gameObject, LevelToSwitchTo, SpawnPointToSpawnAt);
			//SceneManager.LoadScene(LevelToSwitchTo);    
		}
	}
}
