using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class loginControl : MonoBehaviour {

    public InputField username;
    public Text txt_bestscore;

    private string str_username;
    private string currentPlayerName;
    private string bestPlayerName;
    private int bestscore;


    
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (PlayerPrefs.HasKey("currentPlayer"))
            username.gameObject.GetComponent<InputField>().placeholder.GetComponent<Text>().text= PlayerPrefs.GetString("currentPlayer");

        if (username.text != "")
            currentPlayerName = username.text;
        else
            currentPlayerName = username.gameObject.GetComponent<InputField>().placeholder.GetComponent<Text>().text;

        PlayerPrefs.SetString("currentPlayer", currentPlayerName);
        
        if(PlayerPrefs.HasKey("bestPlayer")&&PlayerPrefs.HasKey("bestScore"))
        {
            txt_bestscore.text = "Best Score: " + PlayerPrefs.GetInt("bestScore").ToString() + " by " + PlayerPrefs.GetString("bestPlayer")+"!";
        }
        else
        {
            txt_bestscore.text = "Best Score: 0 by noname!";
        }

        
    }

    public void startPlaying()
    {
        Application.LoadLevel("playingScene");
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
}
