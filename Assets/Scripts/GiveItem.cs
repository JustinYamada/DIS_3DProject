using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveItem : MonoBehaviour
{
    public int[] items;

    // Start is called before the first frame update
    void Start()
    {
        if (items[0] != 0)
        {
            singletonGameManager.Instance.numJumpItem += items[0];
        }
        if (items[1] != 0)
        {
            singletonGameManager.Instance.numSpeedItem += items[1];
        }
        if (items[2] != 0)
        {
            singletonGameManager.Instance.numSlowItem += items[2];
        }
        if (items[3] != 0)
        {
            singletonGameManager.Instance.numPhaseItem += items[3];
        }
    }


}
