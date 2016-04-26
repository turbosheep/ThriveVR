using UnityEngine;
using System.Collections;

public class AnythingFalls : MonoBehaviour {
    public GameObject[] DropableItems;
    float frequency;
    bool StartGame;


    void Play()
    {
        StartGame = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (StartGame)
        {


            //DropableItems[Random.Range(0, (DropableItems.Length - 1))];
        }	   
	}
}
