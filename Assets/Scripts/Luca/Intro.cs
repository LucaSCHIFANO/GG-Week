using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void setIntro()
    {
        anim.SetBool("outro", false);
    }

    public void setOutro()
    {
        anim.SetBool("outro", true);
    }
}
