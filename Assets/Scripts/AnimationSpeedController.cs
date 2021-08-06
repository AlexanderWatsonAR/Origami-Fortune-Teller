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
        animationSlider.onValueChanged.AddListener(delegate { AdjustAnimationSpeed(); });
    }

    public void AdjustAnimationSpeed()
    {
        for(int i = 0; i < OrigamiManager.instance.orgami.Length; i++)
        {
            OrigamiManager.instance.orgami[i].GetComponent<Animator>().speed = startSpeed + (animationSlider.value * animationMultiplier);
        }


        foreach(Sound s in AudioManager.instance.sounds)
        {
            s.pitch = startSpeed + (animationSlider.value * animationMultiplier);
            if (s.pitch > 2)
                s.pitch = 2;
            s.source.pitch = s.pitch;
        }
    }
}
