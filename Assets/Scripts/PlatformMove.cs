using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float moveDistanceRight = 0;
    public float moveDistanceForward = 0;
    public float moveDistanceUp = 0;

    public float movementSpeed = 2;

    private Vector3 origin;

    private Vector3 goalPos;

    private Vector3 movement;

    private bool goToGoal = true;


    private float slowestToGoal;


    //If there is a value for the moveDistance, then it is moved that direction first and the opposite direction back

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        goalPos.x = transform.position.x + moveDistanceRight;
        goalPos.z = transform.position.z + moveDistanceForward;
        goalPos.y = transform.position.y + moveDistanceUp;

        float min = moveDistanceRight;

        if (min > moveDistanceUp)
        {
            min = moveDistanceUp;
        }
        if (min > moveDistanceForward)
        {
            min = moveDistanceForward;
        }
        slowestToGoal = min / movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > goalPos.x)
        {
            goToGoal = !goToGoal;
            movementSpeed = -movementSpeed;
            slowestToGoal = -slowestToGoal;
        }
        else if (transform.position.x < origin.x)
        {
            goToGoal = !goToGoal;
            movementSpeed = -movementSpeed;
            slowestToGoal = -slowestToGoal;
        }


        if (goToGoal)
        {
            if (movement.x + transform.position.x < goalPos.x)
            {
                movement.x = moveDistanceRight / slowestToGoal;
                movement.y = moveDistanceUp / slowestToGoal;
                movement.z = moveDistanceForward / slowestToGoal;
            }
            else
            {
                transform.position = goalPos;
            }
        }
        else
        {
            if (movement.x - transform.position.x < origin.x)
            {
                movement.x = moveDistanceRight / slowestToGoal;
                movement.y = moveDistanceUp / slowestToGoal;
                movement.z = moveDistanceForward / slowestToGoal;
            }
            else
            {
                transform.position = origin;
            }
        }
        transform.position = transform.position + movement;

    }
}
