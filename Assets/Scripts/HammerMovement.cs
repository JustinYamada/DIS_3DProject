using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rb;
    public int xRot;
    public int yRot;
    public int zRot = 90;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0,0,1);
    }
}
