using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 4f;
    public GameObject completeLevelUI;
    public GameObject gameOverLevelUI;
    public float levelNumber = 01;
    public float lastSceneIndex = 2;
    //public Text levelNumberText;

    
    

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            gameOverLevelUI.SetActive(true);
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
            
        }
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        FindObjectOfType<CamSwitch>().isFPPOn = false;
        Collectible.collectScore = 0;
        Collectible.countCollect = 0;
        
    }

    public void CompleteLevel()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            completeLevelUI.SetActive(true);
            //if(completeLevelUI.active == true)
            //    {
                    //Debug.Log("Level Complete");
                    //Invoke("Restart", restartDelay);
            FindObjectOfType<Score>().gameFinish();
            FindObjectOfType<CamSwitch>().isFPPOn = false;
            //}
            Collectible.collectScore = 0;
            Collectible.countCollect = 0;
            if(SceneManager.GetActiveScene().buildIndex == lastSceneIndex)
            {
                PlayerPrefs.SetFloat("score", 0);
            }
        }
       
        
        
    }
}
