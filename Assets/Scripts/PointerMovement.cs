using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointerMovement : MonoBehaviour
{
    public GameObject[] itemArray;
    public TextMeshProUGUI purchaseText;
    public GameObject purchaseUI;
    private int itemIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 itemPos = itemArray[itemIndex].transform.position;
        gameObject.transform.position = new Vector3(itemPos.x, itemPos.y + itemArray[itemIndex].GetComponent<RotatorShop>().pointerY, itemPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("a") || Input.GetKeyDown(KeyCode.LeftArrow)) && itemIndex != 0)
        {
            itemIndex -= 1;
            Vector3 itemPos = itemArray[itemIndex].transform.position;
            gameObject.transform.position = new Vector3(itemPos.x,itemPos.y + itemArray[itemIndex].GetComponent<RotatorShop>().pointerY, itemPos.z);
        }

        if ((Input.GetKeyDown("d") || Input.GetKeyDown(KeyCode.RightArrow)) && itemIndex != itemArray.GetLength(0)-1)
        {
            itemIndex += 1;
            Vector3 itemPos = itemArray[itemIndex].transform.position;
            gameObject.transform.position = new Vector3(itemPos.x, itemPos.y + itemArray[itemIndex].GetComponent<RotatorShop>().pointerY, itemPos.z);
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space))
        {
            purchaseText.text = "Do you want to purchase the " + itemArray[itemIndex].name + " for " + itemArray[itemIndex].GetComponent<RotatorShop>().price + " Bananas? \n" +
                                "Or upgrade it for " + itemArray[itemIndex].GetComponent<RotatorShop>().upgradePrice + " Bananas?";

            //purchaseText.text = "Do you want to purchase the " + itemArray[itemIndex].name + " for " + 50 + " Bananas? \n" +
            //                    "Or upgrade it for " + 50 + " Bananas?";

            purchaseUI.SetActive(true);
        }
        purchaseUI.GetComponent<PurchaseUI>().SetPurchaseObject(itemArray[itemIndex]);


    }

    public void ChangeActivePurchaseUI()
    {
        purchaseUI.SetActive(!purchaseUI.active);
    }


}
