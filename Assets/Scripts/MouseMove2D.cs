using UnityEngine;
using System.Collections;

public class MouseMove2D : MonoBehaviour
{

    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    void Start()
    {

    }

    private Vector3 playerPos = new Vector3(0, 00, 0);

    void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * moveSpeed);
        float yPos = transform.position.y + (Input.GetAxis("Vertical") * moveSpeed);

        playerPos = new Vector3(Mathf.Clamp(xPos, -8f, 8f), Mathf.Clamp(yPos, 1f, 10f), 21f);
        transform.position = playerPos;


    }

}
