using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScatter : Projectile
{
    private Vector3 curScale = new Vector3(0.3f, 0.3f, 0.3f);

    private Vector3 defaultScale = new Vector3();

   protected override void OnEnable()
    {
        StartCoroutine(Move());
        //curScale = transform.localScale;
        defaultScale = transform.localScale;
        StartCoroutine(ScaleChange());
    }
    protected  override void OnDisable()
    {
        transform.localScale = defaultScale;
        StopCoroutine(Move());
        StopCoroutine(ScaleChange());
    }
    protected IEnumerator ScaleChange()
    {
        
        yield return new WaitForSeconds(0.5f);
        transform.localScale += curScale;
        yield return new WaitForSeconds(0.5f);
    }
}
