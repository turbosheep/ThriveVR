using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {

	public Transform player;

	// Use this for initialization
	void Awake () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			this.transform.parent = player;
		} else if (Input.GetKeyUp (KeyCode.Mouse0)) {
			this.transform.parent = null;
		}
	}
}
