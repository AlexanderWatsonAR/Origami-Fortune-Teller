using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Aspect Ratio. Actual. NOT SAFE AREA
// Samsung Galaxy Z F2| 2,208 / 1,768 = 1.24886877828
// iPad Air 1         | 2,048 / 1,536 = 1.33333333333
// iPad Air 2         | 2,048 / 1,536 = 1.33333333333
// iPad Air 3         | 2,224 / 1,668 = 1.33333333333
// Nexus 9            | 2,048 / 1,536 = 1.33333333333
// iPad Air 4         | 2,360 / 1,640 = 1.43902439024
// Chromebook Pixel   | 2,560 / 1,700 = 1.50588235294
// Nexus 7            | 1,920 / 1,200 = 1.6

// Samsung Galaxy S7  | 2,560 / 1,440 = 1.77777777778
// Samsung Galaxy S6  | 2,560 / 1,440 = 1.77777777778
// iPhone 8           | 1,334 / 0,750 = 1.77866666667
// Samsung Galaxy S8  | 2,960 / 1,440 = 2.05555555556
// Samsung Galaxy S9  | 2,960 / 1,440 = 2.05555555556
// Google Pixel 3 XL  | 2,960 / 1,440 = 2.05555555556
// Samsung Galaxy S10 | 3,040 / 1,440 = 2.11111111111
// Samsung Galaxy 20  | 3,088 / 1,440 = 2.14444444444
// iPhone X           | 2,436 / 1,125 = 2.16533333333
// iPhone 11          | 2,688 / 1,242 = 2.16425120773
// iPhone 12          | 2,778 / 1,284 = 2.16355140187
// One Plus 7         | 3,120 / 1,440 = 2.16666666667
// One Plus 6T        | 2,340 / 10,08 = 2.16666666667
// Samsung Galaxy A70 | 2,400 / 1,080 = 2.22222222222

public enum ScreenType
{
    OnePointSix, OnePointSevenSeven, OnePointThreeThree, OnePointFourThree, OnePointNineSeven, TwoPointZeroFive, TwoPointOneSix, TwoPointTwoTwo
}

public class ScreenAdapter : MonoBehaviour
{
    protected float aspectRatio;
    protected float height;
    protected float width;

    protected void ConfigureUI()
    {
        ScreenType configuration = ScreenType.OnePointSevenSeven;
        height = Screen.safeArea.height;
        width = Screen.safeArea.width;
        aspectRatio = height / width;

        if (aspectRatio > 1.29f && aspectRatio < 1.34f)
        {
            configuration = ScreenType.OnePointThreeThree;
        }

        if (aspectRatio > 1.38f && aspectRatio < 1.44f)
        {
            configuration = ScreenType.OnePointFourThree;
        }

        if (aspectRatio > 1.7f && aspectRatio < 1.8f)
        {
            configuration = ScreenType.OnePointSevenSeven;
        }

        if(aspectRatio > 1.59f && aspectRatio < 1.61f)
        {
            configuration = ScreenType.OnePointSix;
        }

        if (aspectRatio > 1.9f && aspectRatio < 2.0f)
        {
            configuration = ScreenType.OnePointNineSeven;
        }

        if (aspectRatio > 2.0f && aspectRatio < 2.12f)
        {
            configuration = ScreenType.TwoPointZeroFive;
        }

        if (aspectRatio > 2.14f && aspectRatio < 2.17f)
        {
            configuration = ScreenType.TwoPointOneSix;
        }

        if (aspectRatio > 2.17f)
        {
            configuration = ScreenType.TwoPointTwoTwo;
        }

        switch (configuration)
        {
            case ScreenType.OnePointSix:
                OnePointSix();
                break;
            case ScreenType.OnePointSevenSeven:
                OnePointSevenSeven();
                break;
            case ScreenType.OnePointNineSeven:
                OnePointNineSeven();
                break;
            case ScreenType.TwoPointZeroFive:
                TwoPointZeroFive();
                break;
            case ScreenType.OnePointThreeThree:
                OnePointThreeThree();
                break;
            case ScreenType.OnePointFourThree:
                OnePointFourThree();
                break;
            case ScreenType.TwoPointOneSix:
                TwoPointOneSix();
                break;
            case ScreenType.TwoPointTwoTwo:
                TwoPointTwoTwo();
                break;
        }
    }

    protected virtual void OnePointSix()
    {

    }

    protected virtual void OnePointSevenSeven()
    {
    }

    protected virtual void OnePointNineSeven()
    {

    }

    protected virtual void TwoPointZeroFive()
    {
    }

    protected virtual void OnePointThreeThree()
    {

    }
    protected virtual void OnePointFourThree()
    {
    }

    protected virtual void TwoPointOneSix()
    {
        // Samsung Galaxy S8, Google Pixel 3 XL
    }
    protected virtual void TwoPointTwoTwo()
    {

    }

    public void OpenUrl()
    {
#if UNITY_IOS
        UnityEngine.iOS.Device.RequestStoreReview();
#endif
#if UNITY_ANDROID
        Application.OpenURL("market://details?id=" + Application.identifier);
#endif
    }
}
