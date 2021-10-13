using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : ScreenAdapter
{
    public GameObject MainCanvas;
    public CanvasScaler MainCanvasScaler;
    public GameObject BackCanvasMask;
    public GameObject mainCamera;
    public GameObject ColourButtons;
    public GameObject AnimationSpeedToggle;
    public GameObject AnimationSpeedSlider;
    public GameObject ColourText;
    public GameObject NumberText;
    public GameObject emptySpace;
    public GameObject SidePanel;
    public GameObject reverseButton;
    public GameObject numberButtons;
    public GameObject Preview;

    private Transform mainCameraTransform;
    private RectTransform designerRectTransform;
    private RectTransform emptyRect;
    private VerticalLayoutGroup sidePanelLayout;
    //private CanvasScaler mainCanvasScaler;

    // Start is called before the first frame update
    void Awake()
    {
        sidePanelLayout = SidePanel.GetComponent<VerticalLayoutGroup>();
        emptyRect = emptySpace.transform as RectTransform;
        mainCameraTransform = mainCamera.transform;
        //mainCanvasScaler = GetComponent<CanvasScaler>();
        ConfigureUI();

    }

    protected override void OnePointThreeThree()
    {
        MainCanvasScaler.matchWidthOrHeight = 0.65f;
        BackCanvasMask.GetComponent<RectTransform>().offsetMin = new Vector2(0.0f, 1400.0f);
        ColourButtons.transform.localPosition = new Vector3(ColourButtons.transform.localPosition.x, -45f, ColourButtons.transform.localPosition.z);
        ColourButtons.GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 1f);
        mainCameraTransform.position = new Vector3(mainCameraTransform.position.x, 1.1f, -10.1f);
        AnimationSpeedToggle.GetComponent<RectTransform>().anchoredPosition = new Vector2(AnimationSpeedToggle.GetComponent<RectTransform>().anchoredPosition.x, -575f);
        AnimationSpeedSlider.GetComponent<RectTransform>().anchoredPosition = new Vector2(AnimationSpeedSlider.GetComponent<RectTransform>().anchoredPosition.x, -800f);
        AnimationSpeedSlider.GetComponent<RectTransform>().localScale = new Vector3(1.25f, 1.25f, 1.25f);
        ColourText.GetComponent<RectTransform>().anchoredPosition = new Vector2(ColourText.GetComponent<RectTransform>().anchoredPosition.x, -1475f);
        NumberText.GetComponent<RectTransform>().anchoredPosition = new Vector2(NumberText.GetComponent<RectTransform>().anchoredPosition.x, -1635f);
        numberButtons.transform.position = new Vector3(numberButtons.transform.position.x, 1.55f, numberButtons.transform.position.z);

        Preview.transform.position = new Vector3(Preview.transform.position.x, 1.8f, Preview.transform.position.z);
        Preview.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
    }

    protected override void OnePointFourThree()
    {
        MainCanvasScaler.matchWidthOrHeight = 0.65f;
        BackCanvasMask.GetComponent<RectTransform>().offsetMin = new Vector2(0.0f, 1400.0f);
        ColourButtons.transform.localPosition = new Vector3(ColourButtons.transform.localPosition.x, -45f, -10.1f);
        ColourButtons.GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 1f);
        mainCameraTransform.position = new Vector3(mainCameraTransform.position.x, 1.1f, mainCameraTransform.position.z);
        AnimationSpeedToggle.GetComponent<RectTransform>().anchoredPosition = new Vector2(AnimationSpeedToggle.GetComponent<RectTransform>().anchoredPosition.x, -575f);
        AnimationSpeedSlider.GetComponent<RectTransform>().anchoredPosition = new Vector2(AnimationSpeedSlider.GetComponent<RectTransform>().anchoredPosition.x, -800f);
        AnimationSpeedSlider.GetComponent<RectTransform>().localScale = new Vector3(1.25f, 1.25f, 1.25f);
        ColourText.GetComponent<RectTransform>().anchoredPosition = new Vector2(ColourText.GetComponent<RectTransform>().anchoredPosition.x, -1475f);
        NumberText.GetComponent<RectTransform>().anchoredPosition = new Vector2(NumberText.GetComponent<RectTransform>().anchoredPosition.x, -1635f);
        numberButtons.transform.position = new Vector3(numberButtons.transform.position.x, 1.55f, numberButtons.transform.position.z);

        Preview.transform.position = new Vector3(Preview.transform.position.x, 1.8f, Preview.transform.position.z);
        Preview.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
    }

    protected override void OnePointSix()
    {
        sidePanelLayout.enabled = false;
        emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 175.0f);
        sidePanelLayout.enabled = true;
        Preview.transform.position = new Vector3(Preview.transform.position.x, 1.75f, Preview.transform.position.z);
        Preview.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        AnimationSpeedToggle.GetComponent<RectTransform>().anchoredPosition = new Vector2(AnimationSpeedToggle.GetComponent<RectTransform>().anchoredPosition.x, -735f);
        ColourButtons.transform.localPosition = new Vector3(ColourButtons.transform.localPosition.x, -89f, 0f);
        ColourButtons.GetComponent<RectTransform>().localScale = new Vector3(0.9f, 0.9f, 0.9f);
    }

    protected override void OnePointSevenSeven()
    {
        numberButtons.transform.position = new Vector3(numberButtons.transform.position.x, 1.5f, numberButtons.transform.position.z);
        mainCameraTransform.position = new Vector3(mainCameraTransform.position.x, 1f, mainCameraTransform.position.z);
        AnimationSpeedToggle.GetComponent<RectTransform>().anchoredPosition = new Vector2(AnimationSpeedToggle.GetComponent<RectTransform>().anchoredPosition.x, -800f);
        AnimationSpeedSlider.GetComponent<RectTransform>().localScale = new Vector3(1.25f, 1.25f, 1.25f);
        sidePanelLayout.enabled = false;
        emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 390.0f);
        sidePanelLayout.enabled = true;

        Preview.transform.position = new Vector3(Preview.transform.position.x, 1.5f, Preview.transform.position.z);
    }

    protected override void OnePointNineSeven()
    {
        Preview.transform.position = new Vector3(Preview.transform.position.x, 1.58f, Preview.transform.position.z);
        Preview.transform.localScale = new Vector3(0.475f, 0.475f, 0.475f);

        ColourButtons.transform.localPosition = new Vector3(ColourButtons.transform.localPosition.x, -85.0f, ColourButtons.transform.localPosition.z);
        ColourButtons.transform.localScale = new Vector3(0.95f, 0.95f, 0.95f);
    }

    protected override void TwoPointZeroFive()
    {
        sidePanelLayout.enabled = false;

        Preview.transform.position = new Vector3(Preview.transform.position.x, 1.45f, Preview.transform.position.z);

        emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 690f);

        if (aspectRatio > 2.0f && aspectRatio < 2.05f)
        {
            emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 650f);
            Preview.transform.position = new Vector3(Preview.transform.position.x, 1.52f, Preview.transform.position.z);
        }

        if (aspectRatio > 2.05f && aspectRatio < 2.07f)
        {
            Preview.transform.position = new Vector3(Preview.transform.position.x, 1.3f, Preview.transform.position.z);
            mainCameraTransform.position = new Vector3(mainCameraTransform.position.x, 0.85f, mainCameraTransform.position.z);
            numberButtons.transform.position = new Vector3(numberButtons.transform.position.x, 1.4f, numberButtons.transform.position.z);
            ColourButtons.transform.localPosition = new Vector3(ColourButtons.transform.localPosition.x, 36.0f, ColourButtons.transform.localPosition.z);
            AnimationSpeedSlider.GetComponent<RectTransform>().anchoredPosition = new Vector2(AnimationSpeedSlider.GetComponent<RectTransform>().anchoredPosition.x, -960f);
        }

        if (aspectRatio > 2.07f && aspectRatio < 2.09f)
        {
            mainCameraTransform.position = new Vector3(mainCameraTransform.position.x, 0.85f, mainCameraTransform.position.z);
            numberButtons.transform.position = new Vector3(numberButtons.transform.position.x, 1.4f, numberButtons.transform.position.z);
        }

        if (aspectRatio > 2.08f && aspectRatio < 2.09f)
        {
            mainCameraTransform.position = new Vector3(mainCameraTransform.position.x, 1.0f, mainCameraTransform.position.z);
            numberButtons.transform.position = new Vector3(numberButtons.transform.position.x, 1.5f, numberButtons.transform.position.z);
            Preview.transform.position = new Vector3(Preview.transform.position.x, 1.4f, Preview.transform.position.z);
        }

        if (aspectRatio > 2.09f && aspectRatio < 2.095f)
        {
            mainCameraTransform.position = new Vector3(mainCameraTransform.position.x, 1.1f, mainCameraTransform.position.z);
            numberButtons.transform.position = new Vector3(numberButtons.transform.position.x, 1.55f, numberButtons.transform.position.z);
        }

        if (aspectRatio > 2.1f && aspectRatio < 2.15f)
        {
            emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 675f);
            mainCameraTransform.position = new Vector3(mainCameraTransform.position.x, 1.1f, mainCameraTransform.position.z);
        }

        

        sidePanelLayout.enabled = true;
    }

    protected override void TwoPointOneSix()
    {
        Preview.transform.position = new Vector3(Preview.transform.position.x, 1.25f, Preview.transform.position.z);
        sidePanelLayout.enabled = false;
        emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 690f);

        reverseButton.transform.localScale = new Vector3(reverseButton.transform.localScale.x, 2.5f, reverseButton.transform.localScale.z);
        sidePanelLayout.enabled = false;
        emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 600.0f);
        sidePanelLayout.enabled = true;

        if(aspectRatio > 2.165f && aspectRatio < 2.168f)
        {
            mainCameraTransform.position = new Vector3(mainCameraTransform.position.x, 0.85f, mainCameraTransform.position.z);
        }
    }
}
