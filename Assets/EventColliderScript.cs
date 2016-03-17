using UnityEngine;
using System.Collections;
using RavingBots.CartoonExplosion;

public class EventColliderScript : MonoBehaviour {
    // Use this for initialization
    private CartoonExplosionFX ScriptRef;
    private BoxCollider BoxRef;
    private GameObject ParentRef;
    void Awake() {
        BoxRef = this.gameObject.AddComponent<BoxCollider>();
        ScriptRef = this.gameObject.GetComponent<CartoonExplosionFX>();


    }

    void OnCollisionEnter(Collision collision)
    {
        BoxRef.isTrigger = false; 
        ScriptRef.Play();
        Object.Destroy(gameObject, 2.0f);
        Destroy(transform.parent.gameObject, 2.0f);
        ScriptRef.Loop = false;
 
    }

   
    // Update is called once per frame
    void Update () {
        transform.LookAt(Camera.main.transform);

    }
}
