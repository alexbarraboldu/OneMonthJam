using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Defeat : MonoBehaviour
{
	public GameObject GMScoreText;
	private Text scoreText;
//    private int score;

	void Start()
	{
		AudioManager.Instance.StopAll();
		AudioManager.Instance.Play("GameOverMusic");
		AudioManager.Instance.Play("MenuMusic");
		scoreText = GMScoreText.GetComponent<Text>();
		scoreText.text = "SCORE: " + GameController.Instance.score.ToString();
	}

	private void Update()
	{
		scoreText.text = "SCORE: " + GameController.Instance.score.ToString();
	}


	public void PlayAgain ()
	{
		ScenesManager.Instance.ChangeScene("LVL1");
	}

	public void BackToMenu ()
	{
		ScenesManager.Instance.ChangeScene("Menu");
	}
}
