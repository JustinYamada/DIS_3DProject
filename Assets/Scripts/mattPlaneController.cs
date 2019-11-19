using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class mattPlaneController : MonoBehaviour
{

    public float maxAccel;

    public float acceleration;


    private float currentAccel;
    private Vector3 movement;

    private Rigidbody ball;


    // Start is called before the first frame update
    void Start()
    {
        currentAccel = 0;
        ball = GetComponent<Rigidbody>();
    }




    // Update is called once per frame
    void Update()
    {


        


        movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        movement *= acceleration;


        ball.AddForce(movement);

    }








}
