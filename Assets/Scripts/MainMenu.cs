using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject MainMenuUI;
    public GameObject levelLoaderUI;


    private void Start()
    {
        singletonGameManager.Instance.loadEverything();
        showMainMenu();
    }

    public void PlayGame()
    {
        singletonGameManager.Instance.saveEverything();
        SceneManager.LoadScene(singletonGameManager.Instance.highestLevelReached);
    }

    public void QuitGame()
    {
        singletonGameManager.Instance.saveEverything();
        Application.Quit();
        Debug.Log("Quitted");
    }

    public void loadStore()
    {
        singletonGameManager.Instance.saveEverything();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void loadLevelsUI()
    {
        MainMenuUI.SetActive(false);
        levelLoaderUI.SetActive(true);
    }

    public void showMainMenu()
    {
        MainMenuUI.SetActive(true);
        levelLoaderUI.SetActive(false);
    }

    public void loadLevel(int num)
    {
        if (num <= singletonGameManager.Instance.highestLevelReached)
        {
            singletonGameManager.Instance.saveEverything();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + num);
        }
        else
        {
            print("Haven't reached that level yet, someone needs to handle this");
        }
    }
    


}
