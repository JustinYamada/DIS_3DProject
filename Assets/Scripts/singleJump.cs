using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleJump : MonoBehaviour
{

    public float jumpHeight = 500;
    public float jumpCoolDown = 4;
    public float numJumps = 0;

    public float jumpLevel = 1;
    public float jumpLevelIncrease = 50;

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
            Vector3 jump = new Vector3(0, (jumpHeight + (jumpLevel * jumpLevelIncrease)), 0);
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

    public void buyJumpItem(int numItems)
    {
        numJumps += numItems;
    }

    public void levelUpJump()
    {
        jumpLevel++;
    }

    public int resetJumpLevel()
    {
        int levelsReturned = (int)jumpLevel;
        jumpLevel = 1;
        return levelsReturned - 1;
    }


}
