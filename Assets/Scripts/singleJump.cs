using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleJump : MonoBehaviour
{

    public float jumpHeight = 5;
    public float numJumps = 0;

    private mattBallController monkeyBall;

    public void useSingleJump(GameObject player)
    {
        if ((numJumps > 0) && (monkeyBall.ballOnGround()))
        {
            Vector3 jump = new Vector3(0, jumpHeight, 0);
            Rigidbody ball = player.GetComponent<Rigidbody>();
            ball.AddForce(jump);
            numJumps--;
        }
    }


}
