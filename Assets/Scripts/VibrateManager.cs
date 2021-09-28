using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateManager : MonoBehaviour
{
    public OnOffToggle vibrationToggle;
    private static bool isVibrateEnabled;

    public static bool IsVibrateEnabled
    {
        get
        {
            return isVibrateEnabled;
        }

        set
        {
            isVibrateEnabled = value;
            int temp = value ? 1 : 0;
            PlayerPrefs.SetInt("IsVibrateEnabled", temp);
        }
    }

    private void Awake()
    {
        //PlayerPrefs.SetInt("IsVibrateEnabled", 0);
        isVibrateEnabled = PlayerPrefs.GetInt("IsVibrateEnabled") == 1 ? true : false;

        if(isVibrateEnabled == true && vibrationToggle != null)
        {
            vibrationToggle.ToggleKnob();
        }
    }

    public void Vibrate()
    {
        if (isVibrateEnabled == true)
        {
            Handheld.Vibrate();
        }
    }

    public void ToggleVibrate()
    {
        IsVibrateEnabled = !IsVibrateEnabled;
    }

}
