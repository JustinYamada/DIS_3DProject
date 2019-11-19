using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedUpItem : MonoBehaviour
{

    public float speedMultiplier = 2;

    public float speedDuration = 5;
    public float numSpeedItems = 0;

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
            accelerator.acceleration *= speedMultiplier;
            accelerator.maxSpeed *= speedMultiplier;
            isSpeeding = true;
            numSpeedItems--;
        }
        yield return new WaitForSeconds(speedDuration + .5f);
        isSpeeding = false;
        accelerator.acceleration /= speedMultiplier;
        accelerator.maxSpeed /= speedMultiplier;

    }

    public void buySpeedItem()
    {
        numSpeedItems++;
    }


}
