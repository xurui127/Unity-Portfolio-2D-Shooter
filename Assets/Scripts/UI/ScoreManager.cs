using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class PlayerScore
{
   public int score;

    public PlayerScore(int _score)
    {
        this.score = _score;
    }
}

[System.Serializable]
public class PlayerScoreList
{
     public List<PlayerScore> playList = new List<PlayerScore>();
}

public class ScoreManager : MonoBehaviour
{


    public static ScoreManager instances;
    readonly  string SavePlayerData = "player_score.json";
   // string playerName = "No Name";




    private void Awake()
    {
        GetInstance();
        SaveNewScore.Register(SavePlayerScore);
        
    }
    private void OnDisable()
    {
        SaveNewScore.UnRegister(SavePlayerScore);
    }
    private void GetInstance()
    {
        if (instances != null)
        {
            Destroy(this);
        }
        else
        {
            instances = this;
        }
    }

    void SavePlayerScore()
    {
        var playerScoreData = LoadPlayerScore();
        playerScoreData.playList.Add(new PlayerScore(PlayerStatus.Instance.Score));
        playerScoreData.playList.Sort((x, y) => y.score.CompareTo(x.score));
        SaveSystem.SaveByJson(SavePlayerData, playerScoreData);
        Debug.Log("Save to jason");
    }
    public  PlayerScoreList LoadPlayerScore()
    {
        var playerScoreData = new PlayerScoreList();
        //playerScoreData = SaveSystem.LoadFromJson<PlayerScoreList>(SavePlayerData);
        if (SaveSystem.SaveFileExists(SavePlayerData))
        {
            playerScoreData = SaveSystem.LoadFromJson<PlayerScoreList>(SavePlayerData);
           
        }
        else
        {
            while (playerScoreData.playList.Count < 5)
            {
                playerScoreData.playList.Add(new PlayerScore(0));
            }
            SaveSystem.SaveByJson(SavePlayerData, playerScoreData);
            Debug.Log("In eles");

        }
        return playerScoreData;
    }

 
}
