using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalParallaxEffect : MonoBehaviour
{
    public float speed = 1.0f;

    private Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + speed);    
    }

    public void ResetParallaxPosition()
    {
        transform.position = startPos;
    }
}
