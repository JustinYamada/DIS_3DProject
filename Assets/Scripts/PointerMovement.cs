using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerMovement : MonoBehaviour
{
    public GameObject[] itemArray;
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
        if (Input.GetKeyDown("a") && itemIndex != 0)
        {
            itemIndex -= 1;
            Vector3 itemPos = itemArray[itemIndex].transform.position;
            gameObject.transform.position = new Vector3(itemPos.x,itemPos.y + itemArray[itemIndex].GetComponent<RotatorShop>().pointerY, itemPos.z);
        }

        if (Input.GetKeyDown("d") && itemIndex != itemArray.GetLength(0)-1)
        {
            itemIndex += 1;
            Vector3 itemPos = itemArray[itemIndex].transform.position;
            gameObject.transform.position = new Vector3(itemPos.x, itemPos.y + itemArray[itemIndex].GetComponent<RotatorShop>().pointerY, itemPos.z);
        }
    }
}
