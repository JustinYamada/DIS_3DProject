using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followBall : MonoBehaviour
{

    public GameObject player;

    private Vector3 _offset;

    void Start()
    {
        _offset = new Vector3(0, 3, -4);    //just put the values that you want instead of y and z
    }

    void FixedUpdate()
    {
        Vector3 flatSpeed = player.GetComponent<Rigidbody>().velocity;
        flatSpeed.y = 0;

        Quaternion wantedRotation = new Quaternion();

        if (flatSpeed != Vector3.zero)
        {
            float targetAngle = Quaternion.LookRotation(flatSpeed).eulerAngles.y;
            wantedRotation = Quaternion.Euler(0, targetAngle, 0);
        }

        transform.position = player.transform.position + (wantedRotation * _offset);
        transform.LookAt(player.transform);
    }



    public Vector3 directionFacing()
    {
        return transform.forward;
    }

}
