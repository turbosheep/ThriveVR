using UnityEngine;
using System.Collections;

public class CarScript : MonoBehaviour {
    public bool isGoingRight;
    public bool isDriving = true;
    public Rigidbody Self;
    public float speed;
    // Use this for initialization
    void Start()
    {
        //What speed are you going
        Self = this.GetComponent<Rigidbody>();
        Self.AddForce(transform.forward * speed);
    }
    // Update is called once per frame
    void Update() { }
}
