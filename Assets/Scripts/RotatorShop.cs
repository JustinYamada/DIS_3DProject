using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RotatorShop : MonoBehaviour
{
    public int xRotation;
    public int yRotation;
    public int zRotation;
    public float pointerY;
    public int itemId;
    public int price;
    public int upgradePrice;

    public TextMeshProUGUI priceText;

    public void Update()
    {
        transform.Rotate(new Vector3(xRotation, yRotation, zRotation) * Time.deltaTime);
    }
    public void Start()
    {
        if (itemId == 0)
        {
           //price = singletonGameManager.Instance.speedItemPrice;
            //upgradePrice = singletonGameManager.Instance.speedItemUpgradePrice;
        }
        else if (itemId == 1)
        {
            //price = singletonGameManager.Instance.phaseItemPrice;
            //upgradePrice = singletonGameManager.Instance.phaseItemUpgradePrice;
        }
        else if (itemId == 2)
        {
            //price = singletonGameManager.Instance.slowItemPrice;
            //upgradePrice = singletonGameManager.Instance.slowItemUpgradePrice;
        }
        else
        {
            //price = singletonGameManager.Instance.jumpItemPrice;
           //upgradePrice = singletonGameManager.Instance.jumpItemUpgradePrice;
        }
        if (priceText != null)
        {
            priceText.text = price + " \n Bananas";
        }
    }

    public bool Buy(int num)
    {
        if (itemId == 0)
        {
            return singletonGameManager.Instance.buySpeedItems(num);
        }
        else if (itemId == 1)
        {
            return singletonGameManager.Instance.buyPhaseItem(num);
        }
        else if (itemId == 2)
        {
            return singletonGameManager.Instance.buySlowItem(num);
        }
        else
        {
            return singletonGameManager.Instance.buyJumpItem(num);
        }
    }

    public bool Upgrade(int num)
    {
        if (itemId == 0)
        {
            return singletonGameManager.Instance.levelUpSpeedItem(num);
        }
        else if (itemId == 1)
        {
            return singletonGameManager.Instance.levelUpPhaseItem(num);
        }
        else if (itemId == 2)
        {
            return singletonGameManager.Instance.levelUpSlowItem(num);
        }
        else
        {
            return singletonGameManager.Instance.levelUpJumpItem(num);
        }
    }
}
