using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public Transform Objective;
	public int life;
	public float Speed;
	public bool arrived;
	public GameObject explosion;

	private void Start()
	{
		GameObject[] PlayerBounties = GameObject.FindGameObjectsWithTag("Wall");

		for (int i = 0; i < PlayerBounties.Length; i++)
		{
			Physics2D.IgnoreCollision(PlayerBounties[i].GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), true);
		}
		life = PlayerManager.Instance.enemyLife;
		arrived = false;
	}

	void Update()
	{
		Objective.position = SearchObjective();

		transform.position = Vector2.MoveTowards(transform.position, Objective.position, Speed * Time.deltaTime * 1000.0f);

		if (life <= 0)
		{
			Destroy(gameObject);
			GameController.Instance.IncrementScore();
			PlayerManager.Instance.AddAmmo();
			PlayerManager.Instance.increaseStreak();
		}
	}

	Vector2 SearchObjective()
	{
		float lowestDistance = 99999;
		Vector2 position = Vector2.zero;


		if (PlayerManager.Instance.CoresInGame.Length == 1) return position;

		for (int i = 0; i < PlayerManager.Instance.CoresInGame.Length; i++)
		{
			if (Vector3.Distance(transform.position, PlayerManager.Instance.CoresInGame[i].transform.position) < lowestDistance)
			{
				lowestDistance = Vector3.Distance(transform.position, PlayerManager.Instance.CoresInGame[i].transform.position);
				position = PlayerManager.Instance.CoresInGame[i].transform.position;
			}
		}

		//if (Vector3.Distance(transform.position, RialMainCore.transform.position) < lowestDistance)
		//{
		//	lowestDistance = Vector3.Distance(transform.position, RialMainCore.transform.position);
		//	position = RialMainCore.transform.position;
		//}

		return position;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			PlayerManager.Instance.health -= PlayerManager.Instance.enemyDmg;
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Bullet")
		{
			GameObject clone = Instantiate(explosion, this.transform.position, Quaternion.identity);
			Destroy(collision.gameObject);
			Destroy(clone, 1.0f);
			life -= PlayerManager.Instance.dmg;
		}
	}
}
