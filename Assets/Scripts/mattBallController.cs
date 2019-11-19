using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class mattBallController : MonoBehaviour
{
    public float maxSpeed = 500;

    public float acceleration;


    private float currentAccel;
    private Vector3 movement;

    private Rigidbody ball;

    public followBall camera;

    singleJump jumpItem;
    speedUpItem speedItem;

    public bool onGround = true;


    public float selectedIndex = 0;

    private float highestSpeed = 10;




    // Start is called before the first frame update
    void Start()
    {
        currentAccel = 0;
        ball = GetComponent<Rigidbody>();
        gameObject.AddComponent<singleJump>();
        jumpItem = gameObject.GetComponent<singleJump>();
        gameObject.AddComponent<speedUpItem>();
        speedItem = gameObject.GetComponent<speedUpItem>();
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

        if ((Input.GetKeyDown(KeyCode.Keypad1)) || (Input.GetKeyDown(KeyCode.Alpha1)))
        {
            selectedIndex = 0;
        }
        if ((Input.GetKeyDown(KeyCode.Keypad2)) || (Input.GetKeyDown(KeyCode.Alpha2)))
        {
            selectedIndex = 1;
        }
        if ((Input.GetKeyDown(KeyCode.Keypad3)) || (Input.GetKeyDown(KeyCode.Alpha3)))
        {
            selectedIndex = 2;
        }
        if ((Input.GetKeyDown(KeyCode.Keypad4)) || (Input.GetKeyDown(KeyCode.Alpha4)))
        {
            selectedIndex = 3;
        }
        if ((Input.GetKeyDown(KeyCode.Keypad5)) || (Input.GetKeyDown(KeyCode.Alpha5)))
        {
            selectedIndex = 4;
        }


        



        if (Input.GetKeyDown("space"))
        {
            switch (selectedIndex)
            {
                case 0:
                    print("Jump");
                    jumpItem.buyJumpItem();
                    jumpItem.useSingleJump(gameObject);
                    break;
                case 1:
                    print("Speed Up");
                    speedItem.buySpeedItem();
                    speedItem.useSpeedItem(gameObject);
                    break;
                case 2:
                    print("Slow Time");
                    break;
                case 3:
                    print("Phase Through Obstacles");
                    break;
                case 4:
                    print("Item 5");
                    break;
                case 5:
                    print("Item 6");
                    break;
            }

        }

        //print("Acceleration: " + acceleration);
        
        if (ball.velocity.x > highestSpeed)
        {
            highestSpeed = ball.velocity.x;
            //print(highestSpeed);
        }

        if (ball.velocity.y > highestSpeed)
        {
            highestSpeed = ball.velocity.y;
            //print(highestSpeed);
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
