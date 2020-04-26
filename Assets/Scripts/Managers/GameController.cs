using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameController : MonoBehaviour
{
    public int score = 0;
    public int hiscore = 0;
    public static GameController Instance { get; private set; }
    

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("MenuMusic");
        StreamReader reader = new StreamReader("Hiscore.txt");
        string hiscorestring = reader.ReadLine();
        reader.Close();
        hiscore = int.Parse(hiscorestring);
        BeginGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    public void BeginGame()
    {
        score = 0;
        //scoreController.Instance.textScore.text = "PUNTOS:" + score;
        //scoreController.Instance.textHiscore.text = "META: " + hiscore;
    }
    public void IncrementScore()
    {
        score++;

        //scoreController.Instance.textScore.text = "PUNTOS:" + score;
        if (score > hiscore)
        {
            hiscore = Instance.score;
            //scoreController.Instance.textHiscore.text = "META: " + hiscore;

            // Save the new hiscore
            StreamWriter writer = new StreamWriter("Hiscore.txt", false);
            writer.Write(hiscore);
            writer.Close();
        }
    }
}
    