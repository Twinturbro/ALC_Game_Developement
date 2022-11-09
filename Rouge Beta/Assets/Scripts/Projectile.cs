using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    private Transform player;
    private Vector2 target;
    private Health playerHealth;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();// get players position
        target = new Vector2(player.position.x, player.position.y);//aim at the target/player
        playerHealth = GameObject.Find("Player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);


        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.CompareTag("Player"))
       {
            DestroyProjectile();
            playerHealth.TakeDamage(damage);
        }

    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
