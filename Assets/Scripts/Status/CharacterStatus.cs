using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{

    [SerializeField]  float maxHealth;
    [SerializeField] protected float curHealth;
    [SerializeField] float speed;
    [SerializeField] float fireInterval;
    [SerializeField] float moveInterval;
   

    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public virtual float CurHealth { get => curHealth; set => curHealth = value; }
    public float Speed { get => speed; }
    public float FireInterval { get => fireInterval; }
    public float MoveInterval { get => moveInterval; }
    //protected void GetHurt(float _damage , float _curHealth)
    //{
    //    _curHealth -= _damage;
    //}

}
