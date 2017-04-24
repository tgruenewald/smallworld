using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	public AudioClip LevelAmbientSound;
    public string SpawnPointName;

	// Use this for initialization
	void Start () {
		var player = GameState.GetPlayer();
		player.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		Debug.Log ("Restorign planet state");
		if (GameObject.Find ("planet1").GetComponent<Planet> () != null) {
			try {
			GameObject.Find ("planet1").GetComponent<Planet> ().PlanetSizeManager.SizeTransform.localScale = GameState.planet1;
			} catch {
				Debug.Log ("planet 1 not saved");
			}
		}
		if (GameObject.Find ("planet2").GetComponent<Planet> () != null) {
			try {
			GameObject.Find ("planet2").GetComponent<Planet> ().PlanetSizeManager.SizeTransform.localScale = GameState.planet2;
			} catch {
				Debug.Log ("planet 2 not saved");
			}

		}
		if (GameObject.Find ("planet3").GetComponent<Planet> () != null) {
			try {
			GameObject.Find ("planet3").GetComponent<Planet> ().PlanetSizeManager.SizeTransform.localScale = GameState.planet3;
			} catch {
				Debug.Log ("planet 3 not saved");
			}
		}
		Debug.Log ("TRIED TO SAVE PLANET SIZE");

		if (player != null)
		{
            if (player.NextTargetSpawnPoint != this.SpawnPointName)
                return;
            //Debug.Log("Setting droplet start pos: " + GetComponent<Transform>().position);
            //playerDroplet.StopAllAudio();
            //playerDroplet.PlayAudio(LevelAmbientSound);
            //playerDroplet.SpawnAt(this.gameObject);
            player.SpawnAt(this.gameObject);

            var otherPlayers = GameObject.FindObjectsOfType<Player>();
			Debug.Log(string.Format("Amount of player in scene: {0}", otherPlayers.Length));
			for(int i = 0; i < otherPlayers.Length; ++i)
            {
				var otherPlayer = otherPlayers[i];
				if(otherPlayer != player)
                {
					Debug.Log(string.Format("Destroying object: {0} because it's not object: {1}", otherPlayer.gameObject.name, player.gameObject.name));
					Destroy(otherPlayer.gameObject);
				}
			}
		}
	}
}
