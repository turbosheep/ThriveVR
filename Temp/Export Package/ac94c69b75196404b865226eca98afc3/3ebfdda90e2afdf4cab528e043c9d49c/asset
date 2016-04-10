using UnityEngine;
using System.Collections;
using System; 

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class CurveCreator : MonoBehaviour
{
    public LineRenderer DrawLine;
    public Vector3 Origin;
    public int ArrayIndex = 0;
    //We will update the array to grow as needed...
    public Vector3[] LocationArray = new Vector3[20];
    public GameObject[] CollisionEventArray;
    public int[] DistanceofEvents;
    float CoolDown;
    SteamVR_TrackedObject trackedObj;



    // Use this for initialization
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        DrawLine = this.gameObject.AddComponent<LineRenderer>();
        //DrawLine.material = 
        DrawLine.SetWidth(0, 3);
    }

    // Build Line controls the line creation as well as the colliders associated with it.
    void BuildLine() {
        //Resize Array if too big
        ArrayIndex += 1;
        if (LocationArray.Length < ArrayIndex)
           Array.Resize(ref LocationArray, ArrayIndex * (5/3));

        //Input Position into Array
        Origin = this.transform.position;
        LocationArray[ArrayIndex-1] = new Vector3(Origin.x, Origin.y, Origin.z);
        //CollisionEventArray[ArrayIndex - 1] = new GameObject();
        DrawLine.SetVertexCount(ArrayIndex);

        //redraw from Array
        for (int i = 0; i < ArrayIndex; i++)
        {
           DrawLine.SetPosition(i, LocationArray[i]);
        }
    }

    void FixedUpdate()
    {

        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
           BuildLine();
           //CoolDown = 3.0f;

        }

    }
}

