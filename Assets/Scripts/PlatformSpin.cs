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
        //if (!spinning)
        //{
        //    StartCoroutine(Spin());
        //}

    }
        //IEnumerator Spin()
        //{
        //    spinning = true;
        //    int divisor;
        //    if (randomSpin)
        //        divisor = Random.Range(2, 8);
        //    else
        //        divisor = 1;

        //    Quaternion NewRotation = Quaternion.AngleAxis(180.0f / divisor, Vector3.up);

        //    float angle = Quaternion.Angle(NewRotation, Quaternion.identity);

        //    float angleDelta = angle / spinTime;
        //    float curangle = 0;

        //    while (curangle < angle)
        //    {
        //        curangle += angleDelta;
        //        transform.rotation = Quaternion.AngleAxis(curangle, Vector3.up);
        //        yield return null;
        //    }

        //    while (curangle > 0)
        //    {
        //        curangle -= angleDelta;
        //        transform.rotation = Quaternion.AngleAxis(curangle, Vector3.up);
        //        yield return null;
        //    }


        //    spinning = false;


        //}
}
