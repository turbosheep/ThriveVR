using UnityEngine;
using System.Collections;

public class ResetBall : MonoBehaviour {
    Vector3 StartPos;
	// Use this for initialization
	void Start () {
        StartPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.name == "Plane")
        {
            transform.position = StartPos;
        }
    }
}
