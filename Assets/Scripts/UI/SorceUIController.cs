using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SorceUIController : MonoBehaviour
{
    [SerializeField] GameObject scoringCanvas;
    [SerializeField] Transform highScoreContainer;


    private void Awake()
    {
        SaveCurrentScoreEvent.Register(SaveCurrentScore);

    }

    private void OnEnable()
    {
        //ShowHightScoreLeaderBoard();

    }
    private void OnDisable()
    {
        SaveCurrentScoreEvent.UnRegister(SaveCurrentScore);

    }
    public void ShowHightScoreLeaderBoard()
    {
        var playerScoreList = ScoreManager.instances.LoadPlayerScore().playList;

        for (int i = 0; i < highScoreContainer.childCount; i++)
        {
            var child =   highScoreContainer.GetChild(i);
            child.Find("txt_Rank").GetComponent<Text>().text = (i + 1).ToString(); 
            child.Find("txt_Score").GetComponent<Text>().text = playerScoreList[i].score.ToString(); 
           // child.Find("txt_Name").GetComponent<Text>().text = playerScoreList[i].name.ToString(); 
        }
    }
    public static void ShowCurrentScore()
    {
        string currentScore = SaveSystem.LoadFromPlayerPrefs("CurrentSocre");
         GameObject.Find("Status").GetComponentInChildren<Text>().text = "Score : " + currentScore;
    }
    public void SaveCurrentScore()
    {
        SaveSystem.SaveByPlayerPrefs("CurrentSocre", PlayerStatus.Instance.Score.ToString());
    }
}
