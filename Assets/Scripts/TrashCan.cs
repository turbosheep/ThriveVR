using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrashCan : MonoBehaviour {

    public Animation Anim;
    public AudioSource Audio;
    public Text Text;

    int Count = 2147483647; 


	// Use this for initialization
	void Start () {
        Print();
        Anim = GetComponent<Animation>();
        Audio = GetComponent<AudioSource>();
	}
    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == ("Level"))
        {
            Debug.Log(hit.name);
            SceneManager.LoadScene(hit.name);
        }

        if (hit.gameObject.layer == LayerMask.NameToLayer("Pickup"))
        {
            Destroy(hit);
            Count -= 1;
            Print();
            Anim.Play();
            Audio.Play();
            if (Count == 0)
                SceneManager.LoadScene("Chinashop");

        }
        
    }

    void Print()
    {
        Text.text = "Your workspace is currently " +  "<color=green>" + Count + "x" + "</color>" + "  more messy than it needs to be";
    }
}
