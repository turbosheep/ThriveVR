using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ColliderCreation : MonoBehaviour {

    public GameObject point;
    public GameObject parent;

    SteamVR_TrackedObject trackedObj;
    GameObject parentInstance;

	// Use this for initialization
	void Awake () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        parentInstance = Instantiate(parent, Vector3.zero, Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if(device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject obj = Instantiate(point, this.gameObject.transform.position, Quaternion.identity) as GameObject;
            obj.transform.parent = parentInstance.transform;
        }
	}
}
