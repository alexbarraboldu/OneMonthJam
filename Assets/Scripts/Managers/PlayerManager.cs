﻿using System;
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
    public int dmg;
	public int ammo, ammoCore;
	public int bulletSelected;
	public Vector2 PlayerPosition;
    public int streak;
    public int lvl;
    public int needed;


    public int enemyLife;
    public int enemyDmg;

    [Header("Variables for Core:")]
    public Core[] CoresInGame;

    //SKINS
    public Sprite lvl1;
    public Sprite lvl2;
    public Sprite lvl3;
    public Sprite lvl4;
    public Sprite lvl5;

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
        health = 3;
		bulletSelected = 0;
        needed = 5;
        streak = 0;
        lvl = 1;
        dmg = 1;
        enemyLife = 1;
        enemyDmg = 1;
    }

    private void Update()
    {
        CoresInGame = FindObjectsOfType<Core>();
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
        health = 3;
        bulletSelected = 0;
        needed = 5;
        streak = 0;
        lvl = 1;
        dmg = 1;
        enemyLife = 1;
        enemyDmg = 1;
        GameController.Instance.score = 0;
    }
    public void increaseStreak()
    {
        if (streak < needed){
            streak += 1;
        }
        else if (streak == needed && lvl <= 5){
            streak = 0;
            if (lvl < 5){
                lvl += 1;
                UpgradeSkin();
            }
            else{
                Debug.Log("MAX LVL");
            }
        }
    }
    void UpgradeSkin()
    {
        Player a = GameObject.Find("Player").GetComponent<Player>();
        switch (lvl)
        {
            case 1:
                FindObjectOfType<SkinController>().GetComponent<SpriteRenderer>().sprite = lvl1;
                needed = 5;
                dmg++;
                health++;
                enemyLife = 2;
                break;
            case 2:
                FindObjectOfType<SkinController>().GetComponent<SpriteRenderer>().sprite = lvl2;
                needed = 7;
                dmg++;
                health++;
                enemyLife = 6;
                break;
            case 3:
                FindObjectOfType<SkinController>().GetComponent<SpriteRenderer>().sprite = lvl3;
                needed = 9;
                dmg++;
                health++;
                enemyLife = 8;
                a.bulletSpeed.Set(a.bulletSpeed.x * 1.5f, a.bulletSpeed.y * 1.5f);
                break;
            case 4:
                FindObjectOfType<SkinController>().GetComponent<SpriteRenderer>().sprite = lvl4;
                needed = 11;
                dmg++;
                health++;
                enemyLife = 10;
                a.bulletSpeed.Set(a.bulletSpeed.x * 1.5f, a.bulletSpeed.y * 1.5f);
                break;
            case 5:
                FindObjectOfType<SkinController>().GetComponent<SpriteRenderer>().sprite = lvl5;
                needed = 13;
                dmg++;
                health++;
                enemyLife = 12;
                a.bulletSpeed.Set(a.bulletSpeed.x * 1.5f, a.bulletSpeed.y * 1.5f);
                break;
            default:
                break;
        }
    }

	public void AddAmmo()
	{
		ammo +=2 + (EnemySpawner.Instance.ActualRound / 2);
	}

    public void DefeatScene ()
    {
        ScenesManager.Instance.ChangeScene("DefeatScene");
    }
}
