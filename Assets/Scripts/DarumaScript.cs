using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class DarumaScript : MonoBehaviour
{
    //Daruma Script is a AI and animation state script. 
    //1) Be able to move daruma between an array of locations, using the reference NavPoint    //

    //Nav Variables 
    public GameObject NavPoint;
    public Transform[] target;
    public GameObject NewTarget;
    public GameObject HeadRef;
    UnityEngine.AI.NavMeshAgent agent;
    public float Radius = 1;
    public float Speed = 1;
    public int NavIndex = 1;
    public float moveMultiplier;
    public int count;
    private Vector3 previousPosition;
    //private Transform OriginalLocation;
    public GameObject TextBoxRef;
    public bool Static;



    //Animator Variables
    Animator Anim;
    int Roll = Animator.StringToHash("RollForward");
    int Idle = Animator.StringToHash("Idle 0");
    float BlinkTimer;

    public bool isTalking = false;
    private bool grounded = false;
    public Rigidbody Rigidbody;
    float RadiusRatio;


    void Start()
    {
        //Head Joint Reference
        NewTarget = GameObject.Find("Camera (head)");
       // OriginalLocation = NewTarget.transform;
        //Camera Reference
        HeadRef = GameObject.Find("Camera (head)");
        Anim = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = NavPoint.GetComponentsInChildren<Transform>();
        count = target.Length;
        agent.speed = Speed;
        
    }
    void Awake()
    {
      Rigidbody = this.GetComponent<Rigidbody>();
      Rigidbody.freezeRotation = true;
      Rigidbody.useGravity = false;
    }

    void Update()
    {
        if (!Static)
        {
            //If the agent's desintation is within the acceptable radius for its location then update and change state
            if (Radius >= agent.remainingDistance && NavIndex < count)
            {
                agent.SetDestination(target[NavIndex].position);
                NavIndex++;
            }
            //Find current magitude then divide it by the max speed and 
            moveMultiplier = 1 + (agent.velocity.magnitude / Speed);
            if (moveMultiplier > 2)
                moveMultiplier = 2;
            Anim.SetFloat("Speed", moveMultiplier);
            previousPosition = transform.position;

            //Has the object stopped moving and has it reached their final destination? 
            if (moveMultiplier == 1F && NavIndex == count && isTalking == false)
            {

                Talking();
            }

            if (isTalking)
            {
                //FaceOffset targets current Camera (Head). Y rotation Is handled Here!
                Vector3 Temp = (HeadRef.transform.position - NewTarget.transform.position);
                NewTarget.transform.right = Temp;
                //Objects rotation follows Head through just its x and z coordinats
                Quaternion Rotation = Quaternion.LookRotation(new Vector3(Temp.x, 0, Temp.z));
                this.gameObject.transform.rotation = Rotation;

            }
        }
    }

    void Talking()
    {
        //Anim.SetTrigger("StartChatHere");
        Invoke("unhide", 2);
        isTalking = true;
    }
    void unhide()
    {
        TextBoxRef.SetActive(true);
    }
    void OnCollisionStay()
    {
        grounded = true;
    }
}
