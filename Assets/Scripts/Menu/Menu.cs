using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void Play ()
    {
        ScenesManager.Instance.ChangeScene("Menu");
    }

    public void Exit ()
    {
        ScenesManager.Instance.ExitGame();
    }
}
