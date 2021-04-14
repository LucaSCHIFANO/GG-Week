using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Flowchart flowchart;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void changeScene()
    {
        float sceneName = flowchart.GetFloatVariable("Affection");
        SceneManager.LoadScene("sceneName");
    }
}
