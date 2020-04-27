using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Core : MonoBehaviour
{
    public int life;
    public Slider lifeslider;

    private void Update()
    {
        lifeslider.value = life;
        if (life <= 0)
        {
            Destroy(gameObject);
            PlayerManager.Instance.DefeatScene();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            life -= PlayerManager.Instance.enemyDmg;
        }
    }
}