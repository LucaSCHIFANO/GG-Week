using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class AffectionBar : MonoBehaviour
{
    public Flowchart flowchart;
    public ProgressBar progressBar;
    public float duration = 0.5f;


    public void SetAffection()
    {
        float value = progressBar.current + flowchart.GetFloatVariable("Affection");
        StartCoroutine(FillAnimation(value));
        Debug.Log("Affection Call Function");
    }

    IEnumerator FillAnimation(float newValue)
    {
        float timer = 0.0f;
        float min = progressBar.current;
        while(timer <= duration)
        {
            timer += Time.deltaTime;
            float ratio = timer / duration;
            float value = Mathf.Lerp(min, newValue, ratio);
            progressBar.SetCurrentFill(value);
            yield return new WaitForEndOfFrame();
        }

        progressBar.SetCurrentFill(newValue);
    }
}
