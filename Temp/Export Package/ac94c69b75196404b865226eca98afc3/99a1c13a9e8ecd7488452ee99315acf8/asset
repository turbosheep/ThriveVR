using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {
    float ScaleRate = 1F;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.rotation *= Quaternion.Euler(0, 180, 0);
        //transform.localScale = Vector3.one * ScaleRate;
        //ScaleRate = ScaleRate + .0001F;
    }
}
