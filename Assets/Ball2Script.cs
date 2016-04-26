using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Ball2Script : MonoBehaviour {
    public GameObject Coconut;
    public Transform[] locations;
    public float Force;
    public int Count;
    Vector3 StartPos;
    Rigidbody BallRigidbody;
    Vector3 Direction;
    GameObject PalmLeaves;

    bool IsActive;
    public Text TextBox;
    public float CoolDown = 1F;


	// Use this for initialization
	void Start () {
        StartPos = this.transform.position; 
        BallRigidbody = GetComponent<Rigidbody>();
        TextBox = GameObject.Find("TextBox").GetComponent<Text>();
        PalmLeaves = GameObject.Find("PalmLeaves");
    }
	
    //Ball Collides with object, Query Object and if its part of three acceptable type. 
    void OnCollisionEnter(Collision hit)
    {
        //If head, Send up! 
        if (hit.gameObject.name == "HeadCollider") //&& IsActive != true)
        {
            Direction = hit.transform.position - transform.position;
            BallRigidbody.AddForce(new Vector3(Direction.x, 5,Direction.z) * Force, ForceMode.Impulse);
            IsActive = true;
        }
        //If Top of the tree, Spawn coconut
        if(hit.gameObject.name == "EVENTSYSTEM")
        {
            PalmLeaves.GetComponent<Animation>().Play();
            PalmLeaves.GetComponent<AudioSource>().Play();
            GameObject Prefab = Instantiate(Coconut, locations[Random.Range(0, (locations.Length - 1))].position, Quaternion.identity) as GameObject;
        }
        //If floor, reset
        if(IsActive && hit.gameObject.name == "IslandModel")
        {
            this.transform.position = StartPos;
            BallRigidbody.useGravity = false;
            BallRigidbody.velocity = Vector3.zero;
            BallRigidbody.angularVelocity = Vector3.zero;
        }
    }
    //Function that is called from the Coconut itself. That way the ball controls all the variables. 
    public void CoconutUpdate()
    {
        //Make sure you arent hitting the same object
        if(CoolDown <= 0)
        {
            Count--;
            CoolDown = 1f;
        }
        if(Count <= 0)
        {
            //Application.LoadLevel("Chinashop");
            SceneManager.LoadScene("Chinashop");

        }

       
    }
	void Update () {
        TextBox.text = "There are <Color=yellow>" + Count + "</Color> Coconuts to break open";
        CoolDown -= Time.deltaTime;
    }
}
