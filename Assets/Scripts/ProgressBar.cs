using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class ProgressBar : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("GameObject/UI/ProgressBar")]
    public static void AddProgressBar()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/ProgressBar"));
        obj.transform.SetParent(Selection.activeGameObject.transform, false);
    }
#endif

    public float min;
    public float max;
    public float current;
    public Image mask;
    public Image fill;
    public Color color;

    public void SetCurrentFill(float value)
    {
        if(value > min && value < max) {
            current = value;
            float currentOffset = current - min;
            float maxOffset = max - min;
            float fillAmount = currentOffset / maxOffset;
            mask.fillAmount = fillAmount;
            fill.color = color;
        }


    }
}
