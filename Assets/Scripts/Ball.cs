
using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    public float ballVelocity = 600f;

    public float vel;


    private Rigidbody rb;
    [HideInInspector]
    public bool ballInPlay;
    public bool Start;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.name == "HeadCollider")
        {
            Start = true;
        }
    }
    void Update()
    {
        vel = rb.velocity.magnitude;

        if (Start == true && vel > 20)
        {
            Debug.Log("Hit");
            Random.seed = (int)System.DateTime.Now.Ticks;
            float horzmov = Random.Range((-1 * ballVelocity), ballVelocity);
            transform.parent = null;
            //ballInPlay = true;
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(horzmov, ballVelocity , ballVelocity));
            // if(rb.velocity.magnitude){
        }

        if(ballInPlay == true && Mathf.Abs(rb.velocity.z) < 24)
        {

        }
    }
}

