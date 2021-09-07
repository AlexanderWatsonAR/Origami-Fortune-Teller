using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public class TweenType
{
    public virtual void Interpolate(float interp)
    {

    }
}

public class ColourTween : TweenType
{
    public Color startColour;
    public Color endColour;
    [HideInInspector]
    public Color outColour;

    public override void Interpolate(float interp)
    {
        Vector4 from = new Vector4(startColour.r, startColour.g, startColour.b, startColour.a);
        Vector4 to = new Vector4(endColour.r, endColour.g, endColour.b, endColour.a);
        Vector4 result = Vector4.Lerp(from, to, interp);
        Color newColour = new Color(result.x, result.y, result.z, result.w);
        outColour = newColour;
    }
}

public class Vector3Tween : TweenType
{
    public Vector3 startVector3;
    public Vector3 endVector3;
    [HideInInspector]
    public Vector3 outVector3;

    public override void Interpolate(float interp)
    {
        Vector3 from = new Vector3(startVector3.x, startVector3.y, startVector3.z);
        Vector3 to = new Vector3(endVector3.x, endVector3.y, endVector3.z);
        Vector3 result = Vector3.Lerp(from, to, interp);
        outVector3 = result;
    }
}

public class FloatTween : TweenType
{
    public float startValue;
    public float endValue;
    [HideInInspector]
    public float outValue;

    public override void Interpolate(float interp)
    {
        float result = Mathf.Lerp(startValue, endValue, interp);
        outValue = result;
    }

}


public class TweenAnimator
{
    public TweenType tweenType;

    public IEnumerator StartTweenAnimation(int numberOfFrames, float startAfter, float duration, Func<int> animationEvent, float animationEventMoment)
    {
        yield return new WaitForSeconds(startAfter);

        float onePercent = duration / numberOfFrames;
        float interp = duration;
        float timeElapsed = 0.0f;

        while (interp > 0.0f)
        {
            interp -= onePercent;
            timeElapsed += Time.fixedDeltaTime;

            if(animationEvent != null && timeElapsed == animationEventMoment)
            {
                animationEvent();
            }

            tweenType.Interpolate(interp);
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
    }
}