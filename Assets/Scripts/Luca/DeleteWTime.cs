using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteWTime : MonoBehaviour
{
    public float number;
    void Start()
    {
        StartCoroutine("death");
    }

    public IEnumerator death()
    {
        yield return new WaitForSeconds(number);
        Destroy(gameObject);
    }
}

