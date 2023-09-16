using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public static LoadManager instance;
    public Transform[] spawnPoints;
    public RawImage fade;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("continue")){
            if (PlayerPrefs.GetInt("continue") == 0)
                ; //처음부터
            else
            {
                //이어서
                int tmp = PlayerPrefs.GetInt("saved");
                Player.instance.transform .position = spawnPoints[tmp].position;
            }
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickBulb()
    {
        SceneManager.LoadScene("Main");
    }

    public IEnumerator GameOver()
    {
        Player.instance.enabled = false;
        yield return new WaitForSeconds(1f);

        fade.color = new Color(0, 0, 0, 1);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SampleScene");
    }
}
