using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{
    public float speed = 2;
    public GameObject player;

    private NavMeshAgent agent;
    private float origSpeed;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        origSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        speed = origSpeed * singletonGameManager.Instance.slowTimeMagnitude;
        agent.speed = speed;
        agent.destination = player.transform.position;
    }
}
