using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DesignSceneTween : MonoBehaviour
{
    public CanvasGroup secondaryCanvasGroup;
    public GameObject mainSceneButton;
    public Image colourPaletteImage;

    private bool isCanvasVisible;
    private CanvasGroup mainCanvasGroup;


    private GameObject origami;
    //SkinnedMeshRenderer BLSkinnedMesh;
    //SkinnedMeshRenderer BRSkinnedMesh;
    //SkinnedMeshRenderer TLSkinnedMesh;
    //SkinnedMeshRenderer TRSkinnedMesh;


    private void Start()
    {
        mainCanvasGroup = GetComponent<CanvasGroup>();

        origami = OrigamiManager.instance.orgami[0];
        origami.transform.DOMove(new Vector3(0.0f, 2.5f, -4.5f), 0.33f, false).SetAutoKill(false).Pause();
        origami.transform.DORotate(new Vector3(260.0f, 0.0f, 0.0f), 0.33f, RotateMode.Fast).SetAutoKill(false).Pause();
        mainCanvasGroup.DOFade(1f, 0.33f).SetAutoKill(false).Pause();
        
        secondaryCanvasGroup.DOFade(1f, 1f).SetAutoKill(false).Pause();
        colourPaletteImage.DOColor(Color.white, 0.33f).SetAutoKill(false).Pause();
        StartTween();

    }

    //private void SetupOrigamiTween()
    //{
    //    origami = OrigamiManager.instance.orgami[0];

    //    GameObject bottomLeft = origami.transform.GetChild(0).gameObject;
    //    GameObject bottomRight = origami.transform.GetChild(1).gameObject;
    //    GameObject topLeft = origami.transform.GetChild(2).gameObject;
    //    GameObject topRight = origami.transform.GetChild(3).gameObject;

    //    BLSkinnedMesh = bottomLeft.GetComponent<SkinnedMeshRenderer>();
    //    BRSkinnedMesh = bottomRight.GetComponent<SkinnedMeshRenderer>();
    //    TLSkinnedMesh = topLeft.GetComponent<SkinnedMeshRenderer>();
    //    TRSkinnedMesh = topRight.GetComponent<SkinnedMeshRenderer>();

    //    Transform one = origami.transform.GetChild(4);

    //    // Open/Close Animation
    //    // One
    //    origami.transform.GetChild(4).DOLocalPath(new[] { new Vector3(-0.196f, 0.2720004f, 0.5499996f) }, 5, PathType.Linear).SetAutoKill(false).Pause();
    //    origami.transform.GetChild(4).DOLocalRotate(new Vector3(21.417f, 281.31f, 274.177f), 1.0f, RotateMode.Fast).Pause();
    //    // Two
    //    origami.transform.GetChild(4).DOLocalPath(new[] { new Vector3(-0.196f, 0.2720004f, 0.5499996f) }, 1, PathType.Linear).SetAutoKill(false).Pause();
    //    origami.transform.GetChild(4).DOLocalRotate(new Vector3(21.417f, 281.31f, 274.177f), 1.0f, RotateMode.Fast).Pause();
    //    // Three
    //    origami.transform.GetChild(4).DOLocalPath(new[] { new Vector3(-0.196f, 0.2720004f, 0.5499996f) }, 1, PathType.Linear).SetAutoKill(false).Pause();
    //    origami.transform.GetChild(4).DOLocalRotate(new Vector3(21.417f, 281.31f, 274.177f), 1.0f, RotateMode.Fast).Pause();
    //    // Four
    //    origami.transform.GetChild(4).DOLocalPath(new[] { new Vector3(-0.196f, 0.2720004f, 0.5499996f) }, 1, PathType.Linear).SetAutoKill(false).Pause();
    //    origami.transform.GetChild(4).DOLocalRotate(new Vector3(21.417f, 281.31f, 274.177f), 1.0f, RotateMode.Fast).Pause();
    //    // Five
    //    origami.transform.GetChild(4).DOLocalPath(new[] { new Vector3(-0.196f, 0.2720004f, 0.5499996f) }, 1, PathType.Linear).SetAutoKill(false).Pause();
    //    origami.transform.GetChild(4).DOLocalRotate(new Vector3(21.417f, 281.31f, 274.177f), 1.0f, RotateMode.Fast).Pause();
    //    // Six
    //    origami.transform.GetChild(4).DOLocalPath(new[] { new Vector3(-0.196f, 0.2720004f, 0.5499996f) }, 1, PathType.Linear).SetAutoKill(false).Pause();
    //    origami.transform.GetChild(4).DOLocalRotate(new Vector3(21.417f, 281.31f, 274.177f), 1.0f, RotateMode.Fast).Pause();
    //    // Seven
    //    origami.transform.GetChild(4).DOLocalPath(new[] { new Vector3(-0.196f, 0.2720004f, 0.5499996f) }, 1, PathType.Linear).SetAutoKill(false).Pause();
    //    origami.transform.GetChild(4).DOLocalRotate(new Vector3(21.417f, 281.31f, 274.177f), 1.0f, RotateMode.Fast).Pause();
    //    // Eight
    //    origami.transform.GetChild(4).DOLocalPath(new[] { new Vector3(-0.196f, 0.2720004f, 0.5499996f) }, 1, PathType.Linear).SetAutoKill(false).Pause();
    //    origami.transform.GetChild(4).DOLocalRotate(new Vector3(21.417f, 281.31f, 274.177f), 1.0f, RotateMode.Fast).Pause();
    //}

    //public void TestTween()
    //{
    //    //one
    //    origami.transform.GetChild(4).DOPlayForward();


    //    DOTween.To(() => BLSkinnedMesh.GetBlendShapeWeight(0), x => BLSkinnedMesh.SetBlendShapeWeight(0, x), 0, 5).SetAutoKill(false);
    //    DOTween.To(() => BRSkinnedMesh.GetBlendShapeWeight(0), x => BRSkinnedMesh.SetBlendShapeWeight(0, x), 0, 5).SetAutoKill(false);
    //    DOTween.To(() => TLSkinnedMesh.GetBlendShapeWeight(0), x => TLSkinnedMesh.SetBlendShapeWeight(0, x), 0, 5).SetAutoKill(false);
    //    DOTween.To(() => TRSkinnedMesh.GetBlendShapeWeight(0), x => TRSkinnedMesh.SetBlendShapeWeight(0, x), 0, 5).SetAutoKill(false);

    //}

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
        }
        else
        {
            mainCanvasGroup.DOPlayBackwards();
            colourPaletteImage.DOPlayBackwards();
            origami.transform.DOPlayBackwards();
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
                //Vector3 newPosition = new Vector3(origami.transform.position.x, origami.transform.position.y, origami.transform.position.z);
                origami.GetComponent<Animator>().rootPosition = origami.transform.position;
                origami.GetComponent<Animator>().enabled = true;
                break;

        }
    }

    public void ClearTweens()
    {
        DOTween.Clear();
    }

    //public void TweenAnimation()
    //{
    //    DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 0, 1);
    //}
}
