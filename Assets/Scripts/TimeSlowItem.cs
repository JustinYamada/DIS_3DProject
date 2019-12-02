using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlowItem : MonoBehaviour
{
    public float slowCoolDown = 10.0f;
    public float slowTimeDuration = 5.0f;

    private bool isSlow;

    // Start is called before the first frame update
    void Start()
    {
        isSlow = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TimeSlow()
    {
        if ((singletonGameManager.Instance.getNumSlowItems() > 0) && (!isSlow))
        {
            isSlow = true;
            print("slowed!");
            singletonGameManager.Instance.slowTimeMagnitude = 0.25f;
            singletonGameManager.Instance.numSlowItem--;
            yield return new WaitForSeconds(slowTimeDuration);
            singletonGameManager.Instance.slowTimeMagnitude = 1.0f;

        }
        yield return new WaitForSeconds(slowCoolDown);
        isSlow = false;
    }

    public void UseSlowItem()
    {
        StartCoroutine(TimeSlow());
    }

    public void BuySlowItem()
    {
        singletonGameManager.Instance.buySlowItem(1);
    }

    public void BuySlowItem(int numItems)
    {
        singletonGameManager.Instance.buySlowItem(numItems);
    }

    public void LevelUpSlow(int numLevels)
    {
        singletonGameManager.Instance.levelUpSlowItem(numLevels);
    }

    public void ResetSlowLevel()
    {
        singletonGameManager.Instance.resetSlowItemLevel();
    }
}
