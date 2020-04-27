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
    }
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
            anim.SetBool("Hit", true);
            life -= PlayerManager.Instance.enemyDmg;

        }
        
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Enemy"))
        {
            anim.SetBool("Hit", false);

        }
    }
}