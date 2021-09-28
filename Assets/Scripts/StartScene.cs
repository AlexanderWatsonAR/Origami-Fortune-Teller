using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

// Aspect Ratio
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
// Google Pixel 3 XL  | 2,960 / 1,440 = 2.05555555556
// Samsung Galaxy S10 | 3,040 / 1,440 = 2.11111111111
// Samasung Galaxy 20 | 3,088 / 1,440 = 2.14444444444
// iPhone X           | 2,436 / 1,125 = 2.16533333333
// iPhone 11          | 2,688 / 1,242 = 2.16425120773
// iPhone 12          | 2,778 / 1,284 = 2.16355140187
// Samsung Galaxy A70 | 2,400 / 1,080 = 2.22222222222

public class StartScene : MonoBehaviour
{
    public GameObject scrollView;
    public GameObject emptySpace;
    public GameObject secondaryCanvas;
    public GameObject mainCanvasMask;
    // Awake is called before Start
    void Awake()
    {
        //Time.timeScale = 0.25f;
        Application.backgroundLoadingPriority = ThreadPriority.Low;
        ConfigureUI();
//#if UNITY_EDITOR
//        PlayerSettings.statusBarHidden = false;
//#endif
//        Debug.unityLogger.logEnabled = false;

//#if UNITY_EDITOR
//        Debug.unityLogger.logEnabled = true;
//#endif

        ApplicationChrome.statusBarState =  ApplicationChrome.States.Hidden;
        ApplicationChrome.navigationBarState = ApplicationChrome.States.TranslucentOverContent;
    }

    private void ConfigureUI()
    {
        float height = Screen.height;
        float width = Screen.width;

        float aspectRatio = height / width;

        RectTransform scrollRect = scrollView.transform as RectTransform;
        RectTransform emptyRect = emptySpace.transform as RectTransform;
        //a.sizeDelta = new Vector2(a.sizeDelta.x, Screen.height * 0.6f);

        if (aspectRatio > 1.32f && aspectRatio < 1.34f)
        {
            scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, height * 0.33f);
            emptySpace.SetActive(false);
            secondaryCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0.15f;

        }

        if (aspectRatio > 1.42f && aspectRatio < 1.44f)
        {
            scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, height * 0.275f);
            emptySpace.SetActive(false);
            secondaryCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0.15f;
            mainCanvasMask.GetComponent<RectTransform>().offsetMin = new Vector2(0.0f, 1400.0f);
            secondaryCanvas.transform.GetChild(0).GetComponent<RectTransform>().offsetMin = new Vector2(30.0f, 0.0f);

        }

        if (aspectRatio > 1.7f && aspectRatio < 1.8f)
        {
            // HTC10 - 1.777778
            // iPhone 8 - 1.778667

            scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, height * 0.46f);

            if (aspectRatio > 1.778f && aspectRatio < 1.779f)
            {
                scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, height * 0.72f);
            }

            
            emptyRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, 350.0f);
        }

        if (aspectRatio > 2.0f && aspectRatio < 2.12f)
        {
            scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, Screen.height * 0.44f);
        }

        if (aspectRatio > 2.14f && aspectRatio < 2.17f)
        {
            // iPhone 12
            scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, Screen.height * 0.52f);
        }


    }

    public void OpenUrl()
    {
        //if (Application.platform == RuntimePlatform.IPhonePlayer)
        //    UnityEngine.iOS.Device.RequestStoreReview();
        if (Application.platform == RuntimePlatform.Android)
            Application.OpenURL("market://details?id=" + Application.identifier);
    }
}
