using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


[RequireComponent(typeof(Slider))]
public class SetVol : MonoBehaviour
{
    [SerializeField] private AudioMixer audioM;
    [SerializeField] private string nameParam;
    private Slider slider;


    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        float v = PlayerPrefs.GetFloat(nameParam, 0);
        slider.value = v;
        audioM.SetFloat(nameParam, v);
    }

    public void SetVolum(float vol)
    {
        audioM.SetFloat(nameParam, vol);
        slider.value = vol;
        PlayerPrefs.SetFloat(nameParam, vol);
    }
}
