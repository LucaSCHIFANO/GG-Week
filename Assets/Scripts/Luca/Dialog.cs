using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDispaly;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        
    }

    IEnumerator Type()
    {
        foreach ( char letter in sentences[index].ToCharArray())
        {
            textDispaly.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
