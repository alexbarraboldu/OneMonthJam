using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance { get; private set; }

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.Log("Error: Duplicated " + this + "in the scene");
        }
    }

    public void ChangeScene (string scName) {
        switch (scName)
        {
            case "MainMenu":
                AudioManager.instance.StopAll();
                AudioManager.instance.Play("MenuMusic");
                break;
            case "LVL1":
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