using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileDamage : ProjectileDamage
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.CompareTag(tag))
        {
            PlayerStatus.playerHurt(projectileDamage);
           
            gameObject.SetActive(false);
        }
    }

}
