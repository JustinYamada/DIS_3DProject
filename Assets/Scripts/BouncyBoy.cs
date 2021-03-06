﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BouncyBoy : MonoBehaviour
{

    public float bounceforce = 3;
    public bool changeScale = false;
    public bool playerChaser = false;

    private Vector3 initialScale;
    private Rigidbody rb;
    public AudioClip bounceSound;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if(rb != null)
            rb.velocity = Vector3.zero;


        if(playerChaser)
        {
            Vector3 lp = transform.localPosition;
            lp.x = -0.5f;
            lp.y = 0.0f;
            lp.z = 0.5f;
            transform.localPosition = lp;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Bounce(col);
    }

    void Bounce(Collision col)
    {
        if (col != null && col.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(bounceSound, transform.position);
            var colContact = col.contacts[0];

            if(changeScale)
                StartCoroutine(Thiccen());

            Vector3 relVel = col.relativeVelocity;
            Vector3 vel = col.rigidbody.velocity;
            Vector3 newDir;

            if (relVel.magnitude < 3)
            {
                relVel.x += relVel.x < 0 ? -3 : 3;
                relVel.y += relVel.y < 0 ? -3 : 3;


               relVel *= 3;
               newDir = Vector3.Reflect(relVel, colContact.normal);

            }
            else
            {
                newDir = Vector3.Reflect(relVel, colContact.normal);
            }
            newDir.y = 0;

            col.rigidbody.velocity = newDir * (bounceforce / 1);
        }
    }

    IEnumerator Thiccen()
    {
        transform.localScale *= 1.5f;

        for(int i = 0; i < 3; i++)
            yield return null;

        transform.localScale = initialScale;
    }
}
