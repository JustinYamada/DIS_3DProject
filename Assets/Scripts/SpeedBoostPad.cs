using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPad : MonoBehaviour
{

    public float speedForce = 750;
    public float speedCoolDown = 4;

    private bool justSped = false;

    public GameObject camera;


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SpeedBoost(collision));
        }
    }

    IEnumerator SpeedBoost(Collision player)
    {
        followBall cameraForward = camera.GetComponent<followBall>();
        if (!justSped)
        {
            justSped = true;
            Rigidbody ball = player.gameObject.GetComponent<Rigidbody>();
            Vector3 forceDirection = cameraForward.directionFacing();
            forceDirection.x *= speedForce;
            forceDirection.z *= speedForce;
            forceDirection.y = 0;
            ball.AddForce(forceDirection);
            yield return new WaitForSeconds(speedCoolDown);
            justSped = false;
        }
    }



}
