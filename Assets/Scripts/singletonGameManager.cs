using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singletonGameManager : MonoBehaviour
{
    private static singletonGameManager instance = null;
    

    public bool isLoaded = false;

    public int highestLevelReached = 1;


    public int numFruit;


    public int numSpeedItem = 0;
    public int speedItemLevel = 1;
    public int speedItemUpgradePrice;
    public int speedItemPrice;
    


    public int numJumpItem = 0;
    public int jumpItemLevel = 1;
    public int jumpItemUpgradePrice;
    public int jumpItemPrice;


    public int numPhaseItem = 0;
    public int phaseItemLevel = 1;
    public int phaseItemUpgradePrice;
    public int phaseItemPrice;


    public int numSlowItem = 0;
    public int slowItemLevel = 1;
    public int slowItemUpgradePrice;
    public int slowItemPrice;
    public float slowTimeMagnitude = 1.0f;

    public int[] scores = new int[8];



    public static singletonGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<singletonGameManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "SingletonController";
                    instance = go.AddComponent<singletonGameManager>();
                    singletonGameManager.instance.loadEverything();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int getNumFruit()
    {
        return numFruit;
    }


    public int getNumSpeedItems()
    {
        return numSpeedItem;
    }

    public int getSpeedItemLevel()
    {
        return speedItemLevel;
    }
    public bool levelUpSpeedItem(int numLevels)
    {
        if ((speedItemUpgradePrice * numLevels) < numFruit)
        {
            numFruit -= (numLevels * speedItemUpgradePrice);
            return true;
        }
        return false;
    }
    public void resetSpeedItemLevel()
    {
        numFruit += (speedItemUpgradePrice * (speedItemLevel - 1));
        speedItemLevel = 1;
    }
    public bool buySpeedItems(int numItems)
    {
        if (numItems * speedItemPrice < numFruit)
        {
            numFruit -= (numItems * speedItemPrice);
            return true;
        }
        return false;
    }






    public int getNumJumpItems()
    {
        return numJumpItem;
    }

    public int getJumpItemLevel()
    {
        return jumpItemLevel;
    }
    public bool levelUpJumpItem(int numLevels)
    {
        if ((jumpItemUpgradePrice * numLevels) < numFruit)
        {
            numFruit -= (numLevels * jumpItemUpgradePrice);
            return true;
        }
        return false;
    }
    public void resetJumpItemLevel()
    {
        numFruit += (jumpItemUpgradePrice * (jumpItemLevel - 1));
        jumpItemLevel = 1;
    }

    public bool buyJumpItem(int numItems)
    {
        if (numItems * jumpItemPrice < numFruit)
        {
            numFruit -= (numItems * jumpItemPrice);
            return true;
        }
        return false;
    }




    public int getNumPhaseItems()
    {
        return numPhaseItem;
    }

    public int getPhaseItemLevel()
    {
        return phaseItemLevel;
    }

    public bool levelUpPhaseItem(int numLevels)
    {
        if ((phaseItemUpgradePrice * numLevels) < numFruit)
        {
            numFruit -= (numLevels * phaseItemUpgradePrice);
            return true;
        }
        return false;
    }
    public void resetPhaseItemLevel()
    {
        numFruit += (phaseItemUpgradePrice * (phaseItemLevel - 1));
        phaseItemLevel = 1;
    }

    public bool buyPhaseItem(int numItems)
    {
        if (numItems * numPhaseItem < numFruit)
        {
            numFruit -= (numItems * numPhaseItem);
            return true;
        }
        return false;
    }



    public int getNumSlowItems()
    {
        return numSlowItem;
    }

    public int getSlowItemLevel()
    {
        return slowItemLevel;
    }

    public bool levelUpSlowItem(int numLevels)
    {
        if ((slowItemUpgradePrice * numLevels) < numFruit)
        {
            numFruit -= (numLevels * slowItemUpgradePrice);
            return true;
        }
        return false;
    }
    public void resetSlowItemLevel()
    {
        numFruit += (slowItemUpgradePrice * (slowItemLevel - 1));
        slowItemLevel = 1;
    }

    public bool buySlowItem(int numItems)
    {
        if (numItems * numSlowItem < numFruit)
        {
            numFruit -= (numItems * numSlowItem);
            return true;
        }
        return false;
    }

    public void saveEverything()
    {
        PlayerPrefs.SetInt("highestLevelReached", highestLevelReached);
        PlayerPrefs.SetInt("numFruit", numFruit);
        PlayerPrefs.SetInt("numSpeedItem", numSpeedItem);
        PlayerPrefs.SetInt("speedItemLevel", speedItemLevel);
        PlayerPrefs.SetInt("numJumpItem", numJumpItem);
        PlayerPrefs.SetInt("jumpItemLevel", jumpItemLevel);
        PlayerPrefs.SetInt("numPhaseItem", numPhaseItem);
        PlayerPrefs.SetInt("phaseItemLevel", phaseItemLevel);
        PlayerPrefs.SetInt("numSlowItem", numSlowItem);
        PlayerPrefs.SetInt("slowItemLevel", slowItemLevel);

        PlayerPrefs.SetInt("score0", scores[0]);
        PlayerPrefs.SetInt("score1", scores[1]);
        PlayerPrefs.SetInt("score2", scores[2]);
        PlayerPrefs.SetInt("score3", scores[3]);
        PlayerPrefs.SetInt("score4", scores[4]);
        PlayerPrefs.SetInt("score5", scores[5]);
        PlayerPrefs.SetInt("score6", scores[6]);
        PlayerPrefs.SetInt("score7", scores[7]);
        PlayerPrefs.Save();
    }


    public void loadEverything()
    {
        if (!isLoaded)
        {
            if (hasKey("numFruit"))
            {
                numFruit = PlayerPrefs.GetInt("numFruit");
            }
            else
            {
                numFruit = 0;
            }
            if (hasKey("highestLevelReached"))
            {
                highestLevelReached = PlayerPrefs.GetInt("highestLevelReached");
            }
            else
            {
                highestLevelReached = 1;
            }
            if (hasKey("numSpeedItem"))
            {
                numSpeedItem = PlayerPrefs.GetInt("numSpeedItem");
            }
            else
            {
                numSpeedItem = 0;
            }
            if (hasKey("speedItemLevel"))
            {
                speedItemLevel = PlayerPrefs.GetInt("speedItemLevel");
            }
            else
            {
                speedItemLevel = 1;
            }
            if (hasKey("numJumpItem"))
            {
                numJumpItem = PlayerPrefs.GetInt("numJumpItem");
            }
            else
            {
                numJumpItem = 0;
            }
            if (hasKey("jumpItemLevel"))
            {
                jumpItemLevel = PlayerPrefs.GetInt("jumpItemLevel");
            }
            else
            {
                jumpItemLevel = 1;
            }
            if (hasKey("numPhaseItem"))
            {
                numPhaseItem = PlayerPrefs.GetInt("numPhaseItem");
            }
            else
            {
                numPhaseItem = 0;
            }
            if (hasKey("phaseItemLevel"))
            {
                phaseItemLevel = PlayerPrefs.GetInt("phaseItemLevel");
            }
            else
            {
                phaseItemLevel = 1;
            }
            if (hasKey("numSlowItem"))
            {
                numSlowItem = PlayerPrefs.GetInt("numSlowItem");
            }
            else
            {
                numSlowItem = 0;
            }
            if (hasKey("slowItemLevel"))
            {
                slowItemLevel = PlayerPrefs.GetInt("slowItemLevel");
            }
            else
            {
                slowItemLevel = 1;
            }
            if (hasKey("score0"))
            {
                scores[0] = PlayerPrefs.GetInt("score0");
            }
            else
            {
                scores[0] = 0;
            }
            if (hasKey("score1"))
            {
                scores[1] = PlayerPrefs.GetInt("score1");
            }
            else
            {
                scores[1] = 0;
            }
            if (hasKey("score2"))
            {
                scores[2] = PlayerPrefs.GetInt("score2");
            }
            else
            {
                scores[2] = 0;
            }
            if (hasKey("score3"))
            {
                scores[3] = PlayerPrefs.GetInt("score3");
            }
            else
            {
                scores[3] = 0;
            }
            if (hasKey("score4"))
            {
                scores[4] = PlayerPrefs.GetInt("score4");
            }
            else
            {
                scores[4] = 0;
            }
            if (hasKey("score5"))
            {
                scores[5] = PlayerPrefs.GetInt("score5");
            }
            else
            {
                scores[5] = 0;
            }
            if (hasKey("score6"))
            {
                scores[6] = PlayerPrefs.GetInt("score6");
            }
            else
            {
                scores[6] = 0;
            }
            if (hasKey("score7"))
            {
                scores[7] = PlayerPrefs.GetInt("score7");
            }
            else
            {
                scores[7] = 0;
            }
        }
    }

    public bool hasKey(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return true;
        }
        return false;
    }
}
