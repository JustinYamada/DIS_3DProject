using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTilt : MonoBehaviour
{
    public float tiltTime = 10;
    public bool TiltOnRightAxis = true;
    public bool alternateTilt = false;
    public bool randomTilt = false;

    public float tiltAngle = 45.0f;

    private bool tilting;
    private Vector3 tiltAxis;

    // Start is called before the first frame update
    void Start()
    {
        tilting = false;
        if(TiltOnRightAxis)
        {
            tiltAxis = Vector3.right;
        }
        else
        {
            tiltAxis = Vector3.left;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (TiltOnRightAxis)
            tiltAxis = Vector3.right;
        else
            tiltAxis = Vector3.forward;

        if (!tilting)
        {
            StartCoroutine(Tilt());
        }

    }

    IEnumerator Tilt()
    {
        tilting = true;
        int divisor;
        if (randomTilt)
            divisor = Random.Range(2, 8);
        else
            divisor = 1;

        Quaternion NewRotation = Quaternion.AngleAxis(tiltAngle / divisor, tiltAxis);

        float angle = Quaternion.Angle(NewRotation, Quaternion.identity);
        float angleDelta = angle / tiltTime;
        float curangle = 0;
        
        while(curangle < angle)
        {
            curangle += angleDelta;
            transform.rotation = Quaternion.AngleAxis(curangle, tiltAxis);
            yield return null;
        }

        while(curangle > 0)
        {
            curangle -= angleDelta;
            transform.rotation = Quaternion.AngleAxis(curangle, tiltAxis);
            yield return null;
        }

        if(alternateTilt)
            TiltOnRightAxis = !TiltOnRightAxis;

        tilting = false;
    }

}
