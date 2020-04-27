using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play ()
    {
        SceneManager.LoadScene("LVL1");
        AudioManager.instance.StopMusic();
        SceneManager.Instance.ChangeScene("Game");
    }

    public void Exit ()
    {
        Application.Quit();
    }
}
