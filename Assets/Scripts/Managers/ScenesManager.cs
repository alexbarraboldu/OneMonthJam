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
                FindObjectOfType<AudioManager>().Stop("GameMusic");
                FindObjectOfType<AudioManager>().Play("MenuMusic");
                break;
            case "Game":
                FindObjectOfType<AudioManager>().Stop("MenuMusic");
                FindObjectOfType<AudioManager>().Play("GameMusic");
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
