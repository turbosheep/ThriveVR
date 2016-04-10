using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {
 
	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
           Application.LoadLevel(other.name);
    }
     
    // Update is called once per frame
    void Update () {
	
	}
}
