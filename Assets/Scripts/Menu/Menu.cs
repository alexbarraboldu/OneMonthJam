using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        ScenesManager.Instance.ExitGame();
    }
}
