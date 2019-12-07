using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float delta = 1.5f;  // Amount to move left and right from the start point
    public float speed = 2.0f;
    public float direction = 1;
    private Quaternion startPos;


    //Code taken from https://answers.unity.com/questions/1233082/swinging-object.html
    void Start()
    {
        startPos = transform.rotation;
    }
    void Update()
    {
        Quaternion a = startPos;
        a.x += (direction * (delta * Mathf.Sin(Time.time * speed)));
        transform.rotation = a;
    }

}
