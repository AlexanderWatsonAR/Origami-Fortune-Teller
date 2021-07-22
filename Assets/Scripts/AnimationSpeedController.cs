using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationSpeedController : MonoBehaviour
{
    private float startSpeed = 1;
    public float animationMultiplier = 2f;
    private Slider animationSlider;

    private void Start()
    {
        animationSlider = GetComponent<Slider>();
        animationSlider.onValueChanged.AddListener(delegate { NewMethod(); });
    }

    public void NewMethod()
    {
        for(int i = 0; i < OrigamiManager.instance.orgami.Length; i++)
        {
            OrigamiManager.instance.orgami[i].GetComponent<Animator>().speed = startSpeed + (animationSlider.value * animationMultiplier);
        }

        //Debug.Log(animationSlider.value);
    }
}
