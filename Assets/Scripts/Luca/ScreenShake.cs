using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public Animator anim;
    public void shake1()
    {
        anim.SetTrigger("shake1");
    }

    public void shake2()
    {
        anim.SetTrigger("shake2");
    }
}
