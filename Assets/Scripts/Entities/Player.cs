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
	public Transform firePointlvl2;
	public Transform firePoint2lvl2;
	public Transform firePointlvl4;
	public Transform firePoint2lvl4;
	public Transform firePoint3lvl4;
	public Transform firePoint4lvl4;
	public GameObject[] bullets;
	public Vector2 bulletSpeed;
	public float fireRate;
	public float fireRateCore;

	public float range;
	//  VARIABLES FOR GUNS
	private Rigidbody2D rb2dBullet;
	private Rigidbody2D rb2dBullet2;
	private Rigidbody2D rb2dBullet3;
	private Rigidbody2D rb2dAuxBullet;
	public GameObject bulletObject;
	public GameObject bulletObject2;
	public GameObject bulletObject3;
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
	  
		if (bulletObject != null)
		{
			if (Input.GetMouseButton(1) && bulletObject.tag == "BulletCore")
			{
				GameObject a = Instantiate(FakeCore);
				a.transform.position = bulletObject.transform.position;
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


		if (Counter >= initialBulletTime && Input.GetMouseButton(0))
		{
			Shooting(0);
			initialBulletTime = Counter + fireRate;
		}
		if (Counter >= initialBulletCoreTime && Input.GetMouseButton(1))
		{
			Shooting(1);
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
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		//habibi
		transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg - 90);

		//Vector2 lookDirection = mousePosition - rb2d.position;
		//float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
		//rb2d.rotation = angle;
	}
	void Shooting(int bulletShooting)
	{
		if (bulletShooting == 0 && PlayerManager.Instance.ammo > 0 && PlayerManager.Instance.lvl == 1)
		{
			bulletObject = Instantiate(bullets[bulletShooting], firePoint.position, firePoint.rotation);
			rb2dBullet = bulletObject.GetComponent<Rigidbody2D>();
			rb2dBullet.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
			AudioManager.Instance.Play("Shoot");
			Destroy(bulletObject, range);
			PlayerManager.Instance.ammo--;
		} 
		else if (bulletShooting == 0 && PlayerManager.Instance.ammo > 0 && PlayerManager.Instance.lvl == 2)
		{
			bulletObject = Instantiate(bullets[bulletShooting], firePointlvl2.position, firePoint.rotation);
			auxBulletObject = Instantiate(bullets[bulletShooting], firePoint2lvl2.position, firePoint.rotation);
			rb2dBullet = bulletObject.GetComponent<Rigidbody2D>();
			rb2dBullet.AddForce(firePointlvl2.up * bulletSpeed, ForceMode2D.Impulse);
			rb2dAuxBullet = auxBulletObject.GetComponent<Rigidbody2D>();
			rb2dAuxBullet.AddForce(firePoint2lvl2.up * bulletSpeed, ForceMode2D.Impulse);
			AudioManager.Instance.Play("Shoot");
			Destroy(bulletObject, range);
			Destroy(auxBulletObject, range);
			PlayerManager.Instance.ammo--;
		}
		if (bulletShooting == 0 && PlayerManager.Instance.ammo > 0 && PlayerManager.Instance.lvl == 3)
		{
			bulletObject = Instantiate(bullets[bulletShooting], firePointlvl2.position, firePoint.rotation);
			auxBulletObject = Instantiate(bullets[bulletShooting], firePoint2lvl2.position, firePoint.rotation);
			rb2dBullet = bulletObject.GetComponent<Rigidbody2D>();
			rb2dBullet.AddForce(firePointlvl2.up * bulletSpeed, ForceMode2D.Impulse);
			rb2dAuxBullet = auxBulletObject.GetComponent<Rigidbody2D>();
			rb2dAuxBullet.AddForce(firePoint2lvl2.up * bulletSpeed, ForceMode2D.Impulse);
			AudioManager.Instance.Play("Shoot");
			Destroy(bulletObject, range);
			Destroy(auxBulletObject, range);
			PlayerManager.Instance.ammo--;
		} 
		else if (bulletShooting == 0 && PlayerManager.Instance.ammo > 0 && PlayerManager.Instance.lvl == 4)
		{
			bulletObject = Instantiate(bullets[bulletShooting], firePointlvl4.position, firePoint.rotation);
			auxBulletObject = Instantiate(bullets[bulletShooting], firePoint2lvl4.position, firePoint.rotation);
			bulletObject2 = Instantiate(bullets[bulletShooting], firePoint3lvl4.position, firePoint.rotation);
			bulletObject3 = Instantiate(bullets[bulletShooting], firePoint4lvl4.position, firePoint.rotation);
			rb2dBullet = bulletObject.GetComponent<Rigidbody2D>();
			rb2dBullet.AddForce(firePointlvl4.up * bulletSpeed, ForceMode2D.Impulse);
			rb2dAuxBullet = auxBulletObject.GetComponent<Rigidbody2D>();
			rb2dAuxBullet.AddForce(firePoint2lvl4.up * bulletSpeed, ForceMode2D.Impulse);
			rb2dBullet2 = bulletObject2.GetComponent<Rigidbody2D>();
			rb2dBullet2.AddForce(firePoint3lvl4.up * bulletSpeed, ForceMode2D.Impulse);
			rb2dBullet3 = bulletObject3.GetComponent<Rigidbody2D>();
			rb2dBullet3.AddForce(firePoint4lvl4.up * bulletSpeed, ForceMode2D.Impulse);
			AudioManager.Instance.Play("Shoot");
			Destroy(bulletObject, range);
			Destroy(auxBulletObject, range);
			Destroy(bulletObject2, range);
			Destroy(bulletObject3, range);
			PlayerManager.Instance.ammo--;
		}
		else if (bulletShooting == 0 && PlayerManager.Instance.ammo > 0 && PlayerManager.Instance.lvl == 5)
		{
			bulletObject = Instantiate(bullets[bulletShooting], firePointlvl4.position, firePoint.rotation);
			auxBulletObject = Instantiate(bullets[bulletShooting], firePoint2lvl4.position, firePoint.rotation);
			bulletObject2 = Instantiate(bullets[bulletShooting], firePoint3lvl4.position, firePoint.rotation);
			bulletObject3 = Instantiate(bullets[bulletShooting], firePoint4lvl4.position, firePoint.rotation);
			rb2dBullet = bulletObject.GetComponent<Rigidbody2D>();
			rb2dBullet.AddForce(firePointlvl4.up * bulletSpeed, ForceMode2D.Impulse);
			rb2dAuxBullet = auxBulletObject.GetComponent<Rigidbody2D>();
			rb2dAuxBullet.AddForce(firePoint2lvl4.up * bulletSpeed, ForceMode2D.Impulse);
			rb2dBullet2 = bulletObject2.GetComponent<Rigidbody2D>();
			rb2dBullet2.AddForce(firePoint3lvl4.up * bulletSpeed, ForceMode2D.Impulse);
			rb2dBullet3 = bulletObject3.GetComponent<Rigidbody2D>();
			rb2dBullet3.AddForce(firePoint4lvl4.up * bulletSpeed, ForceMode2D.Impulse);
			AudioManager.Instance.Play("Shoot");
			Destroy(bulletObject, range);
			Destroy(auxBulletObject, range);
			Destroy(bulletObject2, range);
			Destroy(bulletObject3, range);
			PlayerManager.Instance.ammo--;
		}


		if (bulletShooting == 1 && PlayerManager.Instance.ammoCore > 0)
		{
			bulletObject = Instantiate(bullets[bulletShooting], firePoint.position, firePoint.rotation);
			rb2dBullet = bulletObject.GetComponent<Rigidbody2D>();
			rb2dBullet.AddForce(firePoint.up * new Vector2(10,10), ForceMode2D.Impulse);
			AudioManager.Instance.Play("Shoot");
			Destroy(bulletObject, range);
			PlayerManager.Instance.ammoCore--;
		}
	}
}