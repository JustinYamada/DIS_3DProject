using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotPointRay : MonoBehaviour
{

    public GameObject DaddyBall;
   
    private int layermask = 1 << 2;

    void Start()
    {
        layermask = ~layermask;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = DaddyBall.transform.position;

        Vector3 dir = transform.up * -1;

        RaycastHit hit;
        if(Physics.Raycast(transform.position, dir, out hit, Mathf.Infinity, layermask))
        {
            print(hit.point);
            Debug.DrawRay(transform.position, dir * hit.distance, Color.yellow);
        }


    }
}
