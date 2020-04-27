using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance { get; private set; }

    public void ChangeScene (string scName) {
        switch (scName)
        {
            case "Menu":
                FindObjectOfType<AudioManager>().Stop("GameMusic");
                FindObjectOfType<AudioManager>().Play("MenuMusic");
                break;
            case "LVL1":
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
