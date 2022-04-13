using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    [SerializeField] private Text score;
    [SerializeField] private Image health;
    [SerializeField] private Text playerLives;
    [SerializeField] private PlayerStatus status;
    [SerializeField] private GameObject pausePanel;
    

    private bool pause = false;

    public bool Pause { get => pause; set => pause = value; }
    public static UIManager Instance => instance;
    void Awake()
    {
        
        GetInstance();
        PlayerHPEvent.Register(PlayerHealthChange);
        PlayerScoreEvent.Register(PlayerScoreChange);
        PlayerLivesEvent.Register(PlayerLivesChange);
        PlayerHPEvent.Trigger();
        PlayerScoreEvent.Trigger();
        PlayerLivesEvent.Trigger();
    }
    private void OnEnable()
    {

    }
    void OnDisable()
    {
        PlayerHPEvent.UnRegister(PlayerHealthChange);
        PlayerScoreEvent.UnRegister(PlayerScoreChange);
        PlayerLivesEvent.UnRegister(PlayerLivesChange);
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
    private void PlayerHealthChange()
    {
        if (PlayerStatus.Instance!=null)
        {
         health.fillAmount = PlayerStatus.Instance.CurHealth / 100f;
        }
    }

    private void PlayerScoreChange()
    {
        if (PlayerStatus.Instance != null)
        {
            score.text = PlayerStatus.Instance.Score.ToString("D5");
        }
    }
    private void PlayerLivesChange()
    {
         playerLives.text = " X " + " " + PlayerStatus.Instance.Lives.ToString();
        //if (PlayerStatus.Instance != null)
        //{
        //}
    }
    public void OnPause()
    {
        pause = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
       // Debug.Log("Pause On");

    }
    public void OnUnPause()
    {
      //  Debug.Log("UnPause");
        pause = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

}
