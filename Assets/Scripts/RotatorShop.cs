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
    [HideInInspector] public int price;

    public TextMeshProUGUI priceText;

    public void Update()
    {
        transform.Rotate(new Vector3(xRotation, yRotation, zRotation) * Time.deltaTime);
    }
    public void Start()
    {


        if (itemId == 0)
        {
            price = singletonGameManager.Instance.speedItemPrice;
        }
        else if (itemId == 1)
        {
            price = singletonGameManager.Instance.phaseItemPrice;
        }
        else if (itemId == 2)
        {
            price = singletonGameManager.Instance.slowItemPrice;
        }
        else
        {
            price = singletonGameManager.Instance.jumpItemPrice;
        }
        priceText.text = price + " \n Bananas";
    }

    public void Buy(int num)
    {
        if (itemId == 0)
        {
            singletonGameManager.Instance.buySpeedItems(num);
        }
        else if (itemId == 1)
        {
            singletonGameManager.Instance.buyPhaseItem(num);
        }
        else if (itemId == 2)
        {
            singletonGameManager.Instance.buySlowItem(num);
        }
        else
        {
            singletonGameManager.Instance.buyJumpItem(num);
        }
    }

    public void Upgrade(int num)
    {
        if (itemId == 0)
        {
            singletonGameManager.Instance.levelUpSpeedItem(num);
        }
        else if (itemId == 1)
        {
            singletonGameManager.Instance.levelUpPhaseItem(num);
        }
        else if (itemId == 2)
        {
            singletonGameManager.Instance.levelUpSlowItem(num);
        }
        else
        {
            singletonGameManager.Instance.levelUpJumpItem(num);
        }
    }
}
