using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;
public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;

    public Flowchart flowchart;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
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

    public void QuitGame()
    {
        Application.Quit();
    }
}
