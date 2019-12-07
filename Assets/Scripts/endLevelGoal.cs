using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class endLevelGoal : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex + 1 > singletonGameManager.Instance.highestLevelReached)
            {
                singletonGameManager.Instance.highestLevelReached = SceneManager.GetActiveScene().buildIndex + 1;
            }

            singletonGameManager.Instance.saveEverything();
            SceneManager.LoadScene(0);
            print("level is over");
        }
    }

}
