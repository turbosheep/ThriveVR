using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {

    bool itemAttached;
    Ray ray;
    RaycastHit hit;

	// Use this for initialization
	void Awake () {
        bool itemAttached = false;
        Debug.Log("hello");
	}
	
	// Update is called once per frame
    void FixedUpdate()
    {
        ray = new Ray(this.transform.position, this.transform.forward);
		if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            Debug.Log("click");
            if(itemAttached)
            {
                hit.transform.parent = null;
                Debug.Log(hit.transform.name + " was detached");
                hit.transform.gameObject.GetComponent<Rigidbody>().useGravity = true;
                itemAttached = false;
            }
            else if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Pickup"))
                {
                    itemAttached = true;
                    hit.transform.parent = this.transform;
                    hit.transform.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    Debug.Log(hit.transform.name + " was attached");
                }
            }
		}
	}
}
