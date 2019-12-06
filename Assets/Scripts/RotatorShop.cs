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

    //XD
    void Update()
    {
        transform.Rotate(new Vector3(xRotation, yRotation, zRotation) * Time.deltaTime);
    }

    private void Start()
    {
        if (itemId == 0)
        {
            priceText.text = singletonGameManager.Instance.speedItemPrice + " \n Bananas";
        }
        else if (itemId == 1)
        {
            priceText.text = singletonGameManager.Instance.phaseItemPrice + " \n Bananas";
        }
        else if (itemId == 2)
        {
            priceText.text = singletonGameManager.Instance.slowItemPrice + " \n Bananas";
        }
        else
        {
            priceText.text = singletonGameManager.Instance.jumpItemPrice + " \n Bananas";
        }
    }
}
