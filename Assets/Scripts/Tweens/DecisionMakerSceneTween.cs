using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DecisionMakerSceneTween : MonoBehaviour
{
    public string nextSceneName = "Load";

    public GameObject VerticalLayout;
    public GameObject nextSceneButton;
    public SwitchScene switchScene;

    private RectTransform verticalLayoutTransform;
    private bool areOptionsAvailable;
    
    public void SetSceneName(string name)
    {
        nextSceneName = name;
    }

    // Start is called before the first frame update
    void Start()
    {
        areOptionsAvailable = false;
        verticalLayoutTransform = VerticalLayout.transform as RectTransform;
        verticalLayoutTransform.anchoredPosition = new Vector2(-1100.0f, verticalLayoutTransform.anchoredPosition.y);

        verticalLayoutTransform.DOAnchorPosX(0.0f, 0.5f).SetAutoKill(false).Pause();
        nextSceneButton.GetComponent<CanvasGroup>().DOFade(1.0f, 0.5f).SetAutoKill(false).Pause();

        StartCoroutine(PlayTween());
    }

    public void Play()
    {
        StartCoroutine(PlayTween());
    }

    public IEnumerator PlayTween()
    {
        if(nextSceneName == "IntroScene")
        {
            yield return new WaitForSeconds(0.5f);
        }

        if(areOptionsAvailable == false)
        {
            verticalLayoutTransform.DOPlayForward();
            yield return new WaitForSeconds(0.5f);
            nextSceneButton.GetComponent<CanvasGroup>().DOPlayForward();
        }
        else
        {
            nextSceneButton.GetComponent<CanvasGroup>().DOPlayBackwards();
            verticalLayoutTransform.DOPlayBackwards();
            yield return new WaitForSeconds(0.5f);
            switchScene.LoadScene(nextSceneName);
        }

        areOptionsAvailable = !areOptionsAvailable;
    }
}
