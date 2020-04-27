using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    public GameObject TextScore;
    public GameObject TextHiScore;
    public GameObject TextFakeCores;
    public GameObject TextBulletsRemain;

    private Text Score;
    private Text HiScore;
    private Text FakeCores;
    private Text BulletsRemain;

    void Start()
    {
        FakeCores = TextFakeCores.GetComponent<Text>();
        BulletsRemain = TextBulletsRemain.GetComponent<Text>();
        Score = TextScore.GetComponent<Text>();
        HiScore = TextHiScore.GetComponent<Text>();
    }

    void Update()
    {
        // UPDATE KEYSCOUNTER
        //if (!PlayerManager.Instance.IMMORTAL) KeysCounterText.text = PlayerManager.Instance.keys.ToString() + " de " + PlayerManager.Instance.GetCurrentLVLKeys().ToString();
        //else KeysCounterText.text = PlayerManager.Instance.keys.ToString() + " de " + PlayerManager.Instance.GetCurrentLVLKeys().ToString() + "	IMMORTAL";
        FakeCores.text = PlayerManager.Instance.ammoCore.ToString();
        BulletsRemain.text = PlayerManager.Instance.ammo.ToString();
        Score.text = "Score: " + GameController.Instance.score.ToString();
        HiScore.text = "HighScore: " + GameController.Instance.hiscore.ToString();
    }
}
