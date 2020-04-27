using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void Play ()
    {
<<<<<<< HEAD
        AudioManager.instance.StopAll();
        ScenesManager.Instance.ChangeScene("LVL1");
=======
       // SceneManager.LoadScene("LVL1");
        AudioManager.Instance.StopMusic();
        ScenesManager.Instance.ChangeScene("Game");
>>>>>>> 3dfcefd20f787a9671dce94d4d55395c25f8937a
    }

    public void Exit ()
    {
        ScenesManager.Instance.ExitGame();
    }
}
