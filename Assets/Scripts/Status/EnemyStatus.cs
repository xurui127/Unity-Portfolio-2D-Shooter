using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : CharacterStatus
{
   
    [SerializeField] private int enemyScore;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject vfx_Death;
    [SerializeField] private EnemyManager enemyManager;
   // [SerializeField] private float curHealth;


    public delegate void EnemyHurt(float _damage);
    public  EnemyHurt enemyHurt;
 


    public override float CurHealth
    {
        get =>curHealth;
        set
        {
           
            if (!value.Equals(curHealth))
            {
                curHealth = value;
                if (curHealth <= 0)
                {
                    enemyManager.RemoveEnemy(gameObject);
                    PoolManager.Release(vfx_Death, transform.position);
                    AudioManager.instance.PlayAudioClips(0);
                    this.gameObject.SetActive(false);


                }
            }
       
        }
    }

  

    private void OnEnable()
    {

    }
    private void OnDisable()
    {
        //EnemyManager.instance.RemoveEnemy(this.gameObject);

        PlayerStatus.playerGetScore(enemyScore);
        EnemyCounterEvent.Trigger();
    }

    private void Awake()
    {
        enemyHurt = GetHurt;
       
    }
    protected void GetHurt(float _damage )
    {
        CurHealth -= _damage;
    }



}
