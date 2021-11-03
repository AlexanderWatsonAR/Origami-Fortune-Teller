using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Design : ScreenAdapter
{
    public GameObject mainCamera;
    public GameObject designerVerticalLayout;
    public GameObject Designer;
    public GameObject secondaryCanvasVerticalLayout;
    public GameObject BackCanvasMask;
    public GameObject emptySpace;
    public GameObject SidePanel;
    public GameObject Preview;
    public GameObject MainCanvas;
    public GameObject SecondaryCanvas;

    private CanvasScaler mainCanvasScaler;
    private CanvasScaler secondaryCanvasScaler;
    private Transform mainCameraTransform;
    private RectTransform designerVerticalLayoutTransform;
    private RectTransform secondaryCanvasVerticalLayoutRect;
    private RectTransform designerRectTransform;
    private RectTransform emptyRect;
    private VerticalLayoutGroup sidePanelLayout;

    // Start is called before the first frame update
    void Awake()
    {
        mainCanvasScaler = MainCanvas.GetComponent<CanvasScaler>();
        secondaryCanvasScaler = SecondaryCanvas.GetComponent<CanvasScaler>();
        sidePanelLayout = SidePanel.GetComponent<VerticalLayoutGroup>();
        emptyRect = emptySpace.transform as RectTransform;
        mainCameraTransform = mainCamera.transform;
        designerVerticalLayoutTransform = designerVerticalLayout.transform as RectTransform;
        secondaryCanvasVerticalLayoutRect = secondaryCanvasVerticalLayout.transform as RectTransform;
        designerRectTransform = Designer.transform as RectTransform;
        
        ConfigureUI();

    }

    protected override void OnePointThreeThree()
    {
        // iPad Air 1
        BackCanvasMask.GetComponent<RectTransform>().offsetMin = new Vector2(-1.0f, 1400.0f);
        BackCanvasMask.GetComponent<RectTransform>().offsetMax = new Vector2(1.0f, 1.0f);
        secondaryCanvasVerticalLayoutRect.anchoredPosition = new Vector3(secondaryCanvasVerticalLayoutRect.position.x, 190f, secondaryCanvasVerticalLayoutRect.position.z);
        mainCameraTransform.position = new Vector3(mainCameraTransform.position.x, mainCameraTransform.position.y, -9.0f);
        designerRectTransform.sizeDelta = new Vector2(designerRectTransform.sizeDelta.x, 575f);
        designerVerticalLayoutTransform.anchoredPosition = new Vector3(designerVerticalLayoutTransform.position.x, -60f, designerVerticalLayoutTransform.position.z);

        Preview.transform.position = new Vector3(Preview.transform.position.x, 1.6f, Preview.transform.position.z);
        Preview.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
    }

    protected override void OnePointFourThree()
    {
        // iPad Air 4
        BackCanvasMask.GetComponent<RectTransform>().offsetMin = new Vector2(-1.0f, 1400.0f);
        BackCanvasMask.GetComponent<RectTransform>().offsetMax = new Vector2(1.0f, 1.0f);
        secondaryCanvasVerticalLayoutRect.anchoredPosition = new Vector3(secondaryCanvasVerticalLayoutRect.position.x, 190f, secondaryCanvasVerticalLayoutRect.position.z);
        mainCameraTransform.position = new Vector3(mainCameraTransform.position.x, mainCameraTransform.position.y, -9.0f);
        designerRectTransform.sizeDelta = new Vector2(designerRectTransform.sizeDelta.x, 575f);
        designerVerticalLayoutTransform.anchoredPosition = new Vector3(designerVerticalLayoutTransform.position.x, -60f, designerVerticalLayoutTransform.position.z);

        Preview.transform.position = new Vector3(Preview.transform.position.x, 1.6f, Preview.transform.position.z);
        Preview.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
    }

    protected override void OnePointSix()
    {
        secondaryCanvasVerticalLayoutRect.anchoredPosition = new Vector2(secondaryCanvasVerticalLayoutRect.anchoredPosition.x, -25f);
        designerVerticalLayoutTransform.anchoredPosition = new Vector2(designerVerticalLayoutTransform.anchoredPosition.x, -85f);
        mainCanvasScaler.matchWidthOrHeight = 0.33f;
        secondaryCanvasScaler.matchWidthOrHeight = 0.25f;
        Preview.transform.position = new Vector3(Preview.transform.position.x, 1.75f, Preview.transform.position.z);
        Preview.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        sidePanelLayout.enabled = false;
        emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 175.0f);
        sidePanelLayout.enabled = true;
    }

    protected override void OnePointSevenSeven()
    {
        mainCameraTransform.position = new Vector3(mainCameraTransform.position.x, 1f, mainCameraTransform.position.z);

        designerVerticalLayoutTransform.anchoredPosition = new Vector2(designerVerticalLayoutTransform.anchoredPosition.x, -50f);

        sidePanelLayout.enabled = false;
        emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 390.0f);
        sidePanelLayout.enabled = true;

        Preview.transform.position = new Vector3(Preview.transform.position.x, 1.5f, Preview.transform.position.z);
    }

    protected override void OnePointNineSeven()
    {
        designerVerticalLayoutTransform.anchoredPosition = new Vector2(designerVerticalLayoutTransform.anchoredPosition.x, -100f);
    }

    protected override void TwoPointZeroFive()
    {
        // Samsung Galaxy S8, Google Pixel 3 XL
        designerVerticalLayoutTransform.anchoredPosition = new Vector2(designerVerticalLayoutTransform.anchoredPosition.x, -120f);

        sidePanelLayout.enabled = false;
        emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 690f);
        Preview.transform.position = new Vector3(Preview.transform.position.x, 1.2f, Preview.transform.position.z);

        if (aspectRatio > 2.0f && aspectRatio < 2.05f)
        {
            emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 650f);
            Preview.transform.position = new Vector3(Preview.transform.position.x, 1.52f, Preview.transform.position.z);
        }

        if (aspectRatio > 2.05f && aspectRatio < 2.07f)
        {
            mainCameraTransform.position = new Vector3(mainCameraTransform.position.x, 0.85f, mainCameraTransform.position.z);
            Preview.transform.position = new Vector3(Preview.transform.position.x, 1.3f, Preview.transform.position.z);
        }

        if (aspectRatio > 2.07f && aspectRatio < 2.09f)
        {
            mainCameraTransform.position = new Vector3(mainCameraTransform.position.x, 0.85f, mainCameraTransform.position.z);
        }

        if (aspectRatio > 2.08f && aspectRatio < 2.09f)
        {
            mainCameraTransform.position = new Vector3(mainCameraTransform.position.x, 1.0f, mainCameraTransform.position.z);
            Preview.transform.position = new Vector3(Preview.transform.position.x, 1.36f, Preview.transform.position.z);
        }

        if (aspectRatio > 2.09f && aspectRatio < 2.095f)
        {
            mainCameraTransform.position = new Vector3(mainCameraTransform.position.x, 1.1f, mainCameraTransform.position.z);
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
        designerVerticalLayoutTransform.anchoredPosition = new Vector2(designerVerticalLayoutTransform.anchoredPosition.x, -100f);

        sidePanelLayout.enabled = false;
        emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 600.0f);

        if (aspectRatio < 2.16f)
        {
            emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 800.0f);
            Preview.transform.position = new Vector3(Preview.transform.position.x, 1.35f, Preview.transform.position.z);
            mainCameraTransform.position = new Vector3(mainCameraTransform.position.x, mainCameraTransform.position.y - 0.2f, mainCameraTransform.position.z);
            secondaryCanvasVerticalLayout.GetComponent<VerticalLayoutGroup>().padding.bottom = 100;
        }

        if (aspectRatio > 2.165f && aspectRatio < 2.168f)
        {
            mainCameraTransform.position = new Vector3(mainCameraTransform.position.x, 0.85f, mainCameraTransform.position.z);
        }
        sidePanelLayout.enabled = true;

    }
    protected override void TwoPointTwoTwo()
    {
        mainCameraTransform.position = new Vector3(mainCameraTransform.position.x, 0.8f, mainCameraTransform.position.z);
        Preview.transform.position = new Vector3(Preview.transform.position.x, 1.2f, Preview.transform.position.z);
        sidePanelLayout.enabled = false;
        emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 875.0f);
        sidePanelLayout.enabled = true;
    }
}
