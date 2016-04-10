using UnityEngine;
using System.Collections;

public class keepforever : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

}
