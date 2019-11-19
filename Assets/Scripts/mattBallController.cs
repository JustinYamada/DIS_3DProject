using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class mattBallController : MonoBehaviour
{
    public float maxAccel;

    public float acceleration;


    private float currentAccel;
    private Vector3 movement;

    private Rigidbody ball;

    followBall camera;


    // Start is called before the first frame update
    void Start()
    {
        currentAccel = 0;
        ball = GetComponent<Rigidbody>();
        camera = new followBall();
    }
    

    // Update is called once per frame
    void Update()
    {
        

        Vector3 forward = camera.directionFacing();

        
        movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        movement *= acceleration;
        ball.AddForce(movement);
    }

    private void moveFromDirection(Vector3 forward)
    {
        
    }


    private void moveForwards()
    {

    }

    private void moveBackwards()
    {

    }
    
    private void moveRight()
    {

    }

    private void moveLeft()
    {

    }



    public bool ballOnGround()
    {
        return true;
    }

}
