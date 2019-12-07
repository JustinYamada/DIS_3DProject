using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateItemQuantity : MonoBehaviour
{
    public TextMeshProUGUI jumpItemText;
    public TextMeshProUGUI speedItemText;
    public TextMeshProUGUI slowItemText;
    public TextMeshProUGUI phaseItemText;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        jumpItemText.text = "" + singletonGameManager.Instance.numJumpItem;
        speedItemText.text = "" + singletonGameManager.Instance.numSpeedItem;
        slowItemText.text = "" + singletonGameManager.Instance.numSlowItem;
        phaseItemText.text = "" + singletonGameManager.Instance.numPhaseItem;
    }
}
