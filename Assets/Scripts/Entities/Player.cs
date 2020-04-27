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

	[Header("Variables for guns:")]
	[Space(10)]
	public Transform firePoint;
	public GameObject[] bullets;
	public Vector2 bulletSpeed;
	public float fireRate;
	public float fireRateCore;

	public float range;
	//  VARIABLES FOR GUNS
	private Rigidbody2D rb2dBullet;
	public GameObject bulletObject;
	public GameObject auxBulletObject;
	private float initialBulletTime;
	private float initialBulletCoreTime;
	private float initialBulletCoreLifeTime;
	private float Counter;

	public GameObject FakeCore;

	//VARIABLES FOR ANIMATIONS
	//private Animator animator;
	//private int moveParamID;

	void Start()
	{
        FindObjectOfType<AudioManager>().Play("GameMusic");
        rb2d = GetComponent<Rigidbody2D>();
		Movement = Vector2.zero;
		PlayerManager.Instance.ammo = 50;
		// GET ANIMATOR COMPONENTS
		//animator = GetComponent<Animator>();
		//moveParamID = Animator.StringToHash("Moving");
	}

	private void Update()
	{
		if (PlayerManager.Instance.health <= 0 && !PlayerManager.Instance.IMMORTAL) playerDie();

		EnemySpawner.Instance.Spawner();
		EnemySpawner.Instance.EnemyChecker();

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (PlayerManager.Instance.bulletSelected == 1) PlayerManager.Instance.bulletSelected = 0;
			else PlayerManager.Instance.bulletSelected = 1;
		}


		if (bulletObject != null)
		{
			if (Input.GetKeyDown(KeyCode.E) && bulletObject.tag == "BulletCore")
			{
				Instantiate( FakeCore, bulletObject.transform.position,Quaternion.identity);
				Destroy(bulletObject.gameObject);
			}
		}
        PlayerAim();
    }

	private void playerDie()
	{
        //SoundManager.Instance.PlaySound(SoundManager.Sounds.PlayerDie);
        
        Destroy(gameObject);
		FindObjectOfType<AudioManager>().Stop("GameMusic");
		FindObjectOfType<AudioManager>().Play("GameOver");
        //MusicManager.Instance.PlaySong(MusicManager.Songs.GameOver);
        PlayerManager.Instance.DefeatScene();

    }

    private void FixedUpdate()
	{
		fixedDelta = Time.fixedDeltaTime * 1000.0f;
		Counter = Time.time * fixedDelta;
		PlayerMovement();
		PlayerManager.Instance.SetPlayerPosition(transform.position);


		if (Counter >= initialBulletTime && Input.GetMouseButton(1) && PlayerManager.Instance.bulletSelected == 0)
		{
			Shooting();
			initialBulletTime = Counter + fireRate;
		}
		if (Counter >= initialBulletCoreTime && Input.GetMouseButton(1) && PlayerManager.Instance.bulletSelected == 1)
		{
			Shooting();
			initialBulletCoreTime = Counter + fireRateCore;
		}
	}

	void PlayerMovement()
	{
		Movement.x = Input.GetAxis("Horizontal");
		Movement.y = Input.GetAxis("Vertical");

		if (rb2d.velocity.x > PlayerManager.Instance.speed || rb2d.velocity.x < PlayerManager.Instance.speed)
		{
			rb2d.velocity = Vector2.zero;
            AudioManager.Instance.Stop("Propulsion");
            //animator.SetBool("Moving", false);
        }

        rb2d.AddForce(Movement * PlayerManager.Instance.speed * fixedDelta, ForceMode2D.Impulse);
        //animator.SetBool("Moving", true);
        AudioManager.Instance.Play("Propulsion");

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
		if (PlayerManager.Instance.ammo <= 0) return;
		bulletObject = Instantiate(bullets[PlayerManager.Instance.bulletSelected], firePoint.position, firePoint.rotation);
		rb2dBullet = bulletObject.GetComponent<Rigidbody2D>();
		rb2dBullet.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
        AudioManager.Instance.Play("Shoot");
        Destroy(bulletObject, range);
		PlayerManager.Instance.ammo--;
	}
}