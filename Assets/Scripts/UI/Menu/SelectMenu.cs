using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMenu : MonoBehaviour
{
    [SerializeField] private Selectable[] defaultBtn;
    [SerializeField] private GameObject[] panels;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.01f);
        PanelToggle(0);
        
    }
    public void PanelToggle(int pos)
    {
        Input.ResetInputAxes();
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(pos == i);
            if (pos==i)
            {
                defaultBtn[i].Select();
            }
        }
    }
    public void SavePrefs()
    {
        PlayerPrefs.Save();
    }
}
