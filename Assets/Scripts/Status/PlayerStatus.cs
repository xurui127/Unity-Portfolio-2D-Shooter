using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : CharacterStatus
{
    private static PlayerStatus instance;
    [SerializeField] private int score;
    [SerializeField] private float maxBombNum;
    [SerializeField] private float curBombNum;
    [SerializeField] private int lives;


    public static PlayerStatus Instance => instance;

    public int Lives {
        get => lives ;
        set
        {
            this.lives = value;
            PlayerLivesEvent.Trigger();
            if (!value.Equals(lives))
            {
                this.lives = value;
            }
         
        }
    }
    private void Start()
    {
      
      
        

    }
    public override float CurHealth
    {
       
        get => curHealth;
        set
        {
            if (!value.Equals(curHealth))
            {
                this.curHealth = value;
                PlayerHPEvent.Trigger();
                if (curHealth <=0)
                {
                    this.lives--;
                    this.curHealth = MaxHealth;
                    transform.position = CameraToPosition.instance.ResetPlayerPosition();
                    PlayerLivesEvent.Trigger();
                }
            }

        }
    }
    public int Score
    {
        get => score;
        set
        {
            this.score = value;
            PlayerScoreEvent.Trigger();
            if (!value.Equals(score))
            {
                score = value;
                PlayerScoreEvent.Trigger();
            }
        }
    }

    #region // Player Delegates 
    public delegate void PlayerHurt(float _damage);
    public static PlayerHurt playerHurt;

    public delegate void PlayerGetScore(int _score);
    public static PlayerGetScore playerGetScore;

    public delegate void PlayerLooseLives(int _lives);
    public static PlayerLooseLives playerLooseLives;


    #endregion
    private void Awake()
    {
        GetInstance();
        playerHurt = GetHurt;
        playerGetScore = GetScore;
        playerLooseLives = LooseLives;

    }
  
    private void GetInstance()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    private void GetScore(int _score)
    {
        Score += _score;
    }
    private void LooseLives(int _lives)
    {
        Lives -= _lives;
 

    }
    protected void GetHurt(float _damage)
    {
        CurHealth -= _damage;
    }
    public bool HasNewHighScore()
    {
        if (score > ScoreManager.instances.LoadPlayerScore().playList[4].score)
        {
            return true;
        }
        return false;
    }


}
