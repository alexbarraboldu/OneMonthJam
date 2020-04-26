using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    // RESET TIMER
    public bool IMMORTAL;

    // VARIABLES
    [Header("Variables for player:")]
    public float health;
    public float speed;
    public Vector2 PlayerPosition;

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

    //private void Update()
    //{
    //    //if (SceneManager.GetActiveScene().name == "DEV_TileMap-ZonaHostil-3" && SpawnerManager.Instance.ActualRound >= 5)
    //    //{
    //    //    Victory();
    //    //}
    //}

    private void Victory()
    {
        //PlayerSceneManager.Instance.goFrontScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void SetPlayerPosition(Vector2 position)
    {
        PlayerPosition = position;
    }

    public Vector2 GetPlayerPosition()
    {
        return PlayerPosition;
    }
    public void reset()
    {
        health = 100;
        speed = 1.25f;
    }
}
