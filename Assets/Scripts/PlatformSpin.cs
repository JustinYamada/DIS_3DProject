using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpin : MonoBehaviour
{
    public float spinForce = 10;

    private bool spinning;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        spinning = false;
        rb = GetComponent<Rigidbody>();

        rb.AddTorque(transform.up * spinForce * 1000, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
