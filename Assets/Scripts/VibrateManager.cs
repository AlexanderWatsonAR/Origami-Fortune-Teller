using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateManager : MonoBehaviour
{
    public OnOffToggle vibrationToggle;
    public static bool isVibrateDisabled;

    private void Awake()
    {
        if(isVibrateDisabled ==  true && vibrationToggle != null)
        {
            vibrationToggle.ToggleKnob();
        }
    }

    public void Vibrate()
    {
        if (isVibrateDisabled == false)
        {
            Handheld.Vibrate();
        }
    }

    public void ToggleVibrate()
    {
        isVibrateDisabled = !isVibrateDisabled;
    }

}
