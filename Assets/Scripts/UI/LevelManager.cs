﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Awake () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(other.name);
       // Application.LoadLevel(other.name);
    }

}
