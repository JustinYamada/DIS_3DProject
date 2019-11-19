using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BouncyBoy : MonoBehaviour
{

    public float bounceforce = 3;
    public float speed = 2;
    public GameObject player;

    private NavMeshAgent agent;
    private Vector3 initialScale;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;
        rb.velocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision col)
    {
        Bounce(col);
    }

    void OnCollisionStay(Collision col)
    {
        //Bounce(col);
    }

    void Bounce(Collision col)
    {
        if (col != null && col.gameObject.tag == "Player")
        {
            var colContact = col.contacts[0];

            StartCoroutine(Thiccen());

            Vector3 relVel = col.relativeVelocity;
            Vector3 vel = col.rigidbody.velocity;
            Vector3 newDir;

            if (relVel.magnitude < 3)
            {
               print("low mag");
                relVel.x += relVel.x < 0 ? -3 : 3;
                relVel.y += relVel.y < 0 ? -3 : 3;


               relVel *= 3;
               newDir = Vector3.Reflect(relVel, colContact.normal);

            }
            else
            {
                print("high mag");
                newDir = Vector3.Reflect(relVel, colContact.normal);
            }
            newDir.y = 0;

            col.rigidbody.velocity = newDir * bounceforce;
        }
    }

    IEnumerator Thiccen()
    {
        transform.localScale *= 1.1f;

        for(int i = 0; i < 3; i++)
            yield return null;

        transform.localScale = initialScale;
    }
}
