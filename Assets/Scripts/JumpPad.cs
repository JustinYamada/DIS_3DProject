    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{

    public float jumpForce = 750;
    public float jumpCoolDown = 4;

    private bool justJumped = false;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Jump(collision));
        }
    }

    IEnumerator Jump(Collision player)
    {
        if (!justJumped)
        {
            justJumped = true;
            Rigidbody ball = player.gameObject.GetComponent<Rigidbody>();
            ball.AddForce(0, jumpForce, 0);
            yield return new WaitForSeconds(jumpCoolDown);
            justJumped = false;
        }
    }

    }
