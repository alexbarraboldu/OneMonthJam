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
        scoreText = GMScoreText.GetComponent<Text>();
        scoreText.text = "SCORE: " + GameController.Instance.score.ToString();
        //score = GameController.Instance.score;
    }

    public void PlayAgain ()
    {
        SceneManager.LoadScene("LVL1");
    }

    public void BackToMenu ()
    {
        SceneManager.LoadScene("Menu");
    }
}
