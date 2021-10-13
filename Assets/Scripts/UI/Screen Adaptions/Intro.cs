using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : ScreenAdapter
{
    public GameObject SidePanel;
    public GameObject MainLayout;
    public GameObject scrollView;
    public GameObject emptySpace;
    public GameObject secondaryCanvas;
    public GameObject mainCanvasMask;
    public GameObject Preview;

    private RectTransform scrollRect;
    private RectTransform emptyRect;
    private VerticalLayoutGroup sidePanelLayout;
    private VerticalLayoutGroup mainVerticalLayout;

    void Awake()
    {
        sidePanelLayout = SidePanel.GetComponent<VerticalLayoutGroup>();
        mainVerticalLayout = MainLayout.GetComponent<VerticalLayoutGroup>();
        scrollRect = scrollView.transform as RectTransform;
        emptyRect = emptySpace.transform as RectTransform;
        ConfigureUI();
    }

    protected override void OnePointSix()
    {
        mainVerticalLayout.enabled = false;
        sidePanelLayout.enabled = false;
        scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, 1100.0f);
        emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 175.0f);
        mainVerticalLayout.enabled = true;
        sidePanelLayout.enabled = true;
        Preview.transform.position = new Vector3(Preview.transform.position.x, 0.52f, Preview.transform.position.z);
        Preview.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

    }

    protected override void OnePointThreeThree()
    {
        mainVerticalLayout.enabled = false;
        scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, height * 0.33f);
        emptySpace.SetActive(false);
        mainCanvasMask.GetComponent<RectTransform>().offsetMin = new Vector2(0.0f, 1400.0f);
        mainVerticalLayout.enabled = true;
        Preview.transform.position = new Vector3(Preview.transform.position.x, 0.65f, Preview.transform.position.z);
        Preview.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
    }

    protected override void OnePointFourThree()
    {
        mainVerticalLayout.enabled = false;
        scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, 925f);
        emptySpace.SetActive(false);
        mainCanvasMask.GetComponent<RectTransform>().offsetMin = new Vector2(0.0f, 1400.0f);
        secondaryCanvas.transform.GetChild(0).GetComponent<RectTransform>().offsetMin = new Vector2(30.0f, 0.0f);
        mainVerticalLayout.enabled = true;

        Preview.transform.position = new Vector3(Preview.transform.position.x, 0.65f, Preview.transform.position.z);
        Preview.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
    }

    protected override void OnePointSevenSeven()
    {
        // HTC10 - 1.777778
        // iPhone 8 - 1.778667
        mainVerticalLayout.enabled = false;

        //scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, height * 0.46f);

        //if (aspectRatio > 1.777f && aspectRatio < 1.779f)
        //{
        //    scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, height * 0.77f);
        //}


        scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, scrollRect.sizeDelta.y - (scrollRect.sizeDelta.y * 0.095f));
        sidePanelLayout.enabled = false;
        emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 390.0f);
        sidePanelLayout.enabled = true;

        mainVerticalLayout.enabled = true;
        Preview.transform.position = new Vector3(Preview.transform.position.x, 0.5f, Preview.transform.position.z);
    }

    protected override void OnePointNineSeven()
    {
        sidePanelLayout.enabled = false;
        emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 610.0f);
        sidePanelLayout.enabled = true;
        
    }

    protected override void TwoPointZeroFive()
    {
        mainVerticalLayout.enabled = false;
        sidePanelLayout.enabled = false;
        scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, height * 0.44f);
        emptyRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, 690f);

        if (aspectRatio > 2.0f && aspectRatio < 2.05f)
        {
            emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 650f);
            scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, 1440.0f);
        }

        if (aspectRatio > 2.05f && aspectRatio < 2.07f)
        {
            Preview.transform.position = new Vector3(Preview.transform.position.x, 0.42f, Preview.transform.position.z);
        }

        if (aspectRatio > 2.07f && aspectRatio < 2.09f)
        {
            scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, height * 0.7f);
        }

        if (aspectRatio > 2.08f && aspectRatio < 2.09f)
        {
            scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, 1600.0f);
        }

        if (aspectRatio > 2.09f && aspectRatio < 2.095f)
        {
            scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, height * 0.55f);
        }

        if (aspectRatio > 2.1f && aspectRatio < 2.15f)
        {
            scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, height * 0.66f);
            emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 675f);
        }
        mainVerticalLayout.enabled = true;
        sidePanelLayout.enabled = true;
    }

    protected override void TwoPointOneSix()
    {
        Preview.transform.position = new Vector3(Preview.transform.position.x, 0.4f, Preview.transform.position.z);
        mainVerticalLayout.enabled = false;
        sidePanelLayout.enabled = false;
        emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 600.0f);
        scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, Screen.height * 0.52f);
        sidePanelLayout.enabled = true;
        mainVerticalLayout.enabled = true;
    }

}
