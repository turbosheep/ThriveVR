﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResetScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider hit)
    {
        SceneManager.LoadScene("MenuSceneSecondRun");
    }
    // Update is called once per frame
    void Update () {
	
	}
}
