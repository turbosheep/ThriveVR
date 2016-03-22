using UnityEngine;
using System.Collections;

public class ResetScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider hit)
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    // Update is called once per frame
    void Update () {
	
	}
}
