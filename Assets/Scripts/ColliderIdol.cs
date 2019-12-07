using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderIdol : MonoBehaviour
{

    public GameObject red;
    public GameObject blue;
    public GameObject green;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("VVV");
        if (col.gameObject.tag == "MonkIdolRed")
        {
            Debug.Log("DDDDDDD");
            Destroy(col.gameObject);
            Destroy(red);
        }
        if (col.gameObject.tag == "MonkIdolBlue")
        {
            Destroy(col.gameObject);
            Destroy(blue);
        }
        if (col.gameObject.tag == "MonkIdolGreen")
        {
            Destroy(col.gameObject);
            Destroy(green);
        }
    }
}
