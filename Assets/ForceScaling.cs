using UnityEngine;
using System.Collections;

public class ForceScaling : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update()
    {
        this.gameObject.transform.localScale = new Vector3(.01f, .01f, .01f);
    }
	
}
