using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject ball;
    public GameObject shopCanvas;

    // Update is called once per frame

    private void Start()
    {
        Resume();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Resume()
    {
        if (ball != null)
        {
            ball.GetComponent<mattBallController>().unPauseTime();
        }
        if (shopCanvas != null)
        {
            shopCanvas.SetActive(true);
        }
        if (pauseMenuUI != null)
        {
           pauseMenuUI.SetActive(false);
        }
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        if (ball != null)
        {
            ball.GetComponent<mattBallController>().pauseTime();
        }
        if (shopCanvas != null)
        {
            shopCanvas.SetActive(false);
        }
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
        }
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void LoadMenu()
    {
        singletonGameManager.Instance.saveEverything();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        singletonGameManager.Instance.saveEverything();
        Application.Quit();
        Debug.Log("Quitted");
    }

    public void reloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        singletonGameManager.Instance.saveEverything();
        SceneManager.LoadScene(scene.name);
    }




}
