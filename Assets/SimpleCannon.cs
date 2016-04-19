using UnityEngine;
using System.Collections;
using RavingBots.CartoonExplosion;
//using Valve.VR;

[RequireComponent(typeof(SteamVR_TrackedObject))]


public class SimpleCannon : MonoBehaviour {
    public SteamVR_TrackedObject trackedObj;
    public GameObject ControllerRef;
    public GameObject[] Prefab;
    public Transform PoofRef;
    public float charge = 1f;
    public float size;
    int force;
    float range=8;
    Vector3 VectorAngle;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.LookAt(Camera.main.transform);

        var device = SteamVR_Controller.Input((int)trackedObj.index);
        //gameObject.transform.position = new Vector3(gameObject.transform.position.x,ControllerRef.y, ControllerRef.z);
        //device.GetTouch(SteamVR_Controller.ButtonMask.Axis1);
        //Debug.Log(device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad));

        //Move Cannon based on range and axis of the touchpad. 

        gameObject.transform.position = new Vector3((device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x)*-range, (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y)+ 2.75F, gameObject.transform.position.z);
        Vector3 toCamera = Camera.main.transform.position - this.transform.position;


        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            if (charge <= 5.0f)
                charge += Time.deltaTime;
            else
                charge = 5f;

            var temp = (charge / (2) + size);
            this.transform.localScale = new Vector3(temp, temp, temp);
        }
        else if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        { 
            
            this.transform.localScale = new Vector3(size, size, size);
            if (charge < 2)
            {
                GameObject bPrefab = Instantiate(Prefab[Random.Range(0, Prefab.Length - 1)], PoofRef.position, Quaternion.identity) as GameObject;
                bPrefab.GetComponent<Rigidbody>().AddForce(toCamera * 2 * 2000f);
                bPrefab.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-200, 200), 200, Random.Range(-200,200)));
                PoofRef.GetComponent<CartoonExplosionFX>().Play();
            }
            else
            {
                GameObject bPrefab = Instantiate(Prefab[Prefab.Length - 1], PoofRef.position, Quaternion.identity) as GameObject;
                bPrefab.GetComponent<Rigidbody>().AddForce(toCamera / ((charge / 5) + 1) * 2000f);
                bPrefab.transform.localScale = bPrefab.transform.localScale * ((charge / 5) + 1);
                PoofRef.GetComponent<CartoonExplosionFX>().Play();
            }
            charge = 1f;
        }
   
    }
}
