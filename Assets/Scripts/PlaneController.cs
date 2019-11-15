using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public GameObject ball;
    public GameObject downwardPointer;
    public LayerMask rayCastLayerMask;
    // Start is called before the first frame update
    void Start()
    {

    }

    //Get to move parent empty with child ball
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(downwardPointer.transform.position, -Vector3.up, out hit, Mathf.Infinity, rayCastLayerMask))
        {
            float offsetDistance = hit.distance;
            Debug.DrawLine(downwardPointer.transform.position, hit.point, Color.cyan);
        }
        downwardPointer.transform.position = ball.transform.position;
    }
}
