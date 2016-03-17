using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Awake () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pickup"))
        {
            Debug.Log(other.name);
            Application.LoadLevel(other.name);
        }
	}
}
