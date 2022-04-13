using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PojectileLifeTime : MonoBehaviour
{
    [SerializeField] bool destroyGameObject = false;
    [SerializeField] float lifeTime;
    WaitForSeconds waitLifeTime;
    private void Awake()
    {
        waitLifeTime = new WaitForSeconds(lifeTime);
    }
    private void OnEnable()
    {
        StartCoroutine(DeactiveGameObject());
        destroyGameObject = false;
    }
    private void OnDisable()
    {
        StopCoroutine(DeactiveGameObject());
    }
    IEnumerator DeactiveGameObject()
    {
        yield return waitLifeTime;
        if (destroyGameObject)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
  

}
