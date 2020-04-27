using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void Play ()
    {
        AudioManager.instance.StopAll();
        ScenesManager.Instance.ChangeScene("LVL1");
    }

    public void Exit ()
    {
        ScenesManager.Instance.ExitGame();
    }
}
