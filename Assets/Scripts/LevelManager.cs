using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;
public class LevelManager : MonoBehaviour
{
    public Flowchart flowchart;

    public static LevelManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            //SceneManager.sceneLoaded += OnLevelFinishedLoading;
            
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NextSceneByName()
    {
        string sceneName = flowchart.GetStringVariable("SceneName");
        SceneManager.LoadScene(sceneName);
    }
    public void DefeatScreen()
    {
        SceneManager.LoadScene("DefeatScreen");
    }
    public void VictoryScreen()
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
        GetFlowchart();

        //SoundManager.cs
        GameEvents.sceneIsLoaded.Invoke();
    }

    public void GetFlowchart()
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
    public void QuitGame()
    {
        Application.Quit();
    }
}
