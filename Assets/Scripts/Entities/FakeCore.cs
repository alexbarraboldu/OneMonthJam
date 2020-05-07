using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCore : MonoBehaviour
{
    public int life;

    void Update()
    {
        if (life <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            life -= PlayerManager.Instance.enemyDmg;
    }

}
