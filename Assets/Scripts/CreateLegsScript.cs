﻿using UnityEngine;
using System.Collections;

public class CreateLegsScript : MonoBehaviour {
    //UI plane is the plane that will help us create something inside
    public GameObject UIPlane;
    public Transform L_Locator;
    public Transform R_Locator;
    public FixedJoint L_Knee;
    public FixedJoint R_Knee;

    // Use this for initialization
    void Start () {
      

	}
    void OnTriggerEnter(Collider Trigger)
    {
        //Is this the controller 
        if(Trigger.tag == "Player")
        {

        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}