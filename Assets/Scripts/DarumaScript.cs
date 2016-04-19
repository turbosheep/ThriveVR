using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class DarumaScript : MonoBehaviour
{
    //Daruma Script is a AI and animation state script. 
    //1) Be able to move daruma between an array of locations, using the reference NavPoint    //

    //Nav Variables 
    public GameObject NavPoint;
    public Transform[] target;
    NavMeshAgent agent;
    public float Radius = 1;
    public float Speed = 1;
    public int NavIndex = 1;
    public float moveMultiplier;
    public int count;
    private Vector3 previousPosition;

    //Animator Variables
    Animator Anim;
    int Roll = Animator.StringToHash("RollForward");
    int Idle = Animator.StringToHash("Idle 0");

    private bool grounded = false;
    private Rigidbody Rigidbody;
   


    void Start()
    {
        Anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        target = NavPoint.GetComponentsInChildren<Transform>();
        count = target.Length;
        agent.speed = Speed;
    }
    void Awake()
    {
      Rigidbody = this.GetComponent<Rigidbody>();
      Rigidbody.freezeRotation = true;
      Rigidbody.useGravity = true;
    }

    void Update()
    {
        //If the agent's desintation is within the acceptable radius for its location then update and change state
        if (Radius >= agent.remainingDistance && NavIndex<count)
        {
            agent.SetDestination(target[NavIndex].position);
            NavIndex++;
        }
        //Find current magitude then divide it by the max speed and 
        moveMultiplier = 1+(agent.velocity.magnitude / Speed);
        if(moveMultiplier < 2)
            Anim.SetFloat("Speed", moveMultiplier);
        previousPosition = transform.position;

    }

    void OnCollisionStay()
    {
        grounded = true;
    }
}
