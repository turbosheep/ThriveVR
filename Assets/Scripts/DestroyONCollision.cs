using UnityEngine;
using System.Collections;

public class DestroyONCollision : MonoBehaviour {

    void OnCollisionEnter(Collision hit)
    {
        Destroy(hit.gameObject);
    }

}
