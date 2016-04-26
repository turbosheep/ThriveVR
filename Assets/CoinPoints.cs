using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CoinPoints : MonoBehaviour {
    AudioSource Sound;
    public int count;
    public Text TextboxRef;
	// Use this for initialization
	void Start () {
        Sound = gameObject.GetComponent<AudioSource>();
        
	}

    void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == "coin")
        {
            Sound.Play();
            count++;
            Destroy(hit.gameObject);
        }

        if (count > 7)
        {
            SceneManager.LoadScene("FootSushi");
        }
    }
    void Update()
    {
        TextboxRef.text = "<color=yellow>" + count + ": Coins</Color>";    
    }
    }