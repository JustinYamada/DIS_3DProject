using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFruit : MonoBehaviour
{

    private singletonGameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = singletonGameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            gm.numFruit += 1;
            Destroy(gameObject);
        }
    }
}
