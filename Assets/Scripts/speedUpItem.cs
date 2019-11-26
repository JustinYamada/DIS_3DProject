using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedUpItem : MonoBehaviour
{

    public float speedMultiplier = 2;

    public float speedDuration = 5;
    public float numSpeedItems = 0;



    public float speedItemLevel = 1;
    public float speedItemLevelIncrease = 1.5f;

    private bool isSpeeding;
    mattBallController accelerator;



    public void useSpeedItem(GameObject player)
    {
        StartCoroutine(Speed(player));
    }


    IEnumerator Speed(GameObject player)
    {

        if ((numSpeedItems > 0) && (!isSpeeding))
        {
            accelerator = player.GetComponent<mattBallController>();
            accelerator.acceleration *= (speedMultiplier + (speedItemLevel * speedItemLevelIncrease));
            accelerator.maxSpeed *= (speedMultiplier + (speedItemLevel * speedItemLevelIncrease));
            isSpeeding = true;
            numSpeedItems--;
        }
        yield return new WaitForSeconds(speedDuration);
        isSpeeding = false;
        accelerator.acceleration /= (speedMultiplier + (speedItemLevel * speedItemLevelIncrease));
        accelerator.maxSpeed /= (speedMultiplier + (speedItemLevel * speedItemLevelIncrease));

    }

    public void buySpeedItem()
    {
        numSpeedItems++;
    }

    public void buySpeedItem(int numItems)
    {
        numSpeedItems += numItems;
    }

    public void levelUpSpeed()
    {
        speedItemLevel++;
    }

    public int resetSpeedLevel()
    {
        int levelsReturned = (int)speedItemLevel;
        speedItemLevel = 0;
        return levelsReturned;
    }

    public void levelUpSpeedDuration()
    {
        speedDuration++;
    }

    public int resetSpeedDuration()
    {
        int levelsReturned = (int)speedItemLevel;
        speedDuration = 5;
        return (levelsReturned - 5);
    }


}
