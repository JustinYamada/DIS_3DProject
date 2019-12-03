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

    public TextMeshProUGUI priceText;

    void Update()
    {
        transform.Rotate(new Vector3(xRotation, yRotation, zRotation) * Time.deltaTime);
    }

    private void Start()
    {
        if (itemId == 0)
        {
            priceText.text = singletonGameManager.instance.speedItemPrice + " \n Bananas";
        }
        else if (itemId == 1)
        {
            priceText.text = singletonGameManager.instance.phaseItemPrice + " \n Bananas";
        }
        else if (itemId == 2)
        {
            priceText.text = singletonGameManager.instance.slowItemPrice + " \n Bananas";
        }
        else
        {
            priceText.text = singletonGameManager.instance.jumpItemPrice + " \n Bananas";
        }
    }
}
