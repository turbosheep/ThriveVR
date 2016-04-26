using UnityEngine;
using System.Collections;

public class Coconut : MonoBehaviour {
    AudioSource Sound;
    Ball2Script Temp;
    // Use this for initialization
    bool Running;
	void Start () {
        Sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision hit)
    {
        //If head, break and give point(through CoconutUpdate function in Ball2 script)
        if (hit.gameObject.name == "HeadCollider" && Running == false)
        {
            Sound.Play();
            Running = true;
            Temp = GameObject.Find("BeachBall").GetComponent<Ball2Script>();
            Temp.CoconutUpdate();
            foreach (ContactPoint contact in hit.contacts)
            {
                // Make sure that we don't shatter if another object in the hierarchy was hit
                if (contact.otherCollider == hit.collider)
                {
                    contact.thisCollider.SendMessage("Shatter", contact.point, SendMessageOptions.DontRequireReceiver);

                    break;
                }
            }
        }
    }
}
