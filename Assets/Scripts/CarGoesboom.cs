using UnityEngine;
using System.Collections;
using RavingBots.CartoonExplosion;
using ShatterToolkit.Helpers;

public class CarGoesboom : MonoBehaviour {
    // Use this for initialization
    public CartoonExplosionFX ScriptRef;
    public ShatterOnCollision ShatterRef;
    public BoxCollider BoxRef;
    public GameObject ParentRef;
    public GameObject Explosion;
    public Rigidbody RigidRef;

    void Awake() {
        BoxRef = this.gameObject.GetComponent<BoxCollider>();
        ScriptRef = ParentRef.gameObject.GetComponent<CartoonExplosionFX>();
        RigidRef = this.gameObject.GetComponent<Rigidbody>();
        ShatterRef = this.gameObject.GetComponent<ShatterOnCollision>();
      
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car" )
        {
            //GameObject obj = Instantiate(Explosion, this.gameObject.transform.position, Quaternion.identity) as GameObject;
            ScriptRef.Play();
            RigidRef.AddExplosionForce(5, this.transform.forward, 1, 1.0f);
            var temp = collision.gameObject.GetComponent<Rigidbody>();
           // temp.AddExplosionForce(100, this.transform.position, 7, 3.0f);
           ShatterRef.requiredVelocity += 100;
           // Destroy(DarumaRef.GetComponent<FixedJoint>());
        }


    }

   
    // Update is called once per frame
    void FixedUpdate () {
        //ShatterRef.requiredVelocity += 1000;
    }
}
