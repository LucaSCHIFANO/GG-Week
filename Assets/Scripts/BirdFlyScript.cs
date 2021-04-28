using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlyScript : MonoBehaviour
{
    public float speed = 10.0f;
    private Vector3 startPos;
    private void Awake()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        Camera cam = Camera.main;
        float camWidth = cam.orthographicSize * cam.aspect * 2f;
        float posX = transform.position.x;
        if(posX < camWidth)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = startPos;
        }
       
    }
}
