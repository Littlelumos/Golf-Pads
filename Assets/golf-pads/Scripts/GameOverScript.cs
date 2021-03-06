﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {
	
	int score, bestScore;
	public Text scoreText, bestScoreText;
	public GameObject ball;

	void Start () {
		if (PlayerPrefs.GetInt ("Ads Removed") == 0)
			GameObject.Find ("AdMobController").GetComponent<AdMobScript> ().SendMessage ("showInterstitialAd");
		else
			return;
	}

	public void StartGameOverSequence()
	{
		Time.timeScale = 0;
		score = PlayerPrefs.GetInt ("Score");
		scoreText.text = "Score: " + score.ToString ();
		bestScore = PlayerPrefs.GetInt ("Best Score");
		bestScoreText.text = "Best Score: " + bestScore.ToString ();
	}

	public void OnHomeClick()
	{
		SceneManager.LoadScene ("Menu");
	}

	public void OnRestartClick()
	{
		this.gameObject.SetActive (false);
		SceneManager.LoadScene ("Game");
		ball.SetActive (true);
	}

	public void OnLeaderboardClick()
	{
        PlayGamesScript.ShowLeaderboardsUI();
    }

    public void OnReviveClick()
    {
        PlayerPrefs.SetInt("Credits", PlayerPrefs.GetInt("Credits") - 25);
        ball.GetComponent<BallScript>().Revive();
    }
}
