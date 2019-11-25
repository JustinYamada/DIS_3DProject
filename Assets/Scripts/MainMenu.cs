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
        showMainMenu();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitted");
    }

    public void loadStore()
    {
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + num);
    }
    


}
