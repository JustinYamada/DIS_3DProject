using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followBall : MonoBehaviour
{

    public GameObject player;

    private Vector3 _offset;
    float offSetAngle = 0;


    public float distance = 10;
    //public float minVerticalAngle = -80;
    //public float maxVerticalAngle = 80;

    //public float verticalSpeed = 150;
    //public float horizontalSpeed = 300;

    public float angleX;
    private float angleY;



    void Start()
    {
        _offset = new Vector3(0, 3, -4);    //just put the values that you want instead of y and z
    }
    void Update()
    {
        //Vector3 flatSpeed = player.GetComponent<Rigidbody>().velocity;
        //flatSpeed.y = 0;

        //Quaternion wantedRotation = new Quaternion();

        //Vector3 minimum = new Vector3(.25f, .25f, .25f);


        //angleX += Input.GetAxis("Mouse Y") * Time.deltaTime * verticalSpeed;
        //angleY += Input.GetAxis("Horizontal") * Time.deltaTime * verticalSpeed;
        angleY = player.transform.eulerAngles.y;
        //angleX = Mathf.Clamp(angleX, minVerticalAngle, maxVerticalAngle);
        //angleY %= 360;

        Quaternion xRotation = Quaternion.AngleAxis(angleX, new Vector3(1, 0, 0));
        Quaternion yRotation = Quaternion.AngleAxis(angleY, new Vector3(0, 1, 0));
        Vector3 offset = new Vector3(0, 0, 1);
        offset = xRotation * offset;
        offset = yRotation * offset;
        offset *= distance;


        transform.position = player.transform.position + offset;
        transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position, new Vector3(0, 1, 0));






        //angle++;
        ////if ((flatSpeed.x > minimum.x) || (flatSpeed.y > minimum.y) || (flatSpeed.x < minimum.x) || (flatSpeed.y < minimum.y))
        //if ((flatSpeed != Vector3.zero) || (Input.GetAxis("Horizontal") != 0))
        //{
        //    float targetAngle = 0;


        //    targetAngle = Quaternion.LookRotation(flatSpeed).eulerAngles.y + offSetAngle;

        //    if (Input.GetAxis("Horizontal") > 0)
        //    {
        //        offSetAngle += .75f;
        //    }

        //    if (Input.GetAxis("Horizontal") < 0)
        //    {
        //        offSetAngle -= .75f;
        //    }

        //    targetAngle += offSetAngle;

        //    wantedRotation = Quaternion.Euler(0, targetAngle, 0);
        //}


       
        //transform.LookAt(player.transform);
        //transform.forward = Quaternion.AngleAxis(angle, player.transform.up) * (player.transform.position - transform.position);
        //transform.position = player.transform.position + (wantedRotation * _offset);
    }

    

    public Vector3 directionFacing()
    {
        Vector3 temp = Vector3.ProjectOnPlane(gameObject.transform.forward, Vector3.up).normalized;

        return temp;
    }

}
