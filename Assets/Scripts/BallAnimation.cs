using System.Collections;
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
    // Start is called before the first frame update
    void Start()
    {
        rb = actualBall.GetComponent<Rigidbody>();
        monkeyAnimator = ballMonkey.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity.x +" || "+ rb.velocity.z + " || " );
        gameObject.transform.up = new Vector3(rb.velocity.x/10, 0, rb.velocity.z/10);
        gameObject.transform.position = actualBall.transform.position;
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
