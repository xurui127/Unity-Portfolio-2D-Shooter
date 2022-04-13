using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileDamage : ProjectileDamage
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.CompareTag(tag))
        {
            EnemyStatus enemyStatus = collision.GetComponent<EnemyStatus>();

            enemyStatus.enemyHurt(projectileDamage);
           
            gameObject.SetActive(false);
            
        }
    }

}
