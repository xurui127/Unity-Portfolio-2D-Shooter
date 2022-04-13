using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    [SerializeField] protected string tag;
    [SerializeField] protected float projectileDamage;
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
