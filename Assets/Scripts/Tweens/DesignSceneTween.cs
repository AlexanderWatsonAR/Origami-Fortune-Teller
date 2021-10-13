using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DesignSceneTween : MonoBehaviour
{
    public GameObject MainCanvas;
    public CanvasGroup secondaryCanvasGroup;
    public GameObject mainSceneButton;
    public GameObject Designer;
    public GameObject Buttons;
    public OpenScene openMainScene;
    public SwitchScene switchScene;
    public Image colourPaletteImage;
    public Light mainLight;

    private bool isCanvasVisible;
    private CanvasGroup mainCanvasGroup;


    private GameObject origami;
    //SkinnedMeshRenderer BLSkinnedMesh;
    //SkinnedMeshRenderer BRSkinnedMesh;
    //SkinnedMeshRenderer TLSkinnedMesh;
    //SkinnedMeshRenderer TRSkinnedMesh;


    private void Start()
    {
        mainCanvasGroup = MainCanvas.GetComponent<CanvasGroup>();

        origami = OrigamiManager.instance.orgami[0];
        origami.transform.DOMove(new Vector3(0.0f, 2.5f, -4.5f), 0.33f, false).SetAutoKill(false).Pause();
        origami.transform.DORotate(new Vector3(260.0f, 0.0f, 0.0f), 0.33f, RotateMode.Fast).SetAutoKill(false).Pause();
        mainCanvasGroup.DOFade(1f, 0.33f).SetAutoKill(false).Pause();
        mainLight.transform.DOLocalRotate(new Vector3(-15.0f, 0.0f, 0.0f), 0.33f).SetAutoKill(false).Pause();
        secondaryCanvasGroup.DOFade(1f, 1f).SetAutoKill(false).Pause();
        colourPaletteImage.DOColor(Color.white, 0.33f).SetAutoKill(false).Pause();
        StartTween();

    }

    private void StartTween()
    {
        StartCoroutine(TweenEvent(0, 0.33f));
        secondaryCanvasGroup.DOPlay();
    }

    public void Play()
    {
        mainCanvasGroup.interactable = !mainCanvasGroup.interactable;

        if (isCanvasVisible == false)
        {
            origami.GetComponent<Animator>().enabled = false;
            
            StartCoroutine(TweenEvent(2, 0.33f));

            mainCanvasGroup.DOPlayForward();
            colourPaletteImage.DOPlayForward();
            origami.transform.DOPlayForward();
            mainLight.transform.DOPlayForward();
            DOTween.To(() => mainLight.intensity, x => mainLight.intensity = x, 1.5f, 0.33f);

        }
        else
        {
            mainCanvasGroup.DOPlayBackwards();
            colourPaletteImage.DOPlayBackwards();
            origami.transform.DOPlayBackwards();
            mainLight.transform.DOPlayBackwards();
            DOTween.To(() => mainLight.intensity, x => mainLight.intensity = x, 1, 0.33f);
        }

        isCanvasVisible = !isCanvasVisible;
    }

    public IEnumerator TweenEvent(int index, float time)
    {
        yield return new WaitForSeconds(time);

        switch(index)
        {
            case 0:
                secondaryCanvasGroup.interactable = !secondaryCanvasGroup.interactable;
                break;
            case 1:
                mainCanvasGroup.interactable = !mainCanvasGroup.interactable;
                break;
            case 2:
                origami.GetComponent<Animator>().rootPosition = origami.transform.position;
                origami.GetComponent<Animator>().enabled = true;
                break;

        }
    }

    public void GoHome()
    {
        if(MainCanvas.activeSelf)
            StartCoroutine(DesignToHome());
    }

    public IEnumerator DesignToHome()
    {
        Destroy(openMainScene);
        Designer.transform.DOLocalMoveX(-615.8f, 0.75f).SetDelay(0.4f);
        Buttons.transform.DOMoveX(-1231.6f, 0.75f).SetDelay(0.4f);
        origami.transform.DOMoveX(-5.0f, 0.75f).SetDelay(0.4f);

        yield return new WaitForSeconds(1f);
        switchScene.LoadScene("IntroScene");
    }

    public void StopTweens()
    {
        GameObject loadTweens = GameObject.Find("LoadSceneTween");

        if (loadTweens != null)
        {
            loadTweens.GetComponent<LoadSceneTween>().StopTweens();
            Destroy(loadTweens);
        }
        DestroyLoadOrigami();
    }

    private void DestroyLoadOrigami()
    {
        GameObject orig1 = GameObject.Find("Load Origami 1");

        if (orig1 != null)
        {
            Destroy(orig1.GetComponent<PersistObject>().dependents[0]);
            Destroy(orig1);
        }
    }

    public void ClearTweens()
    {
        DOTween.Clear();
    }
}
