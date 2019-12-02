using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedUpItem : MonoBehaviour
{

    public float speedMultiplier = 2;

    public float speedDuration = 5;

    public float speedItemLevelIncrease = 1.5f;

    private bool isSpeeding;
    mattBallController accelerator;



    public void useSpeedItem(GameObject player)
    {
        StartCoroutine(Speed(player));
    }


    IEnumerator Speed(GameObject player)
    {

        if ((singletonGameManager.Instance.numSpeedItem > 0) && (!isSpeeding))
        {
            accelerator = player.GetComponent<mattBallController>();
            accelerator.acceleration *= (speedMultiplier + (singletonGameManager.Instance.speedItemLevel * speedItemLevelIncrease));
            accelerator.maxSpeed *= (speedMultiplier + (singletonGameManager.Instance.speedItemLevel * speedItemLevelIncrease));
            isSpeeding = true;
            singletonGameManager.Instance.numSpeedItem--;
        }
        yield return new WaitForSeconds(speedDuration + singletonGameManager.Instance.speedItemLevel);
        isSpeeding = false;
        accelerator.acceleration /= (speedMultiplier + (singletonGameManager.Instance.speedItemLevel * speedItemLevelIncrease));
        accelerator.maxSpeed /= (speedMultiplier + (singletonGameManager.Instance.speedItemLevel * speedItemLevelIncrease));

    }

    public void buySpeedItem()
    {
        singletonGameManager.Instance.buySpeedItems(1);
    }

    public void buySpeedItem(int numItems)
    {
        singletonGameManager.Instance.buySpeedItems(numItems);
    }

 //   public void levelUpSpeed()
 //   {
 //       singletonGameManager.Instance.levelUpSpeedItem(1);
 //   }

//    public void resetSpeedLevel()
//    {
//        singletonGameManager.Instance.resetSpeedItemLevel();
//    }

    public void levelUpSpeedDuration(int numLevels)
    {
        singletonGameManager.Instance.levelUpSpeedItem(numLevels);
    }

    public void resetSpeedDuration()
    {
        singletonGameManager.Instance.resetSpeedItemLevel();
    }


}
