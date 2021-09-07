using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustRelativeSize : MonoBehaviour
{
    public float RelativeSize;
    void Awake()
    {
        RectTransform rectTransform = gameObject.transform as RectTransform;
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, Screen.safeArea.height * RelativeSize);
    }
}
