using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1.0f);
        GetComponent<Rigidbody2D>()
            .AddForce(transform.up * 400);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag.Equals("Enemy"))
        {
            Destroy(c.gameObject);
            GameController.Instance.IncrementScore();

        }
        if (c.gameObject.tag.Equals("edges"))
        {
            Destroy(gameObject);
        }
    }
}
