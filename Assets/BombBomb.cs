using UnityEngine;
using System.Collections;
using RavingBots.CartoonExplosion;

public class BombBomb : MonoBehaviour {
    //Color[] BombStage;
    public CartoonExplosionFX ScriptRef;
    bool isTicking;
    bool once;
    float delay;
    float radius = 2F;
    public Collider[] Objects;
    Renderer Reference;
    ForceMode settings;
    
	// Use this for initialization
	void Start () {
        Reference = this.gameObject.GetComponent<Renderer>();
    }
	
    void OnCollisionEnter()
    {
        isTicking = true;
    }
	// Update is called once per frame
	void FixedUpdate () {
        if (isTicking)
        {
            delay += Time.deltaTime;
        }

        if (delay > 4);

        if(isTicking == true && delay < 2)
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
            gameObject.GetComponent<AudioSource>().Play();
            Objects = Physics.OverlapSphere(transform.position, radius);
          foreach(Collider each in Objects)
          {
              Debug.Log("Here starts " + each);
              if(each.GetComponent<Rigidbody>() != null && each.tag == "coin")
                {
                    each.GetComponent<Rigidbody>().AddExplosionForce(100f, transform.position, radius);
                    Debug.Log("Here Ends" + each);
                }
                  
          }
            
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
            Destroy(gameObject, 2);
        }


    }
}
