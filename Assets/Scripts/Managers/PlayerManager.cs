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
	public int ammo;
	public int bulletSelected;
	public Vector2 PlayerPosition;
    public int streak;
    public int lvl;
    public int needed;

    //SKINS
    public Sprite lvl1;
    public Sprite lvl2;
    public Sprite lvl3;
    public Sprite lvl4;
    public Sprite lvl5;

    void Start()
	{
        needed = 5;
        streak = 0;
        lvl = 0;
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			Debug.Log("Error: Duplicated " + this + "in the scene");
		}
		bulletSelected = 0;
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
                //el level ya es el maximo;
            }
        }
    }
    void UpgradeSkin()
    {
        switch (lvl)
        {
            case 1:
                FindObjectOfType<SkinController>().GetComponent<SpriteRenderer>().sprite = lvl1;
                needed = 5;
                break;
            case 2:
                FindObjectOfType<SkinController>().GetComponent<SpriteRenderer>().sprite = lvl2;
                needed = 7;
                break;
            case 3:
                FindObjectOfType<SkinController>().GetComponent<SpriteRenderer>().sprite = lvl3;
                needed = 9;
                break;
            case 4:
                FindObjectOfType<SkinController>().GetComponent<SpriteRenderer>().sprite = lvl4;
                needed = 11;
                break;
            case 5:
                FindObjectOfType<SkinController>().GetComponent<SpriteRenderer>().sprite = lvl5;
                needed = 13;
                break;
            default:
                break;
        }
    }

	public void AddAmmo()
	{
		ammo++;
	}
}
