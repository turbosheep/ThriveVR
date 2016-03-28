using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrashCan : MonoBehaviour {


    public Text Text;

    int Count = 3; 


	// Use this for initialization
	void Start () {
        Print();
	}
    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.layer == LayerMask.NameToLayer("Pickup"))
            Destroy(hit);
            Count -= 1;
            Print();
    }

    void Print()
    {
        Text.text = "Your workspace is currently " +  "<color=green>" + Count + "x" + "</color>" + "  more messy than it needs to be";
    }
}
