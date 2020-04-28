using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    public GameObject loot; 
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            GameObject explosionclone = Instantiate(explosion, this.transform.position, Quaternion.identity);
            GameObject lootclone = Instantiate(loot, this.transform.position, Quaternion.identity);
            Destroy(explosionclone, 1.0f);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject explosionclone = Instantiate(explosion, this.transform.position, Quaternion.identity);
            GameObject lootclone = Instantiate(loot, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(explosionclone, 1.0f);
        }
    }
}
