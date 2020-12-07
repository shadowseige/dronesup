using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        FindObjectOfType<CamSwitch>().isFPPOn = false;
        Collectible.collectScore = 0;
        Collectible.countCollect = 0;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        FindObjectOfType<CamSwitch>().isFPPOn = false;
        //}
        Collectible.collectScore = 0;
        Collectible.countCollect = 0;
        FindObjectOfType<CamSwitch>().isFPPOn = false;
        
        
        PlayerPrefs.SetFloat("score", 0);
        

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
