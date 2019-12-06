using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPointer : MonoBehaviour
{
    public GameObject goal;


    private Vector3 initRight; 

    // Start is called before the first frame update
    void Start()
    {
        initRight = transform.right;


    }

    // Update is called once per frame
    void Update()
    {
        //Vector3.MoveTowards(transform.position, goal.transform.position, 0);

        transform.right = Vector3.zero;
        transform.up = goal.transform.position - transform.position;
        //transform.LookAt(goal.transform, transform.right);


    }
}
