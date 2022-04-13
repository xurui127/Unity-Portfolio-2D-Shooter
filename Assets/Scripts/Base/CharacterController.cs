using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{

    // [SerializeField] protected Rigidbody2D rigid;
    [SerializeField] protected GameObject projectile;
    [SerializeField] public Transform[] muzzles;
    public virtual void OnMove(){}
    public virtual void OnFire() { }
    public virtual void OffFire() { }

    protected virtual IEnumerator Fire() { yield return null;  }
  
}

