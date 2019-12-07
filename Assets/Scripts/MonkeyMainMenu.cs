using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonkeyMainMenu : MonoBehaviour
{
    public GameObject ballMonkey;
    public TextMeshProUGUI raymondText;
    private Animator monkeyAnimator;
    private ArrayList nameList = new ArrayList();
    public GameObject mainMenuMusic;
    public GameObject camera;
    public AudioClip ymcaSound;
    private bool yKeyPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        monkeyAnimator = ballMonkey.GetComponent<Animator>();
        monkeyAnimator.SetBool("isMoving", true);
        monkeyAnimator.SetBool("isMovingFast", true);
        nameList.Add("Raymond");
        nameList.Add("Rodderd");
        nameList.Add("Radford");
        nameList.Add("Redwood");
        nameList.Add("Leonard");
        nameList.Add("Rodlyn");
        nameList.Add("John");
        nameList.Add("Rick");
        nameList.Add("Ken");
        nameList.Add("Charlotte");
        nameList.Add("Twin Peaks");
        nameList.Add("Johan");
        nameList.Add("YMCA");
        nameList.Add("#UniteGameDev");
        nameList.Add("Baboon");
        nameList.Add("Monkey");
        nameList.Add("Owen");
        nameList.Add("Justin");
        nameList.Add("Matt");

        mainMenuMusic = GameObject.FindGameObjectWithTag("MainMenuSound");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            raymondText.text = (string) nameList[Random.Range(0, nameList.Count)];
        }

        if (Input.GetKeyDown("y"))
        {
            if(yKeyPressed != true)
            {
                yKeyPressed = true;
                mainMenuMusic.gameObject.SetActive(false);
                StartCoroutine(WaitCoroutine());
                AudioSource.PlayClipAtPoint(ymcaSound, camera.transform.position);
                raymondText.text = "YMCA";
                monkeyAnimator.SetTrigger("YMCA");
            }
            
        }
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(226.0f);
        mainMenuMusic.gameObject.SetActive(true);
        yKeyPressed = false;
    }
}

