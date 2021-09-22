using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainSceneTween : MonoBehaviour
{
    public GameObject MainCanvas;
    public GameObject SecondaryCanvas;
    public SwitchScene switchScene;

    // Start is called before the first frame update
    void Start()
    {
        MainCanvas.GetComponent<CanvasGroup>().DOFade(0.0f, 0.5f).Pause();
        SecondaryCanvas.GetComponent<CanvasGroup>().DOFade(1.0f, 0.5f).SetAutoKill(false);

        foreach(GameObject origami in OrigamiManager.instance.orgami)
        {
            origami.transform.DOMoveX(-6.0f, 1.0f).SetAutoKill(false).Pause();
        }


        GameObject zeroOrigami = OrigamiManager.instance.orgami[0];
    }

    public void Play()
    {
        StartCoroutine(PlayTween());
    }

    public IEnumerator PlayTween()
    {
        yield return new WaitForSeconds(0.33f);

        MainCanvas.GetComponent<CanvasGroup>().DOPlay();
        SecondaryCanvas.GetComponent<CanvasGroup>().DOPlayBackwards();

        foreach (GameObject origami in OrigamiManager.instance.orgami)
        {
            origami.GetComponent<Animator>().enabled = false;
            origami.transform.DOPlay();
        }

        yield return new WaitForSeconds(1.1f);

        switchScene.LoadScene("IntroScene");
    }
}
