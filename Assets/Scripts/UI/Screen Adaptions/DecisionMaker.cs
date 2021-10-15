using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionMaker : ScreenAdapter
{
    public GameObject emptySpace;
    public GameObject SidePanel;
    public GameObject Preview;

    private RectTransform emptyRect;
    private VerticalLayoutGroup sidePanelLayout;

    private void Awake()
    {
        sidePanelLayout = SidePanel.GetComponent<VerticalLayoutGroup>();
        emptyRect = emptySpace.transform as RectTransform;

        ConfigureUI(); 
    }

    protected override void OnePointThreeThree()
    {
        Preview.transform.position = new Vector3(Preview.transform.position.x, 0.65f, Preview.transform.position.z);
        Preview.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
    }

    protected override void OnePointFourThree()
    {
        Preview.transform.position = new Vector3(Preview.transform.position.x, 0.65f, Preview.transform.position.z);
        Preview.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
    }

    protected override void OnePointSix()
    {
        sidePanelLayout.enabled = false;
        emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 175.0f);
        sidePanelLayout.enabled = true;
        Preview.transform.position = new Vector3(Preview.transform.position.x, 0.52f, Preview.transform.position.z);
        Preview.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    protected override void OnePointSevenSeven()
    {
        sidePanelLayout.enabled = false;
        emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 390.0f);
        sidePanelLayout.enabled = true;
        Preview.transform.position = new Vector3(Preview.transform.position.x, 0.5f, Preview.transform.position.z);
    }

    protected override void OnePointNineSeven()
    {
    }

    protected override void TwoPointZeroFive()
    {
        // Samsung Galaxy S8, Google Pixel 3 XL
        Preview.transform.position = new Vector3(Preview.transform.position.x, 0.3f, Preview.transform.position.z);

        sidePanelLayout.enabled = false;
        emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 690f);

        if (aspectRatio > 2.0f && aspectRatio < 2.05f)
        {
            emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 650f);
        }

        if (aspectRatio > 2.05f && aspectRatio < 2.07f)
        {
            Preview.transform.position = new Vector3(Preview.transform.position.x, 0.42f, Preview.transform.position.z);
        }

        if (aspectRatio > 2.08f && aspectRatio < 2.09f)
        {
            Preview.transform.position = new Vector3(Preview.transform.position.x, 0.38f, Preview.transform.position.z);
        }

        if (aspectRatio > 2.1f && aspectRatio < 2.15f)
        {
            emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 675f);
        }
        // Background mask top -1
        sidePanelLayout.enabled = true;

    }

    protected override void TwoPointOneSix()
    {
        sidePanelLayout.enabled = false;
        emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 600.0f);
        sidePanelLayout.enabled = true;

    }

    protected override void TwoPointTwoTwo()
    {
        Preview.transform.position = new Vector3(Preview.transform.position.x, 0.4f, Preview.transform.position.z);
        sidePanelLayout.enabled = false;
        emptyRect.sizeDelta = new Vector2(emptyRect.sizeDelta.x, 875.0f);
        sidePanelLayout.enabled = true;
    }


}
