using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class AffectionBar : MonoBehaviour
{
    public Flowchart flowchart;
    public ProgressBar progressBar;
    public float duration = 0.5f;

    public Sprite heart;
    public Sprite brokenHeart;

    public void SetAffection()
    {
        float valueToAdd = flowchart.GetFloatVariable("Affection");
        float value = progressBar.current + valueToAdd;
        StartCoroutine(FillAnimation(value));
        Debug.Log("Affection Call Function");

        if(valueToAdd > 0)
        {
            PlayPositiveFeedback();
        }
        else
        {
            PlayNegativeFeedback();
        }
    }

    public void PlayPositiveFeedback()
    {

    }

    public void PlayNegativeFeedback()
    {

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
