using UnityEngine;
using System.Collections;

public class TreeSpin : MonoBehaviour {

    float random;
    float hover;
    float y;
	// Use this for initialization
	void Start () {
        random = Random.Range(.2f, .4f);
	}
	// Update is called once per frame
	void FixedUpdate () {
        y += .1f;
        this.transform.Rotate(0, 5f*random, 0);
        hover = ((Mathf.Sin(y))/10);
        CapsuleCollider collider = this.GetComponent<CapsuleCollider>();
        //eventually this will move up and down
        //this.transform.position = new Vector3
          //  (this.transform.position.x, this.transform.position.y + hover, this.transform.position.z);
                collider.transform.position.Set
            (collider.transform.position.x, collider.transform.position.y - hover, collider.transform.position.z);
	}
}
