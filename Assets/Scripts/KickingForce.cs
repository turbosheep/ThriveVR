using UnityEngine;
using System.Collections;

public class KickingForce : MonoBehaviour {
    public float Velocity;
    public Vector3 Direction;
	// Update is called once per frame
	void Update () {
        //Velocity = hit.relativeVelocity.magnitude;
    }
    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "GameController")
        {
            Direction  = hit.transform.position - this.transform.position;
            Velocity = hit.relativeVelocity.magnitude;
            gameObject.GetComponent<Rigidbody>().AddForce(Direction*10F, ForceMode.Impulse);
        }
    }
}
