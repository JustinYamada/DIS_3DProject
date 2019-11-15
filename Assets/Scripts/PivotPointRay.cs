using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotPointRay : MonoBehaviour
{
    public GameObject daddyball;

    private Quaternion initRot;


    /* OK OWEN THIS IS WHAT YOU'RE GONNA DO WHEN YOU OPEN THIS AGAIN.
     * FIRST YOU DONT NEED A SILLY CHILD, RAYCAST FROM THE BALL, THE RAYCAST DIRECTION
     * SHOULD BE THE VECTOR OF THE DIRECTION FROM THE BALL (WHERE EVER THE POINT OF RAY OUTPUT IS) 
     * TO THE GROUND / DOWN DIRECTION. Whether this be down all the time or towards the nearest plane who knows
     * downward all the time would probably be ideal so get that vector, raycast that way and then hit up that point ez pz.
     */
   
    void Start()
    {
        initRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = initRot;
    }
}
