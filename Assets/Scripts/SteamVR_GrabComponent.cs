using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class SteamVR_GrabComponent: MonoBehaviour
{
	public GameObject ObjectGrabbed;
    public Rigidbody Self;
    public bool DebugMode;
    public TextMesh DebugText;
    GameObject TextCompensateLocation;  
    SteamVR_TrackedObject trackedObj;
	FixedJoint joint;

    
    //FixedJoint ObjectsJoint;
    void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
        TextCompensateLocation = new GameObject();
        if (DebugMode == true)
        {
            //TextCompensateLocation.parent
            DebugText = this.gameObject.AddComponent<TextMesh>();
            DebugText.characterSize = 0.01f;
            DebugText.offsetZ = -0.1f;

        }
	}
    void OnTriggerEnter(Collider hit)
    {
        ObjectGrabbed = hit.gameObject;
        ObjectGrabbed.GetComponent<Rigidbody>().useGravity = false;
     }

    //Handled on event trigger released
    void OnCollisionExit()
    {
        ObjectGrabbed = null;
    }
	void FixedUpdate()
	{

        if(DebugMode == true)
        {
            DebugText.text = ObjectGrabbed.name;
        }

		var device = SteamVR_Controller.Input((int)trackedObj.index);
		if (joint == null && device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
		{
            joint = ObjectGrabbed.AddComponent<FixedJoint>();
            joint.connectedBody = Self;
            

        }
		else if (joint != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
		{
    
            var go = joint.gameObject;
            var rigidbody = go.GetComponent<Rigidbody>();
            Destroy(ObjectGrabbed.GetComponent<FixedJoint>());
            joint = null;
			// We should probably apply the offset between trackedObj.transform.position
			// and device.transform.pos to insert into the physics sim at the correct
			// location, however, we would then want to predict ahead the visual representation
			// by t he same amount we are predicting our render poses.

			var origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
			if (origin != null)
			{
				rigidbody.velocity = origin.TransformVector(device.velocity);
				rigidbody.angularVelocity = origin.TransformVector(device.angularVelocity);
			}
			else
			{
				rigidbody.velocity = device.velocity;
				rigidbody.angularVelocity = device.angularVelocity;
			}
            ObjectGrabbed.GetComponent<Rigidbody>().useGravity = true;
            rigidbody.maxAngularVelocity = rigidbody.angularVelocity.magnitude;
            ObjectGrabbed = null;
        }
	}
}
