using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDefaultAnimation : MonoBehaviour
{
    public string FirstAnimation;
    public string SecondAnimation;
    public string DefaultAnimation;

    public void ChangeDefault()
    {
        GetComponent<Animator>().Play(DefaultAnimation);

        if (DefaultAnimation == FirstAnimation)
            DefaultAnimation = SecondAnimation;
        else if (DefaultAnimation == SecondAnimation)
            DefaultAnimation = FirstAnimation;
        else
            DefaultAnimation = SecondAnimation;
    }
}
