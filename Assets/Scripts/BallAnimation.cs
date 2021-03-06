﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAnimation : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject ballMonkey;
    public GameObject actualBall;
    private Animator monkeyAnimator;
    public int runVelocity;
    public int walkVelocity;
    private Vector3 sphereRotation = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        rb = actualBall.GetComponent<Rigidbody>();
        monkeyAnimator = ballMonkey.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rb.velocity.x +" || "+ rb.velocity.z + " || " );
        /*Vector3.RotateTowards(sphereRotation,rb.velocity,Mathf.Infinity, Mathf.Infinity);
        gameObject.transform.Rotate(sphereRotation);*/
        if (rb.velocity.magnitude > runVelocity)
        {
            monkeyAnimator.SetBool("isMovingFast", true);
        }
        else if (rb.velocity.magnitude > walkVelocity)
        {
            monkeyAnimator.SetBool("isMoving", true);
            if (rb.velocity.magnitude < runVelocity)
            {
                monkeyAnimator.SetBool("isMovingFast", false);
            }
        }
        else
        {
            monkeyAnimator.SetBool("isMoving", false);
        }
    }
}
