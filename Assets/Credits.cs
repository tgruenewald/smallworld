﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Credits : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void clickEndScene() {
		SceneManager.LoadScene ("ending");
	}

	public void clickBack() {
		SceneManager.LoadScene ("title");
		
	}
}
