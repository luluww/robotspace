using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public GameObject gameoverText;
    public bool gameOver = false;
    public float scrollSpeed=-1.5f;
    public float baseSpeed = -1.5f;
    public Text scoreText;
    public GameObject newScore;
    public bool withUFO=false;

    private float startTime = 0;
    private float stageTime = 0;
    private float nextActionTime = 0;
    private float period = 0.5f;
   

    private int score = 0;
    
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.LoadLevel("loginScene");

        if (gameOver==false)
        {
            if (Time.time > nextActionTime)
            {
                stageTime = Time.time;
                scoreText.text = "Time: " + String.Format("{0:0}", (stageTime - startTime)) + " s";
                score = (int)(stageTime - startTime);
                nextActionTime += period;

                scrollSpeed = baseSpeed * (((int)(score / 60))+1);
                
            }
        }else
        {
            if (PlayerPrefs.HasKey("bestScore"))
            {
                if (score > PlayerPrefs.GetInt("bestScore"))
                {
                    PlayerPrefs.SetString("bestPlayer", PlayerPrefs.GetString("currentPlayer"));
                    PlayerPrefs.SetInt("bestScore", score);
                    newScore.GetComponent<Text>().text = "New Record: " + score.ToString() + "!!";
                    newScore.SetActive(true);
                }
            }
            else
            {
                PlayerPrefs.SetString("bestPlayer", PlayerPrefs.GetString("currentPlayer"));
                PlayerPrefs.SetInt("bestScore", score);
                newScore.GetComponent<Text>().text = "New Record: " + score.ToString() + "!!";
                newScore.SetActive(true);
            }
            
        }
        
        
    }

    public void clickToRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void robotDie()
    {
        gameoverText.SetActive(true);
        gameOver = true;
    }

    

    public void takeSpaceship()
    {
        scrollSpeed = 2*scrollSpeed;
    }

    //public void robotScored()
    //{
    //    if (gameOver)
    //        return;
    //    score += 1;
    //    scoreText.text = "Score: " + score.ToString()+"Stars";
    //}
}
