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
			case "Menu":
				AudioManager.Instance.StopAll();
				AudioManager.Instance.Play("MenuMusic");
				break;
			case "LVL1":
				AudioManager.Instance.StopAll();
				AudioManager.Instance.Play("GameMusic");
				PlayerManager.Instance.reset();
				break;
	//        case "Game":
	//            AudioManager.Instance.StopAll();
	//            AudioManager.Instance.Play("GameMusic");
				//PlayerManager.Instance.reset();
				//break;
			default:
				break;
		}
		SceneManager.LoadScene(scName);
	}

	public void ExitGame() {
		Application.Quit();
	}
}
