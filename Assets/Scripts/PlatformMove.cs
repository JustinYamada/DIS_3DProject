using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float moveDistanceRight = 0;
    public float moveDistanceForward = 0;
    public float moveDistanceUp = 0;

    public float movementSpeed = 2.5f;

    private Vector3 origin;

    private Vector3 goalPos;

    private float journeyLength;
    private float startTime;
    private float currentFraction;

    private bool goToGoal = true;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        goalPos.x = transform.position.x + moveDistanceRight;
        goalPos.z = transform.position.z + moveDistanceForward;
        goalPos.y = transform.position.y + moveDistanceUp;

        journeyLength = Vector3.Distance(origin, goalPos);
        startTime = Time.time;        
    }

    // Update is called once per frame
    void Update()
    {

        currentFraction = ((Time.time - startTime) * movementSpeed) / journeyLength;

        if (currentFraction >= 1)
        {
            startTime = Time.time;
            goToGoal = !goToGoal;
        }
        else if (goToGoal)
        {
            transform.position = Vector3.Lerp(origin, goalPos, currentFraction);
        }
        else
        {
            transform.position = Vector3.Lerp(goalPos, origin, currentFraction);
        }
    }
}