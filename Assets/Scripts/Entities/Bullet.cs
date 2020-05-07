using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	void Start()
	{
		Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Core").GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), true);
	}
}
