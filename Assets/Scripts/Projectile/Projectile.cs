using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0,2)]
    [SerializeField] private float speed;
    [SerializeField] private Vector2 moveDiric;
    [SerializeField] private float projectileDamage;

   protected virtual void OnEnable()
    {
       
        
        StartCoroutine(Move());
       

    }
    protected virtual void OnDisable()
    {
        StopCoroutine(Move());
    }

   protected IEnumerator Move()
    {
        while (gameObject.activeSelf)
        {
            transform.Translate(moveDiric * speed * Time.deltaTime);
            yield return null;
        }
    }
   

}
