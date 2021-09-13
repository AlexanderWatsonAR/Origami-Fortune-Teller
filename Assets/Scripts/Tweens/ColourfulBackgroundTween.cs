using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ColourfulBackgroundTween : MonoBehaviour
{
    public SwitchScene switchScene;
    private RectTransform maskTransform;
    private RectTransform backgroundTransform;
    private TextMeshProUGUI title;

    // Start is called before the first frame update
    void Start()
    {
        maskTransform = transform.GetChild(0) as RectTransform;
        backgroundTransform = maskTransform.GetChild(0) as RectTransform;
        title = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();

        Reverse();

        // Background Animation.
        maskTransform.DOAnchorPosY(-1100.0f, 1f, false).SetAutoKill(false).Pause();
        maskTransform.DOSizeDelta(new Vector2(maskTransform.sizeDelta.x, 2200f), 1f, false).SetAutoKill(false).Pause();
        backgroundTransform.DOAnchorPosY(1440.0f, 1f, false).SetAutoKill(false).Pause();
        title.DOFade(0.0f, 1f).SetAutoKill(false).Pause();
    }

    private void Reverse()
    {
        maskTransform.anchoredPosition = new Vector2(maskTransform.anchoredPosition.x, -1100.0f);
        maskTransform.sizeDelta = new Vector2(maskTransform.sizeDelta.x, 2200f);
        backgroundTransform.anchoredPosition = new Vector2(backgroundTransform.anchoredPosition.x, 1440.0f);
        title.alpha = 0f;

        maskTransform.DOAnchorPosY(0.0f, 1f, false).SetAutoKill(true);
        maskTransform.DOSizeDelta(new Vector2(maskTransform.sizeDelta.x, 0f), 1f, false).SetAutoKill(true);
        backgroundTransform.DOAnchorPosY(-770.0f, 1f, false).SetAutoKill(true);
        title.DOFade(1f, 1f).SetAutoKill(true);
    }

    public void Play()
    {
        StartCoroutine(TweenEvent(1.0f));
        maskTransform.DOPlayForward();
        backgroundTransform.DOPlayForward();
        title.DOPlayForward();
    }

    private IEnumerator TweenEvent(float time)
    {
        yield return new WaitForSeconds(time);
        switchScene.LoadInternalScene();

    }
}
