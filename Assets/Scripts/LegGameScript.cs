using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LegGameScript : MonoBehaviour {
    public float cooldown;
    public float VariableTime = 20f;
    public Text ScoreRef;
    public GameObject[] Items;
    public Transform[] locations;
    int inside;
    string Score;
    AudioSource Confirm;

    GameObject[] Everything;
    void Start()
    {
       
       // Confirm = gameObject.GetComponent<AudioSource>();
    }



    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "coin")
            inside++;
    }
    void OnTriggerExit(Collider hit)
    {
        if (hit.tag == "coin")
            inside--;
    }

   void Print()
    {
        Score = "You have <color=yellow>" + inside + "</color> of <color=green> 7 </color> coins in your area to win!!!";
        ScoreRef.text = Score;
    }
    // Update is called once per frame
    void FixedUpdate () {
        cooldown += Time.deltaTime;

        if (cooldown > VariableTime)
        {
           // Print();
            GameObject Prefab = Instantiate(Items[Random.Range(0,2)], locations[Random.Range(0,(locations.Length-1))].position , Quaternion.identity) as GameObject;
           // Confirm.Play();
            VariableTime = Random.Range(.5f, 3f);
            cooldown = 0F;
            }
        if(inside >= 7)
        {
            SceneManager.LoadScene("AnimationDemo");
        }
    }
}
