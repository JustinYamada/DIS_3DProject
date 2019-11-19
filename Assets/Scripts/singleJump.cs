using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleJump : MonoBehaviour
{

    public float jumpHeight = 500;
    public float jumpCoolDown = 4;
    public float numJumps = 0;

    private bool isJumping = false;

    public void useSingleJump(GameObject player)
    {
        StartCoroutine(Jump(player));
    }

    IEnumerator Jump(GameObject player)
    {
        if ((numJumps > 0) && (!isJumping))
        {
            isJumping = true;
            Vector3 jump = new Vector3(0, jumpHeight, 0);
            Rigidbody ball = player.GetComponent<Rigidbody>();
            ball.AddForce(jump);
            numJumps--;
        }
        yield return new WaitForSeconds(jumpCoolDown);
        isJumping = false;
    }

        public void buyJumpItem()
    {
        numJumps++;
    }


}
