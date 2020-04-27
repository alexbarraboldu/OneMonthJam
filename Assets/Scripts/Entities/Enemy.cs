using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public Transform Objective;
	public int life;
	public float Speed;
	public bool arrived;

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

		if (!arrived) transform.position = Vector2.MoveTowards(transform.position, Objective.position, Speed * Time.deltaTime * 1000.0f);

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
		//for (int i = 0; i < Manager.Instance.Core.Length; i++)
		//{
		//    if (Vector3.Distance(transform.position, Manager.Instance.Core[i].transform.position) < lowestDistance)
		//    {
		//        lowestDistance = Vector3.Distance(transform.position, Manager.Instance.Core[i].transform.position);
		//        position = Manager.Instance.Core[i].transform.position;
		//    }
		//}
		//if (Vector3.Distance(transform.position, RialMainCore.transform.position) < lowestDistance)
		//{
		//    lowestDistance = Vector3.Distance(transform.position, RialMainCore.transform.position);
		//    position = RialMainCore.transform.position;
		//}

		return position;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Core")
		{
			arrived = true;
		}
		//if (collision.gameObject.tag == "Enemy")
		//{
		//	transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		//}
		if (collision.gameObject.tag == "Player")
		{
			PlayerManager.Instance.health -= 1;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Bullet")
		{
			Destroy(collision.gameObject);
			life -= PlayerManager.Instance.dmg;
		}
		if (collision.gameObject.tag == "BulletCore")
		{
			Destroy(collision.gameObject);
		}
	}
}
