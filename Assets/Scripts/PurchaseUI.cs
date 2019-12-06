using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PurchaseUI : MonoBehaviour
{
    [HideInInspector] public GameObject purchaseObject;
    public TextMeshProUGUI purchaseText;
    public GameObject monkey;
    private Animator monkeyAnimator;

    private void Start()
    {
        monkeyAnimator = monkey.GetComponent<Animator>();

    }

    public void SetPurchaseObject(GameObject go)
    {
        purchaseObject = go;
    }
    // Start is called before the first frame update
    public void Buy()
    {
        if (purchaseObject.GetComponent<RotatorShop>().Buy(1))
        {
            monkeyAnimator.SetTrigger("ItemBought");
            purchaseText.text = "Thanks for your Business!";
        }
        else
        {
            monkeyAnimator.SetTrigger("Bored");
            purchaseText.text = "You don't have enough Bananas to purchase that...";
        }
    }

    public void Upgrade()
    {
        if (purchaseObject.GetComponent<RotatorShop>().Upgrade(1))
        {
            monkeyAnimator.SetTrigger("ItemBought");
            purchaseText.text = "Thanks for your Business!";
        }
        else
        {
            monkeyAnimator.SetTrigger("Bored");
            purchaseText.text = "You don't have enough Bananas to upgrade that...";
        }
    }

    public void X()
    {
        gameObject.SetActive(false);
    }
}
