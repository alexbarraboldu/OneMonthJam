using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Core : MonoBehaviour
{
	public int life;
	public Slider lifeslider;
	private Animator anim;
	private void Start()
	{
		anim = gameObject.GetComponent<Animator>();
		//if (lifeslider == null) lifeslider = GetComponent<Slider>();
	}
	private void Update()
	{
		if (lifeslider != null) lifeslider.value = life;
		if (life <= 0)
		{
			Destroy(gameObject);
			if (lifeslider != null) PlayerManager.Instance.DefeatScene();
		}
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			anim.SetBool("Hit", true);
			life -= PlayerManager.Instance.enemyDmg;

		}
		
	}
	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag.Equals("Enemy"))
		{
			anim.SetBool("Hit", false);
		}
	}
}