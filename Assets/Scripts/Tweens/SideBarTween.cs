using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SideBarTween : MonoBehaviour
{
    public Image coverImage;
    public GameObject SidePanel;
    public GameObject ShopWindow;
    public GameObject Preview;

    private bool isSideBarVisible;
    private GameObject topSection;
    private RectTransform sidePanelTransform;
    private RectTransform restoreImageTransform;
    private CanvasGroup shopWindowCanvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        topSection = SidePanel.transform.GetChild(1).gameObject;
        Color black = new Color(0.0f, 0.0f, 0.0f, 0.7843137f);

        restoreImageTransform = topSection.transform.GetChild(6).GetChild(0) as RectTransform;
        shopWindowCanvasGroup = ShopWindow.GetComponent<CanvasGroup>();

        // Side Panel Animation.
        coverImage.DOColor(black, 0.33f).SetAutoKill(false).Pause();
        sidePanelTransform = SidePanel.transform as RectTransform;
        sidePanelTransform.DOAnchorPosX(100.0f, 0.33f, false).SetAutoKill(false).Pause();
        sidePanelTransform.DOSizeDelta(new Vector2(-200, sidePanelTransform.sizeDelta.y), 0.33f, false).SetAutoKill(false).Pause();

        // Restore Purchase.
        restoreImageTransform.DORotate(new Vector3(0.0f, 0.0f, -360.0f), 0.5f, RotateMode.FastBeyond360).SetAutoKill(false).Pause();

        // Shop Window
        shopWindowCanvasGroup.DOFade(1.0f, 0.33f).SetAutoKill(false).Pause();

        Preview.transform.DORotate(new Vector3(0.0f, -35.0f, 0.0f), 4, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);

    }

    public void Play()
    {
        if(isSideBarVisible)
        {
            topSection.GetComponent<VerticalLayoutGroup>().enabled = false;
            coverImage.DOPlayBackwards();
            sidePanelTransform.DOPlayBackwards();
        }
        else
        {
            topSection.GetComponent<VerticalLayoutGroup>().enabled = false;
            coverImage.DOPlayForward();
            sidePanelTransform.DOPlayForward();
            StartCoroutine(TweenEvent(0, 0.25f));
        }

        isSideBarVisible = !isSideBarVisible;
    }

    public void RestorePurchaseTween()
    {
        restoreImageTransform.DOPlay();
    }

    public void OpenShowWindow()
    {
        topSection.GetComponent<VerticalLayoutGroup>().enabled = false;
        sidePanelTransform.DOPlayBackwards();
        isSideBarVisible = !isSideBarVisible;
        StartCoroutine(TweenEvent(2, 0.33f));
    }

    public void CloseShopWindow()
    {
        shopWindowCanvasGroup.DOPlayBackwards();
        coverImage.DOPlayBackwards();
        StartCoroutine(TweenEvent(1, 0.16f));
        shopWindowCanvasGroup.interactable = false;
        shopWindowCanvasGroup.blocksRaycasts = false;
    }

    private IEnumerator TweenEvent(int eventIndex, float time)
    {
        yield return new WaitForSeconds(time);
        switch (eventIndex)
        {
            case 0:
                topSection.GetComponent<VerticalLayoutGroup>().enabled = true;
                break;
            case 1:
                Preview.SetActive(!Preview.activeSelf);
                break;
            case 2:
                shopWindowCanvasGroup.DOPlayForward();
                StartCoroutine(TweenEvent(1, 0.33f));
                shopWindowCanvasGroup.interactable = true;
                shopWindowCanvasGroup.blocksRaycasts = true;
                break;
        }
    }
}
