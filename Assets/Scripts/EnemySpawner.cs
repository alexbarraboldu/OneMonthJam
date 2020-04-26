﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public static EnemySpawner Instance { get; private set; }

	public bool STOP;

	[Header("Map Bounties:")]
	public Vector2 MapTopLeftLimit;
	public Vector2 MapBotRightLimit;

	[Header("Camera Bounties:")]
	public Vector2 CameraTopLeftLimit;
	public Vector2 CameraBotRightLimit;

	[Header("Final Spawn Position:")]
	public Vector2 NetPosition;
	private Vector2 RawPosition;

	[Header("Enemies to spawn:")]
	public Enemy AuxEnemy;

	[Header("Enemy Waves:")]
	public int ActualRound = 0;
	public bool RoundSpawnComplete;
	public int TotalEnemies;
	//public EnemyWaves HostileZoneWaves;

	public float Counter;
	public float waveCounter;
	public bool FirstTime;

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
		Counter = 0;
		FirstTime = true;
	}

	private void Update()
	{
		//if (!PlayerSceneManager.Instance.ZoneIsHostile) reset();
		MapTopLeftLimit = new Vector2(GameObject.Find("West_Wall").transform.position.x, GameObject.Find("North_Wall").transform.position.y);
		MapBotRightLimit = new Vector2(GameObject.Find("East_Wall").transform.position.x, GameObject.Find("South_Wall").transform.position.y);


		CameraTopLeftLimit = new Vector2(Camera.main.transform.position.x - Camera.main.aspect * Camera.main.orthographicSize, Camera.main.transform.position.y + Camera.main.orthographicSize);
		CameraBotRightLimit = new Vector2(Camera.main.transform.position.x + Camera.main.aspect * Camera.main.orthographicSize, Camera.main.transform.position.y - Camera.main.orthographicSize);
	}
	private Vector2 GenerateRawPosition()
	{
		//if (PlayerManager.Instance.PlayerPosition.x > 0) //Right
		//{
		//	if (PlayerManager.Instance.PlayerPosition.y > 0) //Up
		//	{
		//		return new Vector2(Random.Range(0, MapBotRightLimit.x), Random.Range(0, MapTopLeftLimit.y));
		//	}
		//	else //Down
		//	{
		//		return new Vector2(Random.Range(0, MapBotRightLimit.x), Random.Range(MapBotRightLimit.y, 0));
		//	}
		//}
		//else if (PlayerManager.Instance.PlayerPosition.x < 0) //Left
		//{
		//	if (PlayerManager.Instance.PlayerPosition.y > 0) //Up
		//	{
		//		return new Vector2(Random.Range(MapTopLeftLimit.x, 0), Random.Range(0, MapTopLeftLimit.y));
		//	}
		//	else //Down
		//	{
		//		return new Vector2(Random.Range(MapTopLeftLimit.x, 0), Random.Range(MapBotRightLimit.y, 0));
		//	}
		//}
		//else //All
		//{
			return new Vector2(Random.Range(MapTopLeftLimit.x, MapBotRightLimit.x), Random.Range(MapBotRightLimit.y, MapTopLeftLimit.y));
		//}
	}

	public Vector2 CheckRawPosition()
	{
		Vector2 RawPosition = GenerateRawPosition();

		if (STOP) return RawPosition;

		if ((RawPosition.x >= CameraTopLeftLimit.x && RawPosition.x <= CameraBotRightLimit.x) && (RawPosition.y >= CameraBotRightLimit.y && RawPosition.y <= CameraTopLeftLimit.y))
		{
			RawPosition = CheckRawPosition();
		}

		NetPosition = RawPosition;

		//  Enemy Randomize
		//int EnemyToSpawn = Random.Range(0, 2);
		//if (EnemyToSpawn == 0) Instantiate(AuxEnemy, NetPosition, Quaternion.identity);
		//else Instantiate(AuxEnemyShooter, NetPosition, Quaternion.identity);

		//Debug.Log(NetPosition);
		return NetPosition;
	}

	public void Spawner()
	{
		if (RoundSpawnComplete /*|| !PlayerSceneManager.Instance.ZoneIsHostile*/) return;

		if (FirstTime)
		{
			Counter++;
			if (Counter >= 400f)
			{
				FirstTime = false;
				Counter = 0;
			}
			return;
		}

		// Enemy Spawn
		//int EnemiesToSpawn = HostileZoneWaves.EnemyTypePerRound[ActualRound].x;
		for (int m = 0; m < 10; m++)
		{
			NetPosition = CheckRawPosition();
			Instantiate(AuxEnemy, NetPosition, Quaternion.identity);
		}
		//EnemiesToSpawn = HostileZoneWaves.EnemyTypePerRound[ActualRound].y;

		RoundSpawnComplete = true;
	}

	public void EnemyChecker()
	{
		int MeleeEnemies = GameObject.FindObjectsOfType<Enemy>().Length;
		//int RangedEnemies = GameObject.FindObjectsOfType<EnemyShooter>().Length;

		TotalEnemies = MeleeEnemies;

		if ((MeleeEnemies == 0) /*&& PlayerSceneManager.Instance.ZoneIsHostile */ && !FirstTime)
		{
			if (Counter >= 200f)
			{
				ActualRound++;
				RoundSpawnComplete = false;
				Counter = 0;
			}
			Counter += 1f;
		}
	}

	public void reset()
	{
		RoundSpawnComplete = false;
		ActualRound = 0;
		Counter = 0;
		FirstTime = true;
	}
}
