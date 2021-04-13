using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{   
    public void OpenSubMenu(GameObject name)
    {
        name.SetActive(true);
    }

    public void CloseSubMenu(GameObject name)
    {
        name.SetActive(false);
    }
}
