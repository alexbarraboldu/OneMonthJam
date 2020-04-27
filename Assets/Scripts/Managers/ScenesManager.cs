using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void ChangeScene (string scName) {
        switch (scName)
        {
            case "MainMenu":
                AudioManager.instance.StopAll();
                AudioManager.instance.Play("MenuMusic");
                break;
            case "Game":
                AudioManager.instance.StopAll();
                AudioManager.instance.Play("GameMusic");
                break;
            default:
                break;
        }
        SceneManager.LoadScene(scName);
    }

    public void ExitGame() {
        Application.Quit();
    }
}