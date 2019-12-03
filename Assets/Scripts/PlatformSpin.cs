using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpin : MonoBehaviour
{
    public float spinForce = 1.0f;


    [Tooltip("Enter 0 for x, 1 for y, 2 for z")]
    public int spinAxis = 0;


    private Rigidbody rb;
    private float origSpinForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        origSpinForce = spinForce;
    }

    // Update is called once per frame
    void Update()
    {
        spinForce = origSpinForce * singletonGameManager.Instance.slowTimeMagnitude;

        if (spinAxis == 0)
        {
            rb.angularVelocity = new Vector3(spinForce, 0, 0);
            rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePosition;
        }
        else if (spinAxis == 1)
        {
            rb.angularVelocity = new Vector3(0, spinForce, 0);
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePosition;

        }
        else if (spinAxis == 2)
        {
            rb.angularVelocity = new Vector3(0, 0, spinForce);
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePosition; 

        }
        else
        {
            rb.angularVelocity = new Vector3(20, 20, 20);
            print("Invalid spinAxis value! Change it to 0, 1 or 2!");
        }
    }

    void OnCollisionStay(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            //col.transform.rotation = transform.rotation;
            //col.rigidbody.angularVelocity = new Vector3(spinForce, 0, 0);
        }
    }

}
