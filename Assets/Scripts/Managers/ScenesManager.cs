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
            case "MainMenu":
                AudioManager.Instance.StopAll();
                AudioManager.Instance.Play("MenuMusic");
                break;
            case "Game":
                AudioManager.Instance.StopAll();
                AudioManager.Instance.Play("GameMusic");
				PlayerManager.Instance.reset();
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
