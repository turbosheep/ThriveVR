
using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    public float ballVelocity = 600f;

    public float vel;


    private Rigidbody rb;
    [HideInInspector]
    public bool ballInPlay;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        vel = rb.velocity.z;

        if (Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            Random.seed = (int)System.DateTime.Now.Ticks;
            float horzmov = Random.Range((-1 * ballVelocity), ballVelocity);
            rb.useGravity = true;

            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(horzmov, ballVelocity , ballVelocity));
        }

        if(ballInPlay == true && Mathf.Abs(rb.velocity.z) < 24)
        {

        }
    }
}

