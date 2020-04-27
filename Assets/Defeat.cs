using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Defeat : MonoBehaviour
{
    public Text scoreText;
    int score;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    scoreText = GetComponent<Text>();
    //    score = GameController.Instance.score;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    scoreText.text = score.ToString();
    //}

    public void PlayAgain ()
    {
        SceneManager.LoadScene("LVL1");
    }

    public void BackToMenu ()
    {
        SceneManager.LoadScene("Menu");
    }
}
