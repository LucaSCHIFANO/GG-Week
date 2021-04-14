using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WineSimulation : MonoBehaviour
{
    public GameObject wine;
    public float speed = 0.1f;

    private float widthLimit;
    private float heightLimit;
    private float wineWidthLimit;
    private float wineHeightLimit;

    private void Start()
    {
        widthLimit = GetComponent<SpriteRenderer>().bounds.size.x /2;
        heightLimit = GetComponent<SpriteRenderer>().bounds.size.y /2;

        wineWidthLimit = wine.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        wineHeightLimit = wine.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }
    public void MoveUp()
    {
        float limit = heightLimit - wineHeightLimit;
        if(wine.transform.position.y < transform.position.y + limit)
        {
            wine.transform.position = new Vector3(
                wine.transform.position.x, 
                wine.transform.position.y + speed, 
                wine.transform.position.z);
        }
        //else {
        //    wine.transform.position = new Vector3(
        //        transform.position.x,
        //        transform.position.y + limit,
        //        transform.position.z);
        //}

    }

    public void MoveUpInsta()
    {
        float limit = heightLimit - wineHeightLimit;
        if (wine.transform.position.y < transform.position.y + limit)
        {
            wine.transform.position = new Vector3(
                transform.position.x,
                transform.position.y + limit,
                transform.position.z);
            Debug.Log(wine.transform.position);
        }
    }
    public void MoveDown()
    {
        float limit = heightLimit - wineHeightLimit;
        if (wine.transform.position.y > transform.position.y - limit)
        {
            wine.transform.position = new Vector3(
                wine.transform.position.x, 
                wine.transform.position.y - speed, 
                wine.transform.position.z);
        }
        //else {
        //    wine.transform.position = new Vector3(
        //        transform.position.x,
        //        transform.position.y - limit,
        //        transform.position.z);
        //}
    }

    public void MoveDownInsta()
    {
        float limit = heightLimit - wineHeightLimit;
        if (wine.transform.position.y > transform.position.y - limit)
        {
            wine.transform.position = new Vector3(
                wine.transform.position.x,
                wine.transform.position.y - limit,
                wine.transform.position.z);
        }
    }

    public void MoveLeft()
    {
        float limit = widthLimit - wineWidthLimit;
        if (wine.transform.position.x > transform.position.x - limit)
        {
            wine.transform.position = new Vector3(
                wine.transform.position.x - speed, 
                wine.transform.position.y, 
                wine.transform.position.z);
        }

        //if (wine.transform.position.x > transform.position.x - limit)
        //{
        //    wine.transform.position = new Vector3(
        //        transform.position.x - limit,
        //        transform.position.y,
        //        transform.position.z);
        //}
    }

    public void MoveLeftInsta()
    {
        float limit = widthLimit - wineWidthLimit;
        if (wine.transform.position.x > transform.position.x - limit)
        {
            wine.transform.position = new Vector3(
                wine.transform.position.x - limit,
                wine.transform.position.y,
                wine.transform.position.z);
        }
    }

    public void MoveRight()
    {
        float limit = widthLimit - wineWidthLimit;
        if (wine.transform.position.x < transform.position.x + limit)
        {
            wine.transform.position = new Vector3(
            wine.transform.position.x + speed, 
            wine.transform.position.y, 
            wine.transform.position.z);
        }

        //if (wine.transform.position.x > transform.position.x + limit)
        //{
        //    wine.transform.position = new Vector3(
        //        transform.position.x + limit,
        //        transform.position.y,
        //        transform.position.z);
        //}
    }

    public void MoveRightInsta()
    {
        float limit = widthLimit - wineWidthLimit;
        if (wine.transform.position.x < transform.position.x + limit)
        {
            wine.transform.position = new Vector3(
            wine.transform.position.x + limit,
            wine.transform.position.y,
            wine.transform.position.z);
        }
    }

    public void ResetPosition()
    {
        wine.transform.position = new Vector3(
            transform.position.x, 
            transform.position.y, 
            transform.position.z);
    }
}
