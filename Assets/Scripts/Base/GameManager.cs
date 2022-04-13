using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject panel;
    [SerializeField]private int enemyCounter;
    private int playerLives;
    private bool pause =false;

    public int EnemyCounter
    {
        get => enemyCounter;
        set
        {
             enemyCounter = value;
        }
    }

    
    public bool Pause
    {
        get => pause;
        set
        {
            if (pause == true)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }

    private void Awake()
    {
     
        //EndGameEvent.Register(GameEnd);
        EnemyCounterEvent.Register(EnemyCounters);
    }

    private void Start()
    {

    }

    private void Update()
    {
       GameEnd();
      
    }
    private void OnDisable()
    {
       // EndGameEvent.UnRegister(GameEnd);
        EnemyCounterEvent.UnRegister(EnemyCounters);
    }

    public void OnPause()
    {
        Pause = true; 
    }
    public void OnUnPause()
    {
        Pause = false;
        panel.SetActive(false);
    }

    private void GameEnd()
    {
        if (PlayerStatus.Instance.Lives < 0 || EnemyManager.enemyWave>6 )
        {
            if (PlayerStatus.Instance.HasNewHighScore()==true)
            {
                SaveNewScore.Trigger();
            }
            SaveSystem.SaveByPlayerPrefs("CurrentSocre", PlayerStatus.Instance.Score.ToString());
            LoadScene.BtnLoadScene(3);
        }
    }

    // Count Enemy number, if Enemy destroy counter by 1 
     public void EnemyCounters()
    {
        enemyCounter++;
    }

}
