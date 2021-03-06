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

    public Transform spawnParticule;
    public Transform spawnParticule2;

    public GameObject love;
    public GameObject breaked;

    public float soundDuration = 2.0f;

    private void Awake()
    {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        spawnParticule = GameObject.Find("SpawnHeart").GetComponent<Transform>();
        spawnParticule2 = GameObject.Find("SpawnHeart (1)").GetComponent<Transform>();
    }
    public void SetAffection()
    {
        float valueToAdd = flowchart.GetFloatVariable("Affection");
        float value = progressBar.current + valueToAdd;
        flowchart.SetFloatVariable("TotalAffection", value);
        StartCoroutine(FillAnimation(value));
        //Debug.Log("Affection Call Function");

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
        Instantiate(love, spawnParticule.position, spawnParticule.rotation);
        StartCoroutine(HeartBeatSound("battement_rapide"));
    }

    public void PlayNegativeFeedback()
    {
        Instantiate(breaked, spawnParticule2.position, spawnParticule2.rotation);
        StartCoroutine(HeartBeatSound("brokenHeart"));
    }

    IEnumerator HeartBeatSound(string name)
    {
        FindObjectOfType<SoundManager>().PlaySound(name);
        yield return new WaitForSeconds(soundDuration);
        FindObjectOfType<SoundManager>().StopSound(name);
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
        //Debug.Log("debug" + progressBar.current + newValue);
    }
}
