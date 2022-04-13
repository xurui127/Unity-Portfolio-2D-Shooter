using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //create Player projectile pool
    [SerializeField] Pool[] playerProjectilePools;
    [SerializeField] Pool[] enemyProjectilePools;
    [SerializeField] Pool[] enemyPrefab;
    [SerializeField] Pool[] vfx_Death;
    [SerializeField] Pool[] player;
    static Dictionary<GameObject, Pool> dictionary;
    private void Start()
    {
        dictionary = new Dictionary<GameObject, Pool>();
        Init(player);
        Init(playerProjectilePools);
        Init(enemyProjectilePools);
        Init(enemyPrefab);
        Init(vfx_Death);

    }
#if UNITY_EDITOR
    void CheckPoolSize(Pool[] pools)
    {
        foreach (var pool in pools)
        {
            if (pool.RunTimeSize > pool.Size)
            {
                Debug.LogWarning(string.Format("pool: {0} has a runsize {1} bigger than initial size {2} ",
                                  pool.Prefab.name,
                                  pool.RunTimeSize,
                                  pool.Size));

            }
        }
    }
    private void OnDestroy()
    {
        CheckPoolSize(playerProjectilePools);
    }
#endif
    // Intialize all prefab in pools
    private void Init(Pool[] pools)
    {
        foreach (var pool in pools)
        {
#if UNITY_EDITOR
            if (dictionary.ContainsKey(pool.Prefab))
            {
                Debug.Log("dictionary contains prefab" + pool.Prefab.name);
                continue;
            }
#endif
            dictionary.Add(pool.Prefab, pool);
            // Create a object that contains all the prefab in Hierachy 
            Transform poolParent = new GameObject("Pool : " + pool.Prefab.name).transform;
            // set poolParent to Pool manager as a child object 
            poolParent.parent = transform;
            pool.Init(poolParent);
        }
    }
    public static GameObject Release(GameObject prefab)
    {
#if UNITY_EDITOR
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.Log("Dictionary not contain Prefab" + prefab.name);
            return null;
        }
#endif
        return dictionary[prefab].PreparedObject();
    }
    public static GameObject Release(GameObject prefab, Vector3 position)
    {
#if UNITY_EDITOR
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.Log("Dictionary not contain Prefab" + prefab.name);
            return null;
        }
#endif
        return dictionary[prefab].PreparedObject(position);
    }
    public static GameObject Release(GameObject prefab, Vector3 position, Quaternion rotation)
    {
#if UNITY_EDITOR
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.Log("Dictionary not contain Prefab" + prefab.name);
            return null;
        }
#endif
        return dictionary[prefab].PreparedObject(position, rotation);
    }
    public static GameObject Release(GameObject prefab, Vector3 position, Quaternion rotation, Vector3 localScale)
    {
#if UNITY_EDITOR
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.Log("Dictionary not contain Prefab" + prefab.name);
            return null;
        }
#endif
        return dictionary[prefab].PreparedObject(position, rotation, localScale);
    }


}


