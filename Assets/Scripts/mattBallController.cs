using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class mattBallController : MonoBehaviour
{
    public float maxSpeed = 500;

    public float acceleration;


    private Vector3 movement;

    private Rigidbody ball;

    public followBall camera;

    singleJump jumpItem;
    speedUpItem speedItem;
    PhaseItem phaseItem;

    public bool onGround = true;


    public float selectedIndex = 0;



    public float torque = .25f;

    private float verticalInput = 0f;
    private float horizontalInput = 0f;


    /*
     * LOOK INTO SEPHAMORE WAIT FOR SIGNAL
     * WHY DOES IT HAVE A 95 Millesecond processing time. It is in other in the profiler on the cpu usage
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     */




    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        gameObject.AddComponent<singleJump>();
        jumpItem = gameObject.GetComponent<singleJump>();
        gameObject.AddComponent<speedUpItem>();
        speedItem = gameObject.GetComponent<speedUpItem>();
        gameObject.AddComponent<PhaseItem>();
        phaseItem = gameObject.GetComponent<PhaseItem>();
    }
    

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = camera.directionFacing();

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        if ((verticalInput > 0) && (ball.velocity.z < maxSpeed) && (ball.velocity.x < maxSpeed))
        {
            moveForwards(forward);
        }

        else if ((verticalInput < 0) && (ball.velocity.z > -maxSpeed) && (ball.velocity.x > -maxSpeed))
        {
            moveBackwards(forward);
        }

        if (horizontalInput > 0)
        {
            turnRight();
        }

        else if (horizontalInput < 0)
        {
            turnLeft();
        }

        ball.AddForce(movement);
        movement = new Vector3(0, 0, 0);

        if ((Input.GetKeyDown(KeyCode.Keypad1)) || (Input.GetKeyDown(KeyCode.Alpha1)))
        {
            selectedIndex = 0;
        }
        else if ((Input.GetKeyDown(KeyCode.Keypad2)) || (Input.GetKeyDown(KeyCode.Alpha2)))
        {
            selectedIndex = 1;
        }
        else if ((Input.GetKeyDown(KeyCode.Keypad3)) || (Input.GetKeyDown(KeyCode.Alpha3)))
        {
            selectedIndex = 2;
        }
        else if ((Input.GetKeyDown(KeyCode.Keypad4)) || (Input.GetKeyDown(KeyCode.Alpha4)))
        {
            selectedIndex = 3;
        }
        else if ((Input.GetKeyDown(KeyCode.Keypad5)) || (Input.GetKeyDown(KeyCode.Alpha5)))
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
                    phaseItem.buyPhaseItem();
                    phaseItem.useSinglePhase(gameObject);
                    break;
                case 4:
                    print("Item 5");
                    break;
                case 5:
                    print("Item 6");
                    break;
            }

        }
    }



    private void moveForwards(Vector3 forward)
    {
        if (Time.unscaledDeltaTime != 0)
        {
            forward *= acceleration * Time.unscaledDeltaTime;
        }
        else
        {
            forward *= acceleration;
        }
        movement = forward;
    }

    private void moveBackwards(Vector3 forward)
    {
        if (Time.unscaledDeltaTime != 0)
        {
            forward *= -acceleration * Time.unscaledDeltaTime;
        }
        else
        {
            forward *= -acceleration;
        }
        movement = forward;
    }
    private void turnRight()
    {
        if (ball.angularVelocity.magnitude > -2)
        {
            ball.AddTorque(transform.up * torque, ForceMode.Force);
        }
    }

    private void turnLeft()
    {
        if (ball.angularVelocity.magnitude < 2)
        {
            ball.AddTorque(-transform.up * torque, ForceMode.Force);
        }
    }


    public void pauseTime()
    {
        Time.timeScale = 1f;
        print("paused");
    }
    public void unPauseTime()
    {
        Time.timeScale = 0f;
        print("Unpaused");
    }



}
