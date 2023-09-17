using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Effect
{
    public string soundName;
    public AudioClip clip;
    public AudioSource source;
}

public class EffectManager : MonoBehaviour
{
    public static EffectManager instance;
    [Header("효과음 이름")]
    [SerializeField]
    public Effect[] effectSounds;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < effectSounds.Length; i++)
        {
            effectSounds[i].source = gameObject.AddComponent<AudioSource>();
            effectSounds[i].source.clip = effectSounds[i].clip;
            effectSounds[i].source.loop = false;
            effectSounds[i].source.volume = 0.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EffectSoundsPlay(int i)
    {
        effectSounds[i].source.Play();
    }
}