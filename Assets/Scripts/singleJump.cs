using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleJump : MonoBehaviour
{

    public float jumpHeight = 500;
    public float jumpCoolDown = 4;


    public float jumpLevelIncrease = 50;

    public bool isJumping = false;

    public void useSingleJump(GameObject player)
    {
        StartCoroutine(Jump(player));
    }

    IEnumerator Jump(GameObject player)
    {
        if ((singletonGameManager.Instance.numJumpItem > 0) && (!isJumping))
        {
            isJumping = true;
            Vector3 jump = new Vector3(0, (jumpHeight + (singletonGameManager.Instance.jumpItemLevel * jumpLevelIncrease)), 0);
            Rigidbody ball = player.GetComponent<Rigidbody>();
            ball.AddForce(jump);
            singletonGameManager.Instance.numJumpItem--;
        }
        yield return new WaitForSeconds(jumpCoolDown);
        isJumping = false;
    }

    public void buyJumpItem()
    {
        singletonGameManager.Instance.buyJumpItem(1);
    }

    public void buyJumpItem(int numItems)
    {
        singletonGameManager.Instance.buyJumpItem(numItems);
    }

    public void levelUpJump(int numLevels)
    {
        singletonGameManager.Instance.levelUpJumpItem(numLevels);
    }

    public void resetJumpLevel()
    {
        singletonGameManager.Instance.resetJumpItemLevel();
    }


}
