using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BananaQuantityManager : MonoBehaviour
{
    public TextMeshProUGUI bananaQuantityText;
    // Start is called before the first frame update
    private void Update()
    {
        bananaQuantityText.text = "You have " + singletonGameManager.Instance.numFruit + " Bananas";
    }
}
