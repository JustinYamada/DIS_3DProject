using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rb;
    public int xFor = 80;
    public int xBack = -60;
    public int yFor;
    public int yBack;
    public int zFor = 90;
    public int zBack = 90;
    private bool hasDone = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hasDone == false)
        {
            hasDone = true;
            StartCoroutine(WaitCoroutine());

            rb.velocity = new Vector3(xFor, yFor, zFor);
            rb.velocity = new Vector3(xBack, yBack, zBack);
        }

    }


    IEnumerator WaitCoroutine()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        
        yield return new WaitForSeconds(4);
        hasDone = false;


        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
