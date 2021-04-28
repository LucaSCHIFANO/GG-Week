using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;
public class LevelManager2 : MonoBehaviour
{
    public Flowchart flowchart;

    //public static LevelManager instance;
    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(this.gameObject);
    //        //SceneManager.sceneLoaded += OnLevelFinishedLoading;

    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
    public void NextScene2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NextSceneEnterString2(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void NextSceneByName2()
    {
        string sceneName = flowchart.GetStringVariable("SceneName");
        SceneManager.LoadScene(sceneName);
    }
    public void DefeatScreen2()
    {
        SceneManager.LoadScene("DefeatScreen");
    }
    public void VictoryScreen2()
    {
        SceneManager.LoadScene("VictoryScreen");
    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Level Loaded");
        Debug.Log(scene.name);
        GetFlowchart2();

        //SoundManager.cs
        GameEvents.sceneIsLoaded.Invoke();
    }

    public void GetFlowchart2()
    {
        try
        {
            flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        }
        catch
        {
            Debug.Log("Scene Loader : No Flow chart");
        }

    }
    public void QuitGame2()
    {
        Application.Quit();
    }
}
