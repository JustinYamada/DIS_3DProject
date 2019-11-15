using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamadaPlaneMover : MonoBehaviour
{
    public float speed = 60f;

    public GameObject ball;
    public GameObject plane;
    // Start is called before the first frame update
    void Start()
    {
        //ball = gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Vertical") > 0)
        {
            transform.localRotation *= Quaternion.AngleAxis(speed * Time.deltaTime, Vector3.left);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            transform.localRotation *= Quaternion.AngleAxis(-speed * Time.deltaTime, Vector3.left);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localRotation *= Quaternion.AngleAxis(speed * Time.deltaTime, Vector3.forward);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation *= Quaternion.AngleAxis(-speed * Time.deltaTime, Vector3.forward);
        }
        else
        {
            transform.localRotation *= Quaternion.AngleAxis(speed*2 * Time.deltaTime, Vector3.zero);
        }
    }
}
