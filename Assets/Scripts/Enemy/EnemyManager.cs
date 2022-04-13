using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] List<GameObject> enemyList;
    [SerializeField] float enemySpawnTime = 1f;
    public static int enemyWave;
    private int enemyAmount = 1;
    private float waveBetweenTime = 1f;
    WaitForSeconds waitEnemySpawnTime;
    WaitForSeconds waitNextWave;
    WaitUntil waitUntilListEmpty;
    private int BossWaveNumber=3;
    private int enemyMinAmount = 4;
    private int enemyMaxAmount = 10;

    [SerializeField] private bool spawnEnemy = true;

    // public delegate void RemoveToList(GameObject enemy);
    //public RemoveToList removeTolist;
    private void Awake()
    {
        GetInstance();
        enemyList = new List<GameObject>();
        waitEnemySpawnTime = new WaitForSeconds(enemySpawnTime);
        waitNextWave = new WaitForSeconds(waveBetweenTime);
        waitUntilListEmpty = new WaitUntil(() => enemyList.Count == 0);
        enemyWave = 0;
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

    IEnumerator Start()
    {
      
        while (spawnEnemy)
        {
            yield return waitUntilListEmpty;
        
          
            yield return StartCoroutine(nameof(RandomEnemySpawnCoroutine));
            Debug.Log(enemyWave);
            
        }
    }
    private void OnDisable()
    {
        //  StopCoroutine(nameof(RandomEnemySpawnCoroutine));
    }
    IEnumerator RandomEnemySpawnCoroutine()
    {
        if (enemyWave<5)
        {


            enemyAmount = Mathf.Clamp(enemyAmount, enemyMinAmount + enemyWave / BossWaveNumber, enemyMaxAmount);

            for (int i = 0; i < enemyAmount; i++)
            {
                var enmey = PoolManager.Release(enemyPrefab[Random.Range(0, enemyPrefab.Length-1)]);
                enemyList.Add(enmey);


                yield return waitEnemySpawnTime;
            }
            enemyWave++;
        }
        else
        {

            for (int i = 0; i < 1; i++)
            {
                var boss = PoolManager.Release(enemyPrefab[3]);
                enemyList.Add(boss);
                enemyWave++;
            }


        }

    }
    public void RemoveEnemy(GameObject enemy)
    {

        enemyList.Remove(enemy);
    }
}
