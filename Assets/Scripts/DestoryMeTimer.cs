using UnityEngine;
using System.Collections;

public class DestoryMeTimer : MonoBehaviour {
    public float Delay = 10f;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, Delay);
	}
}
