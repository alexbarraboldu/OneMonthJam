using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public static EnemySpawner Instance { get; private set; }

	public bool STOP;

	[Header("Map Bounties:")]
	public Vector2 MapTopLeftLimit;
	public Vector2 MapBotRightLimit;

	[Header("Inner Map Bounties:")]
	public Vector2 InnerMapTopLeftLimit;
	public Vector2 InnerMapBotRightLimit;

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
			//DontDestroyOnLoad(this);
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
		if (GameController.Instance.GetIndexScene() == "DefeatScene" || GameController.Instance.GetIndexScene() == "DefeatScene") return;
		MapTopLeftLimit = new Vector2(GameObject.Find("West_Wall").transform.position.x, GameObject.Find("North_Wall").transform.position.y);
		MapBotRightLimit = new Vector2(GameObject.Find("East_Wall").transform.position.x, GameObject.Find("South_Wall").transform.position.y);

		InnerMapTopLeftLimit = new Vector2(GameObject.Find("West").transform.position.x, GameObject.Find("North").transform.position.y);
		InnerMapBotRightLimit = new Vector2(GameObject.Find("East").transform.position.x, GameObject.Find("South").transform.position.y);
	}
	private Vector2 GenerateRawPosition()
	{
			return new Vector2(Random.Range(MapTopLeftLimit.x, MapBotRightLimit.x), Random.Range(MapBotRightLimit.y, MapTopLeftLimit.y));
	}

	public Vector2 CheckRawPosition()
	{
		Vector2 RawPosition = GenerateRawPosition();

		if (STOP) return RawPosition;

		if ((RawPosition.x >= InnerMapTopLeftLimit.x && RawPosition.x <= InnerMapBotRightLimit.x) && (RawPosition.y >= InnerMapBotRightLimit.y && RawPosition.y <= InnerMapTopLeftLimit.y))
		{
			RawPosition = CheckRawPosition();
		}

		NetPosition = RawPosition;

		return NetPosition;
	}

	public void Spawner()
	{
		if (RoundSpawnComplete) return;

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
		for (int m = 0; m < 10 + waveCounter; m++)
		{
			NetPosition = CheckRawPosition();
			Instantiate(AuxEnemy, NetPosition, Quaternion.identity);
		}

		RoundSpawnComplete = true;
	}

	public void EnemyChecker()
	{
		int MeleeEnemies = GameObject.FindObjectsOfType<Enemy>().Length;

		TotalEnemies = MeleeEnemies;

		if ((MeleeEnemies == 0) && !FirstTime)
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
