using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ColurPallete : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    private void Start()
    {
        GetComponent<CanvasScaler>();
        canvasGroup.DOFade(0f, 1f).SetAutoKill(false).Pause();
    }

    public void TweenAnimation()
    {
        DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 0, 1);
    }
}
