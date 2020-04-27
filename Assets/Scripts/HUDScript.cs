using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    public GameObject TextScore;
    public GameObject TextHiScore;

    private Text Score;
    private Text HiScore;

    void Start()
    {
        Score = TextScore.GetComponent<Text>();
        HiScore = TextHiScore.GetComponent<Text>();
    }

    void Update()
    {
        // UPDATE KEYSCOUNTER
        //if (!PlayerManager.Instance.IMMORTAL) KeysCounterText.text = PlayerManager.Instance.keys.ToString() + " de " + PlayerManager.Instance.GetCurrentLVLKeys().ToString();
        //else KeysCounterText.text = PlayerManager.Instance.keys.ToString() + " de " + PlayerManager.Instance.GetCurrentLVLKeys().ToString() + "	IMMORTAL";

        Score.text = "Score: " + GameController.Instance.score.ToString();
        HiScore.text = "HighScore: " + GameController.Instance.hiscore.ToString();
    }
}
