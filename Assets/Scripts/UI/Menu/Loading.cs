using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.Xml.Serialization;

public class Loading : MonoBehaviour
{
    private AsyncOperation async;

    [SerializeField] private Image progressBar;
    [SerializeField] private Text txtPercent;

    [SerializeField] private bool waitForUserInput = false;
    private bool ready = false;
    [SerializeField] private float delay = 0;
    [SerializeField] private int sceneToLoad = -1;

    private void Start()
    {
        Time.timeScale = 1.0f;
        Input.ResetInputAxes();
        System.GC.Collect();
        Scene currScene = SceneManager.GetActiveScene();
        if (sceneToLoad <=-1)
        {
            async = SceneManager.LoadSceneAsync(currScene.buildIndex + 1);
        }
        else
        {
            async = SceneManager.LoadSceneAsync(sceneToLoad);
        }
        async.allowSceneActivation=false;
        if (waitForUserInput ==false)
        {
            Invoke("Activate", delay);
        }
    }

    public void Activate()
    {
        ready = true;
    }

    private void Update()
    {
        if (waitForUserInput && Input.anyKey)
        {
            ready = true;
        }
        if (progressBar)
        {
            progressBar.fillAmount = async.progress + 0.1f;
        }
        if (txtPercent)
        {
            txtPercent.text = ((async.progress + 0.1f) * 100f).ToString("F2") + "%";
        }
        if (async.progress >=0.89f && SplashScreen.isFinished&& ready)
        {
            async.allowSceneActivation = true;
        }
    }
}
