using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdShaderFly : MonoBehaviour
{
    public float speed = 10.0f;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + Time.deltaTime * speed, transform.position.y + speed * Time.deltaTime, transform.position.z);
    }
}
