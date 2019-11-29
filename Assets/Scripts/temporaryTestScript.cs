using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temporaryTestScript : MonoBehaviour
{
    TMPro.TextMeshProUGUI text;


    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Super Baboon Ball " + singletonGameManager.Instance.numFruit;
        print(text.text);
    }
}
