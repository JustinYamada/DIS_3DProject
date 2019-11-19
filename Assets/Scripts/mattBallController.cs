using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class mattBallController : MonoBehaviour
{
    public float maxSpeed;

    public float acceleration;


    private float currentAccel;
    private Vector3 movement;

    private Rigidbody ball;

    public followBall camera;

    singleJump jumpItem;

    public bool onGround = true;


    // Start is called before the first frame update
    void Start()
    {
        currentAccel = 0;
        ball = GetComponent<Rigidbody>();
        gameObject.AddComponent<singleJump>();
        jumpItem = gameObject.GetComponent<singleJump>();
    }
    

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = camera.directionFacing();
        
        if ((Input.GetAxis("Vertical") > 0) && (ball.velocity.y < maxSpeed))
        {
            moveForwards(forward);
        }

        if ((Input.GetAxis("Vertical") < 0) && (ball.velocity.y > -maxSpeed))
        {
            moveBackwards(forward);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            turnRight();
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            turnLeft();
        }

        ball.AddForce(movement);
        movement = new Vector3(0, 0, 0);


        if (Input.GetKeyDown("space"))
        {
            jumpItem.buyJumpItem();
            jumpItem.useSingleJump(gameObject);
        }


    }



    private void moveForwards(Vector3 forward)
    {
        forward *= acceleration;
        movement = forward;
    }

    private void moveBackwards(Vector3 forward)
    {
        forward *= -acceleration;
        movement = forward;
    }
    public float torque;
    private void turnRight()
    {
        if (ball.angularVelocity.magnitude > -2)
        {
            ball.AddTorque(transform.up * torque, ForceMode.Force);
        }
        //ball.AddTorque(transform.up * torque, ForceMode.Force);

    }

    private void turnLeft()
    {
        if (ball.angularVelocity.magnitude < 2)
        {
            ball.AddTorque(-transform.up * torque, ForceMode.Force);
        }
    }




}
