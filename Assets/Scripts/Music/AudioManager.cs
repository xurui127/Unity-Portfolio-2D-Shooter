using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioM;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private string[] nameParam;

    public static AudioManager instance;
    private void Awake()
    {
        if (instance ==null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        SetVolum();

    }
    private void SetVolum()
    {
        for (int i = 0; i < nameParam.Length; i++)
        {
            float v = PlayerPrefs.GetFloat(nameParam[i]);
            audioM.SetFloat(nameParam[i], v);
        }
    }
    public  void PlayAudioClips(int i)
    {
        //AudioSource audioSource = GetComponent<AudioSource>();
        //audioSource.clip = audioClips[i];
        //audioSource.Play();
        audioSources[i].Play();
       // audioClips[i].Play();
    }

}
