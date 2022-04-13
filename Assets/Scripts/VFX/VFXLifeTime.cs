using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXLifeTime : MonoBehaviour
{

    [SerializeField] float lifeTime;
    WaitForSeconds waitLifeTime;
    private void Awake()
    {
        waitLifeTime = new WaitForSeconds(lifeTime);
    }
    private void OnEnable()
    {
        StartCoroutine(DeactiveGameObject());

    }
    private void OnDisable()
    {
       // StopCoroutine(DeactiveGameObject());
    }
    IEnumerator DeactiveGameObject()
    {
        yield return waitLifeTime;
        if (gameObject.activeSelf)
        {
        gameObject.SetActive(false);
        }

    }
}
