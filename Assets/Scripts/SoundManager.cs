using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Sound
{
    public string soundName;
    public AudioClip clip;
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource bgmPlayer;
    public Sound[] bgmSounds;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeBGM(int i)
    {
        bgmPlayer.clip = bgmSounds[i].clip;
        bgmPlayer.time = 0;
        bgmPlayer.Play();
    }
}