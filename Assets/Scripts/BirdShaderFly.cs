using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdShaderFly : MonoBehaviour
{
    public float speed = 10.0f;
    private Vector2 startPos;
    private void Start()
    {
        startPos = transform.position;
        FindObjectOfType<SoundManager>().PlaySound("Seagull");
    }
    // Update is called once per frame
    void Update()
    {
        Camera cam = Camera.main;
        float camHeight = 2.0f * cam.orthographicSize;
        float posY = transform.position.y;
        if(posY < camHeight * 4.0f)
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * speed, transform.position.y + speed * Time.deltaTime, transform.position.z);
        }
        else
        {
            transform.position = startPos;
            FindObjectOfType<SoundManager>().PlaySound("Seagull");
        }

    }
}
