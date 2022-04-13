using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private static AsyncOperation async;

    public void BtnLoadScene()
    {
        if (async == null)
        {
            Scene currScene = SceneManager.GetActiveScene();
            async = SceneManager.LoadSceneAsync(currScene.buildIndex + 1);
            async.allowSceneActivation = true;
        }
    }
    public static void BtnLoadScene(int i)
    {
        async = SceneManager.LoadSceneAsync(i);
        async.allowSceneActivation = true;
    }
    public static void BtnLoadScene(string s)
    {
        async = SceneManager.LoadSceneAsync(s);
        async.allowSceneActivation = true;
    }
}
