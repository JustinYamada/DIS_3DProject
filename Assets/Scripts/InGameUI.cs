using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{

    public GameObject player;
    public GameObject numBananas;
    private int bananaNum;
    public GameObject time;
    public GameObject Speed;
    private bool enabled;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        enabled = true;
        timer = 0;
        bananaNum = singletonGameManager.Instance.numFruit;
        numBananas.GetComponent<TMPro.TextMeshProUGUI>().text = singletonGameManager.Instance.numFruit + " Bananas";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            enabled = !enabled;
            gameObject.transform.GetChild(0).gameObject.SetActive(enabled);
        }

        timer += Time.unscaledDeltaTime;
        if (bananaNum != singletonGameManager.Instance.numFruit) {
            numBananas.GetComponent<TMPro.TextMeshProUGUI>().text = singletonGameManager.Instance.numFruit + " Bananas";
        }
        time.GetComponent<TMPro.TextMeshProUGUI>().text = System.Math.Round(timer, 1) + " seconds";
        Speed.GetComponent<TMPro.TextMeshProUGUI>().text = (int)player.GetComponent<Rigidbody>().velocity.magnitude + " mph";
    }
}
