using UnityEngine;
using System.Collections;

public class CreateLegsScript : MonoBehaviour {
    //UI plane is the plane that will help us create something inside
    public GameObject self;
    public FixedJoint selfRef;
    public float delay;

    Collider hitObject;
    bool inside = false;
    float temp = 0;
    // Use this for initialization
    void Awake () 
    {
        selfRef = this.GetComponent<FixedJoint>();
	}
    void OnTriggerEnter(Collider Trigger)
    {
        //Is this the controller 
        if(Trigger.tag == "Player")
        {
            Debug.Log("Legs hit");
            inside = true;
            hitObject = Trigger;
        }
    }
	// Update is called once per frame
	void Update () 
    {
        if (temp < delay && inside == true)
            temp+= Time.deltaTime;
        else if(inside == true)
            selfRef.connectedBody = hitObject.gameObject.GetComponent<Rigidbody>();

	}
}
