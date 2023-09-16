using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartNew()
    {
        PlayerPrefs.SetInt("continue", 0);
        SceneManager.LoadScene("SampleScene");
    }
    public void OnClickContinue()
    {
        PlayerPrefs.SetInt("continue", 1);
        SceneManager.LoadScene("SampleScene");
    }
    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
