using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    #region  PlayerPrefs
    public static void SaveByPlayerPrefs(string key, string data)
    {
        //var json = JsonUtility.ToJson(data);

        PlayerPrefs.SetString(key, data);
        PlayerPrefs.Save();


#if UNITY_EDITOR
        Debug.Log($"data to PlayerPrefs suscess.Key:{key} Data:{data} ");
#endif 
    }

    public static string LoadFromPlayerPrefs(string key)
    {
#if UNITY_EDITOR
        Debug.Log("data loaded");
#endif
        return PlayerPrefs.GetString(key);

    }
    #endregion

    #region //Json

    public static void SaveByJson(string saveFileName, object data)
    {
        var json = JsonUtility.ToJson(data);
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        Debug.Log("data loaded jason");
        try
        {
            File.WriteAllText(path, json);
#if UNITY_EDITOR
            Debug.Log($" data to ${path} suscess ");
#endif
        }
        catch
        {
#if UNITY_EDITOR
            Debug.Log($" data to ${path} failed ");
#endif
        }


    }

    public static T LoadFromJson<T>(string saveFileName)
    {

        var path = Path.Combine(Application.persistentDataPath, saveFileName);

        try
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(json);
            return data;
        }
        catch (System.Exception exception)
        {
#if UNITY_EDITOR
            Debug.LogError($" data to {path} failed. \n {exception} ");
#endif
            return default;
        }
    }

    public static void DeleteSaveFile(string saveFileName)
    {
#if UNITY_EDITOR
        var path = Path.Combine(Application.persistentDataPath, saveFileName);

        try
        {
            File.Delete(path);
        }
        catch (System.Exception exception)
        {

#if UNITY_EDITOR
            Debug.LogError($" data to {path} failed. \n {exception} ");
#endif
        }
#endif
    }

    public static bool SaveFileExists(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        return File.Exists(path);
    }
    #endregion
}
