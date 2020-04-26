using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	private Vector2 mousePosition;
	private Vector2 Movement;
	private Rigidbody2D rb2d;

	private float fixedDelta;

	[Header("Counters for player:")]
	[Space(5)]
	public float dmgCounter = 100f;
	private float initialDmgCounter = 0;
	private float StaminaTimeRecover;
	private bool OffSetSprint = false;

	//  VARIABLES FOR GUNS
	private Rigidbody2D rb2dBullet;
	private GameObject bulletObject;
	private float initialBulletTime;
	private float Counter;

	[Header("Variables for guns:")]
	[Space(10)]
	public Transform firePoint;
	public GameObject weaponGraphicsObject;

	//VARIABLES FOR ANIMATIONS
	//private Animator animator;
	//private int moveParamID;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		Movement = Vector2.zero;

		// GET ANIMATOR COMPONENTS
		//animator = GetComponent<Animator>();
		//moveParamID = Animator.StringToHash("Moving");

		//PlayerSceneManager.Instance.isSceneHostile();
	}

	private void Update()
	{
		if (PlayerManager.Instance.health <= 0 && !PlayerManager.Instance.IMMORTAL) playerDie();
	}

	private void playerDie()
	{
		//SoundManager.Instance.PlaySound(SoundManager.Sounds.PlayerDie);
		//Destroy(gameObject);
		//MusicManager.Instance.PlaySong(MusicManager.Songs.GameOver);
		//PlayerSceneManager.Instance.goLastScene();
	}

	private void FixedUpdate()
	{
		fixedDelta = Time.fixedDeltaTime * 1000.0f;
		Counter = Time.time * fixedDelta;
		PlayerMovement();
		PlayerManager.Instance.SetPlayerPosition(transform.position);
		PlayerAim();

		//SpawnerManager.Instance.Spawner();
		//SpawnerManager.Instance.EnemyChecker();

		//if (weaponUsing == null) return;
		//if (Counter >= ReloadingCounter && reloading == true) reloading = false;
		//else
		//{
		//	if (Counter >= initialBulletTime && Input.GetMouseButton(0))
		//	{
		//		if (weaponUsing.Rounds <= 0) return;

		//		if (reloading == true) return;

		//		Shooting();

		//		initialBulletTime = Counter + (weaponUsing.FireRate / PlayerManager.Instance.shootingBoost);
		//		ReloadingCounter = Counter + weaponUsing.reloadTime;
		//	}
		//}
	}

	void PlayerMovement()
	{
		Movement.x = Input.GetAxis("Horizontal");
		Movement.y = Input.GetAxis("Vertical");

		if (rb2d.velocity.x > PlayerManager.Instance.speed || rb2d.velocity.x < PlayerManager.Instance.speed)
		{
			rb2d.velocity = Vector2.zero;
			//animator.SetBool("Moving", false);
		}
		rb2d.AddForce(Movement * PlayerManager.Instance.speed * fixedDelta, ForceMode2D.Impulse);
		//animator.SetBool("Moving", true);
	}
	void PlayerAim()
	{
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

		Vector2 lookDirection = mousePosition - rb2d.position;
		float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
		rb2d.rotation = angle;
	}
	void Shooting()
	{
		//bulletObject = Instantiate(weaponUsing.Bullet, firePoint.position, firePoint.rotation);
		//bulletObject.GetComponent<Bullet>().PlayerShoot = true;
		//rb2dBullet = bulletObject.GetComponent<Rigidbody2D>();
		//rb2dBullet.AddForce(firePoint.up * weaponUsing.BulletSpeed, ForceMode2D.Impulse);
		////SoundManager.Instance.PlaySound(SoundManager.Sounds.Shooting);
		//Destroy(bulletObject, weaponUsing.Range);
	}
}