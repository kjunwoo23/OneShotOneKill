using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    public bool bossCleared;
    public GameObject boss;
    public GameObject bossSpawn;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBoss()
    {
        SoundManager.instance.ChangeBGM(1);
        bossSpawn.SetActive(false);
        boss.SetActive(true);
    }

    public IEnumerator GameClear()
    {
        SoundManager.instance.ChangeBGM(2);
        Player.instance.enabled = false;
        while (LoadManager.instance.fade.color.a < 1)
        {
            LoadManager.instance.fade.color += new Color(0, 0, 0, Time.deltaTime * 0.1f);
            yield return null;
        }
    }
}
