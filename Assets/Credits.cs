using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour {

	const int MAX_TUT_LEVEL = 7;
	static int tutLevel = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private int getNextTutorial() {
		if (tutLevel < MAX_TUT_LEVEL) {
			tutLevel++;
		}
		return tutLevel;
	}
	private int getPrevTutorial() {
		if (tutLevel > 1) {
			tutLevel--;
		}
		return tutLevel;
	}

	public void clickPlay() {
		SceneManager.LoadScene ("outer_space");
	}

	private void check_button_states () {
		Button button = GameObject.Find ("next").GetComponent<Button> ();
		if (tutLevel >= MAX_TUT_LEVEL) {
			button.interactable = false;
		} else {
			button.interactable = true;
		}
	}
	public void clickNextTutorial() {


		GameObject go = GameObject.Find("Tutorial");
		go.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("sprites/tut" +  getNextTutorial() );
		check_button_states ();

	}
	public void clickPrevTutorial() {
		if (tutLevel == 1) {
			SceneManager.LoadScene ("title");
		}
		GameObject go = GameObject.Find("Tutorial");
		go.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("sprites/tut" + getPrevTutorial());
		check_button_states ();
	}
	public void clickEndScene() {
		SceneManager.LoadScene ("ending");
	}

	public void clickBack() {
		SceneManager.LoadScene ("title");
		
	}
}
