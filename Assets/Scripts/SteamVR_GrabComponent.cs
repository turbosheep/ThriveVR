using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class SteamVR_GrabComponent: MonoBehaviour
{
	public GameObject ObjectGrabbed;
    private Rigidbody Self;
    public bool DebugMode;
    public TextMesh DebugText;
    SteamVR_TrackedObject trackedObj;
	public FixedJoint joint;
    float MassContainer;

    //FixedJoint ObjectsJoint;
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        //TextCompensateLocation = new GameObject();
        Self = this.GetComponent<Rigidbody>();
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
        if (DebugMode == true)
        {
            Debug.Log("OnTriggerEnter");
        }
        if (hit.gameObject.layer == LayerMask.NameToLayer("Pickup"))
        {
            if (DebugMode == true)
            {
                Debug.Log("in the if");
            }
            ObjectGrabbed = hit.gameObject;
        }
    }

    //Handled on event trigger released
    void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject == ObjectGrabbed.gameObject)
        {
            Debug.Log("OnCollisionExit");
            ObjectGrabbed = null;
            joint.connectedBody = null;
        }
    }

    void FixedUpdate()
    {

        if (DebugMode == true)
        {
            if (ObjectGrabbed != null)
                DebugText.text = ObjectGrabbed.name;
        }

        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (joint == null && device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            if (ObjectGrabbed != null)
            {
                device.TriggerHapticPulse(500);
                Rigidbody tempspace = ObjectGrabbed.GetComponent<Rigidbody>();
                MassContainer = tempspace.mass;
                tempspace.mass = 1;
                tempspace.useGravity = false;
                joint = ObjectGrabbed.AddComponent<FixedJoint>();
                joint.connectedBody = Self;
            }
        }
        else if (joint != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            var go = joint.gameObject;
            var rigidbody = go.GetComponent<Rigidbody>();
            Object.DestroyImmediate(joint);
            joint = null;

            // We should probably apply the offset between trackedObj.transform.position
            // and device.transform.pos to insert into the physics sim at the correct
            // location, however, we would then want to predict ahead the visual representation
            // by the same amount we are predicting our render poses.

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
            ObjectGrabbed.GetComponent<Rigidbody>().mass = MassContainer;
            MassContainer = 1;
            rigidbody.maxAngularVelocity = rigidbody.angularVelocity.magnitude;
        }
    }
}