using UnityEngine;
using System.Collections;

public class CreateLegsScript : MonoBehaviour {
    //UI plane is the plane that will help us create something inside
    public GameObject self;
    public GameObject MasterPrefab;

    public float delay;
    public AudioSource Sound;
    Collider hitObject;
    bool inside = false;
    bool grabbed = false;
    float temp = 0;

    // Use this for initialization
    void Awake () 
    {
        MasterPrefab = GameObject.Find("GetPlayerDataSquare");
        self = gameObject;
        Sound = gameObject.GetComponent<AudioSource>();
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
	void FixedUpdate () 
    {
        if (temp < delay && inside == true)
            temp += Time.deltaTime;
        else if (inside == true && grabbed != true)
        {
            Sound.Play();
            self.transform.parent = hitObject.transform;
            grabbed = true;
            Destroy(MasterPrefab, 10);
            
           // GameObject bPrefab = Instantiate(Prefab[Random.Range(0, Prefab.Length - 1)], PoofRef.position, Quaternion.identity) as GameObject;
        }
	}
}
