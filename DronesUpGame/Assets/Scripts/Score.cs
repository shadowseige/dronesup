using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{

    

    
    public Text timeText;
    public Text scoreText;
    
    public float timeLeft;
    private float startTime;
    private bool gameFinished = false;
    public float timeSpent = 0; 
    public float levelScore = 50; // The player will be awarded of 50 points per remaining second
    public float collectScore = 10;
    public float collectTimeIncrease = 10;
    






    void Start()
    {
        startTime = Time.time;
    }
    private void Update()
    {
        //Debug.Log(player.position.z);
        //scoreText.text = player.position.z.ToString("0");
        if (gameFinished)
            return;
        
        float t = Time.time - startTime;
        float countDown = timeLeft - t + (Collectible.countCollect * collectTimeIncrease);
        //timeSpent = timeLeft - countDown;

        if (countDown < 0)
        {
            gameFinish();
            
            ScoreBoard();
        }
        else
        {
            string minutes = ((int)countDown / 60).ToString("00");
            string seconds = (countDown % 60).ToString("00");

            if(seconds == "60")
            {
                timeText.text = "Timer: " + (((int)countDown / 60)+ 1).ToString("00") + ":00";
            }
            else
            {
                timeText.text = "Timer: " + minutes + ":" + seconds;
            }
            
            
        }
        
    }

    public void gameFinish()
    {
        
        gameFinished = true;
        timeText.color = Color.red;
        timeText.fontSize = 24;
        
        ScoreBoard();
        FindObjectOfType<GameManager>().EndGame();
    }

    public void ScoreBoard()
    {
        float score = 0;

        if (SceneManager.GetActiveScene().buildIndex == 2) 
        {

            PlayerPrefs.SetFloat("score", 0);
            // Compute the final score
            score += (System.Math.Max(0, timeLeft - Time.time) * levelScore) + (Collectible.totalCollectibles * collectScore);
            //Debug.Log(Time.time);
            //Debug.Log(timeLeft);
            //Debug.Log(score);
            //Debug.Log(System.Math.Max(0, timeLeft - Time.time) * levelScore);
            //Debug.Log(Collectible.countCollect * collectScore);
            scoreText.text = "Your Score: " + score.ToString();
            Debug.Log("score1");
            Debug.Log(score);
            PlayerPrefs.SetFloat("score", score);
            Debug.Log("PP 1");
            Debug.Log(PlayerPrefs.GetFloat("score"));

        }

        else if((SceneManager.GetActiveScene().buildIndex != 0 || SceneManager.GetActiveScene().buildIndex != 1 || SceneManager.GetActiveScene().buildIndex != 7))
        {

            score += PlayerPrefs.GetFloat("score");
            float a = score;
            // Compute the final score
            score += (System.Math.Max(0, timeLeft - Time.time) * levelScore) + (Collectible.totalCollectibles * collectScore);
            //Debug.Log(Time.time);
            //Debug.Log(timeLeft);
            //Debug.Log(score);
            //Debug.Log(System.Math.Max(0, timeLeft - Time.time) * levelScore);
            //Debug.Log(Collectible.countCollect * collectScore);
            scoreText.text = "Your Score: " + score.ToString();
            Debug.Log("score2");
            Debug.Log(score-a);
            Debug.Log("Totalscore");
            Debug.Log(score);
            PlayerPrefs.SetFloat("score", score);

        }

       

    }
}