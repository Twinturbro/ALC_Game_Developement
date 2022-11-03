using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float attackDelay;
    public float startDelay;
    public Transform attackpos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    // Update is called once per frame
    void Update()
    {
        if (attackDelay <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackpos.position, attackRange, whatIsEnemies);

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }

                attackDelay = startDelay;
            }
        }
        else
        {
            attackDelay -= Time.deltaTime;
        }
    }
}