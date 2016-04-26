using UnityEngine;
using System.Collections;
using RavingBots.CartoonExplosion;

public class BombBomb : MonoBehaviour {
    //Color[] BombStage;
    public CartoonExplosionFX ScriptRef;
    bool isTicking = true;
    bool once;
    float delay;
    public float radius = 2F;
    public Collider[] Objects;
    Renderer Reference;
    ForceMode settings;
    public float Cadence = 3f;
    public float TimeSinceCadence;
    public AudioSource Sound;
    public AudioClip[] A;
    
	// Use this for initialization
	void Start () {
        Reference = this.gameObject.GetComponent<Renderer>();
        Sound = gameObject.GetComponent<AudioSource>();
        TimeSinceCadence = Cadence;
        
    }
	
    void OnCollisionEnter()
    {
        isTicking = true;
    }

	// Update is called once per frame
	void Update () {
        if (isTicking == true)
        {
            delay += Time.deltaTime;
            TimeSinceCadence += Time.deltaTime;
            if (TimeSinceCadence > Cadence)
            {
                Sound.clip = A[0];
                Sound.Play();
                Cadence = Cadence * .8f;
                TimeSinceCadence = 0;
                if (Cadence < .25f)
                    Cadence = 200f;
            }
            TimeSinceCadence += Time.deltaTime;

        }

        if (isTicking == true && delay < 2)
        {
            Reference.material.color = Color.grey;
            
        }
        else if (delay > 2 && delay < 4)
        {
            Reference.material.color = Color.yellow;

        }
        else if(delay > 4)
        {
            Reference.material.color = Color.red;
        }

        if(delay > 6 && isTicking == true && once==false)
        {
            isTicking = false;
            once = true;
            ScriptRef.Play();
            Objects = Physics.OverlapSphere(transform.position, radius);
            Sound.clip = A[1];
            Sound.Play();
            
          foreach (Collider each in Objects)
          {
              Debug.Log("Here starts " + each);
              if(each.GetComponent<Rigidbody>() != null && each.tag == "coin")
                {
                    each.GetComponent<Rigidbody>().AddExplosionForce(200f, transform.position, radius, 10f, ForceMode.Impulse);
                    Debug.Log("Here Ends" + each);
                }
                  
          }
            
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
            Destroy(gameObject, 2);
        }


    }
}
