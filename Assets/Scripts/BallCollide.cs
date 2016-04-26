using UnityEngine;
using System.Collections;

public class BallCollide : MonoBehaviour {

    public float ballVelocity = 600f;
    private Rigidbody rb;
    private Vector3 restart = new Vector3(0, 0, 26);
    public GameObject ballObject;
    Ball ball;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ballObject = this.gameObject;
        ball = ballObject.GetComponent<Ball>();
    }


    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Island")
        {
            rb.AddForce(new Vector3(0, ballVelocity/ 3, ballVelocity/(Mathf.Abs(ballVelocity))));

        }

        else if(col.gameObject.name == "Floor")
        {
            transform.position = restart;
            rb.useGravity = false;
            rb.velocity = (new Vector3(0, 0, 0));

            ball.ballInPlay = false;
            
        }
    }
}
