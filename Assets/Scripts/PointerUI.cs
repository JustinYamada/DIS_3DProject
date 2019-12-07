using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointerUI : MonoBehaviour
{
    public GameObject[] itemArray;
    private int itemIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 itemPos = itemArray[itemIndex].transform.position;
        gameObject.transform.position = new Vector3(itemPos.x - 0.03f, itemPos.y + itemArray[itemIndex].GetComponent<RotatorShop>().pointerY, itemPos.z - 0.15f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q") && itemIndex != 0)
        {
            itemIndex -= 1;
            Vector3 itemPos = itemArray[itemIndex].transform.position;
            gameObject.transform.position = new Vector3(itemPos.x - 0.03f, itemPos.y + itemArray[itemIndex].GetComponent<RotatorShop>().pointerY, itemPos.z - 0.15f);
        }

        if (Input.GetKeyDown("e") && itemIndex != itemArray.GetLength(0)-1)
        {
            itemIndex += 1;
            Vector3 itemPos = itemArray[itemIndex].transform.position;
            gameObject.transform.position = new Vector3(itemPos.x - 0.03f, itemPos.y + itemArray[itemIndex].GetComponent<RotatorShop>().pointerY, itemPos.z - 0.15f);
        }

        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            itemIndex = 0;
            Vector3 itemPos = itemArray[0].transform.position;
            gameObject.transform.position = new Vector3(itemPos.x - 0.03f, itemPos.y + itemArray[0].GetComponent<RotatorShop>().pointerY, itemPos.z - 0.15f);
        }

        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            itemIndex = 1;
            Vector3 itemPos = itemArray[1].transform.position;
            gameObject.transform.position = new Vector3(itemPos.x - 0.03f, itemPos.y + itemArray[1].GetComponent<RotatorShop>().pointerY, itemPos.z - 0.15f);
        }

        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            itemIndex = 2;
            Vector3 itemPos = itemArray[2].transform.position;
            gameObject.transform.position = new Vector3(itemPos.x - 0.03f, itemPos.y + itemArray[2].GetComponent<RotatorShop>().pointerY, itemPos.z - 0.15f);
        }

        if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            itemIndex = 3;
            Vector3 itemPos = itemArray[3].transform.position;
            gameObject.transform.position = new Vector3(itemPos.x - 0.03f, itemPos.y + itemArray[3].GetComponent<RotatorShop>().pointerY, itemPos.z - 0.15f);
        }
    }
}
