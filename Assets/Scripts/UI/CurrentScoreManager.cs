using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SorceUIController.ShowCurrentScore();
        Screen.SetResolution(720, 1280, true);
    }
}
