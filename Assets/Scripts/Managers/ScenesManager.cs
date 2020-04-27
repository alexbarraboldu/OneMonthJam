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
                AudioManager.Instance.StopAll();
                AudioManager.Instance.Play("MenuMusic");
                break;
<<<<<<< HEAD
            case "LVL1":
                AudioManager.instance.StopAll();
                AudioManager.instance.Play("GameMusic");
                break;
=======
            case "Game":
                AudioManager.Instance.StopAll();
                AudioManager.Instance.Play("GameMusic");
				PlayerManager.Instance.reset();
				break;
>>>>>>> 3dfcefd20f787a9671dce94d4d55395c25f8937a
            default:
                break;
        }
        SceneManager.LoadScene(scName);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
