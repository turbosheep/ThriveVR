using UnityEngine;
using System.Collections;

public class BlinkingScript : MonoBehaviour {
    float BlinkTimer;
    bool Blink;
    public SkinnedMeshRenderer L_Eye;
    public SkinnedMeshRenderer R_Eye;
    public Material[] StateArray;

    // Use this for initialization
    void Start () {
        L_Eye = GameObject.Find("L_Eye").GetComponent<SkinnedMeshRenderer>();
        R_Eye = GameObject.Find("R_Eye").GetComponent<SkinnedMeshRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
        BlinkTimer += Time.deltaTime;

        //State: Open eyes
        if(BlinkTimer < 3 && Blink == false)
        {
            L_Eye.material = StateArray[0];
            R_Eye.material = StateArray[0];
        }
        //State: Closed 
        else if(BlinkTimer > 3 && Blink == false){
            L_Eye.material = StateArray[1];
            R_Eye.material = StateArray[1];
            Blink = true;
        }
        //Reset Timer and Blink
        else if (BlinkTimer > 3.1 && Blink == true)
        {
            BlinkTimer = 0f;
            Blink = false; 
        }
    }
}
