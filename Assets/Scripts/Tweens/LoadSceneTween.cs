using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LoadSceneTween : MonoBehaviour
{
    public GameObject Origami_1;
    public GameObject Origami_2;
    public GameObject Origami_3;

    private bool isOnePaused;
    private bool isTwoPaused;
    private bool isThreePaused;
    private bool isTweenEventInProgress;

    private SwitchScene switchScene;
    private float divider;

    // Start is called before the first frame update
    void Start()
    {
        divider = 1.0f;
        DontDestroyOnLoad(gameObject);
        switchScene = GetComponent<SwitchScene>();

        StartCoroutine(Origami1Setup());
    }

    private IEnumerator Origami1Setup()
    {
        // Reveal paper
        StartCoroutine(switchScene.LoadSceneAsync(4));
        Origami_1.transform.DOMoveY(0.95f, 1f / divider);

        yield return new WaitForSeconds(1f / divider);

        divider = IsMainSceneLoaded();

        if (isOnePaused)
            yield return null;

        if (Origami_1 == null)
            yield return null;

        // Rotate 45d
        Origami_1.transform.DORotate(new Vector3(90.0f, -90.0f, 90.0f), 1.0f / divider, RotateMode.Fast);

        // Close from flat.
        GameObject bottom = Origami_1.transform.GetChild(0).gameObject;
        GameObject left = Origami_1.transform.GetChild(1).gameObject;
        GameObject right = Origami_1.transform.GetChild(2).gameObject;
        GameObject top = Origami_1.transform.GetChild(3).gameObject;

        SkinnedMeshRenderer bottomSkinnedMesh = bottom.GetComponent<SkinnedMeshRenderer>();
        SkinnedMeshRenderer leftSkinnedMesh = left.GetComponent<SkinnedMeshRenderer>();
        SkinnedMeshRenderer rightSkinnedMesh = right.GetComponent<SkinnedMeshRenderer>();
        SkinnedMeshRenderer topSkinnedMesh = top.GetComponent<SkinnedMeshRenderer>();

        GameObject bottomPlane = Origami_1.transform.GetChild(4).gameObject;
        GameObject leftPlane = Origami_1.transform.GetChild(5).gameObject;
        GameObject rightPlane = Origami_1.transform.GetChild(6).gameObject;
        GameObject topPlane = Origami_1.transform.GetChild(7).gameObject;

        yield return new WaitForSeconds(1f / divider);

        StartCoroutine(TweenEvent(2, 2.5f / divider));

        topPlane.SetActive(false);
        top.SetActive(true);

        DOTween.To(() => topSkinnedMesh.GetBlendShapeWeight(0), x => topSkinnedMesh.SetBlendShapeWeight(0, x), 50, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);
        DOTween.To(() => topSkinnedMesh.GetBlendShapeWeight(1), x => topSkinnedMesh.SetBlendShapeWeight(1, x), 100, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);
        DOTween.To(() => topSkinnedMesh.GetBlendShapeWeight(2), x => topSkinnedMesh.SetBlendShapeWeight(2, x), 50, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);

        yield return new WaitForSeconds(0.5f / divider);

        DOTween.To(() => topSkinnedMesh.GetBlendShapeWeight(0), x => topSkinnedMesh.SetBlendShapeWeight(0, x), 0, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);
        DOTween.To(() => topSkinnedMesh.GetBlendShapeWeight(1), x => topSkinnedMesh.SetBlendShapeWeight(1, x), 0, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);
        DOTween.To(() => topSkinnedMesh.GetBlendShapeWeight(2), x => topSkinnedMesh.SetBlendShapeWeight(2, x), 0, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);

        leftPlane.SetActive(false);
        left.SetActive(true);

        DOTween.To(() => leftSkinnedMesh.GetBlendShapeWeight(0), x => leftSkinnedMesh.SetBlendShapeWeight(0, x), 50, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);
        DOTween.To(() => leftSkinnedMesh.GetBlendShapeWeight(1), x => leftSkinnedMesh.SetBlendShapeWeight(1, x), 100, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);
        DOTween.To(() => leftSkinnedMesh.GetBlendShapeWeight(2), x => leftSkinnedMesh.SetBlendShapeWeight(2, x), 0, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);

        yield return new WaitForSeconds(0.5f / divider);

        DOTween.To(() => leftSkinnedMesh.GetBlendShapeWeight(0), x => leftSkinnedMesh.SetBlendShapeWeight(0, x), 0, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);
        DOTween.To(() => leftSkinnedMesh.GetBlendShapeWeight(1), x => leftSkinnedMesh.SetBlendShapeWeight(1, x), 0, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);
        DOTween.To(() => leftSkinnedMesh.GetBlendShapeWeight(2), x => leftSkinnedMesh.SetBlendShapeWeight(2, x), 0, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);

        bottomPlane.SetActive(false);
        bottom.SetActive(true);

        DOTween.To(() => bottomSkinnedMesh.GetBlendShapeWeight(0), x => bottomSkinnedMesh.SetBlendShapeWeight(0, x), 50, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);
        DOTween.To(() => bottomSkinnedMesh.GetBlendShapeWeight(1), x => bottomSkinnedMesh.SetBlendShapeWeight(1, x), 100, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);
        DOTween.To(() => bottomSkinnedMesh.GetBlendShapeWeight(2), x => bottomSkinnedMesh.SetBlendShapeWeight(2, x), 50, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);

        yield return new WaitForSeconds(0.5f / divider);

        DOTween.To(() => bottomSkinnedMesh.GetBlendShapeWeight(0), x => bottomSkinnedMesh.SetBlendShapeWeight(0, x), 0, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);
        DOTween.To(() => bottomSkinnedMesh.GetBlendShapeWeight(1), x => bottomSkinnedMesh.SetBlendShapeWeight(1, x), 0, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);
        DOTween.To(() => bottomSkinnedMesh.GetBlendShapeWeight(2), x => bottomSkinnedMesh.SetBlendShapeWeight(2, x), 0, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);

        rightPlane.SetActive(false);
        right.SetActive(true);

        DOTween.To(() => rightSkinnedMesh.GetBlendShapeWeight(0), x => rightSkinnedMesh.SetBlendShapeWeight(0, x), 50, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);
        DOTween.To(() => rightSkinnedMesh.GetBlendShapeWeight(1), x => rightSkinnedMesh.SetBlendShapeWeight(1, x), 100, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);
        DOTween.To(() => rightSkinnedMesh.GetBlendShapeWeight(2), x => rightSkinnedMesh.SetBlendShapeWeight(2, x), 50, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);

        yield return new WaitForSeconds(0.5f / divider);

        DOTween.To(() => rightSkinnedMesh.GetBlendShapeWeight(0), x => rightSkinnedMesh.SetBlendShapeWeight(0, x), 0, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);
        DOTween.To(() => rightSkinnedMesh.GetBlendShapeWeight(1), x => rightSkinnedMesh.SetBlendShapeWeight(1, x), 0, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);
        DOTween.To(() => rightSkinnedMesh.GetBlendShapeWeight(2), x => rightSkinnedMesh.SetBlendShapeWeight(2, x), 0, 0.5f / divider).SetAutoKill(true).SetEase(Ease.Linear);

        yield return new WaitForSeconds(0.5f / divider);

        StartCoroutine(Origami2Setup());
    }

    private IEnumerator Origami2Setup()
    {
        if (isTwoPaused)
            yield return null;

        if (Origami_2 == null)
            yield return null;

        divider = IsMainSceneLoaded();
        // Move Forward
        Origami_2.transform.DOLocalMoveZ(-5f, 2.5f / divider);

        GameObject bottomLeft = Origami_2.transform.GetChild(0).gameObject;
        GameObject bottomRight = Origami_2.transform.GetChild(1).gameObject;
        GameObject topLeft = Origami_2.transform.GetChild(2).gameObject;
        GameObject topRight = Origami_2.transform.GetChild(3).gameObject;

        SkinnedMeshRenderer BLSkinnedMesh = bottomLeft.GetComponent<SkinnedMeshRenderer>();
        SkinnedMeshRenderer BRSkinnedMesh = bottomRight.GetComponent<SkinnedMeshRenderer>();
        SkinnedMeshRenderer TLSkinnedMesh = topLeft.GetComponent<SkinnedMeshRenderer>();
        SkinnedMeshRenderer TRSkinnedMesh = topRight.GetComponent<SkinnedMeshRenderer>();

        DOTween.To(() => BRSkinnedMesh.GetBlendShapeWeight(0), x => BRSkinnedMesh.SetBlendShapeWeight(0, x), 0, 1f / divider).SetAutoKill(true);
        yield return new WaitForSeconds(0.5f / divider);
        DOTween.To(() => TLSkinnedMesh.GetBlendShapeWeight(0), x => TLSkinnedMesh.SetBlendShapeWeight(0, x), 0, 1f / divider).SetAutoKill(true);
        yield return new WaitForSeconds(0.5f / divider);
        DOTween.To(() => BLSkinnedMesh.GetBlendShapeWeight(0), x => BLSkinnedMesh.SetBlendShapeWeight(0, x), 0, 1f / divider).SetAutoKill(true);
        yield return new WaitForSeconds(0.5f / divider);
        DOTween.To(() => TRSkinnedMesh.GetBlendShapeWeight(0), x => TRSkinnedMesh.SetBlendShapeWeight(0, x), 0, 1f / divider).SetAutoKill(true);
        yield return new WaitForSeconds(1.0f / divider);

        Origami_2.GetComponent<ChangeMesh>().NextOrigamiModel();
        StartCoroutine(Origami3Setup());
    }

    private IEnumerator Origami3Setup()
    {
        if (isThreePaused)
            yield return null;

        if (Origami_3 == null)
            yield return null;

        divider = IsMainSceneLoaded();

        GameObject bottomLeft = Origami_3.transform.GetChild(0).gameObject;
        GameObject bottomRight = Origami_3.transform.GetChild(1).gameObject;
        GameObject topLeft = Origami_3.transform.GetChild(2).gameObject;
        GameObject topRight = Origami_3.transform.GetChild(3).gameObject;

        SkinnedMeshRenderer BLSkinnedMesh = bottomLeft.GetComponent<SkinnedMeshRenderer>();
        SkinnedMeshRenderer BRSkinnedMesh = bottomRight.GetComponent<SkinnedMeshRenderer>();
        SkinnedMeshRenderer TLSkinnedMesh = topLeft.GetComponent<SkinnedMeshRenderer>();
        SkinnedMeshRenderer TRSkinnedMesh = topRight.GetComponent<SkinnedMeshRenderer>();

        DOTween.To(() => BLSkinnedMesh.GetBlendShapeWeight(0), x => BLSkinnedMesh.SetBlendShapeWeight(0, x), 100, 1f / divider).SetAutoKill(true);
        DOTween.To(() => BRSkinnedMesh.GetBlendShapeWeight(0), x => BRSkinnedMesh.SetBlendShapeWeight(0, x), 100, 1f / divider).SetAutoKill(true);
        DOTween.To(() => TLSkinnedMesh.GetBlendShapeWeight(0), x => TLSkinnedMesh.SetBlendShapeWeight(0, x), 100, 1f / divider).SetAutoKill(true);
        DOTween.To(() => TRSkinnedMesh.GetBlendShapeWeight(0), x => TRSkinnedMesh.SetBlendShapeWeight(0, x), 100, 1f / divider).SetAutoKill(true);

        yield return new WaitForSeconds(1f / divider);

        switchScene.CloseLoadingScene();

        Destroy(Origami_3);
        Destroy(gameObject);
    }

    public IEnumerator TweenEvent(int eventIndex, float time)
    {
        isTweenEventInProgress = true;
        yield return new WaitForSeconds(time);

        if (Origami_1 == null)
            yield return null;

        switch(eventIndex)
        {
            case 0:
                AudioManager.instance.Play("PageFlip1");
                break;
            case 1:
                AudioManager.instance.Play("PageFlip2");
                break;
            case 2:
                Origami_1.GetComponent<ChangeMesh>().NextOrigamiModelDontDisable();
                break;
        }
    }

    public float IsMainSceneLoaded()
    {
        // if main scene is loaded. adjust tween speed;
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == NextSceneIndex.nextSceneIndex)
        {
            return 2.0f;
        }
        return 1.0f;
    }

    public void StopTweens()
    {
        if (isTweenEventInProgress)
        {
            StopCoroutine(TweenEvent(0, 0));
            isTweenEventInProgress = false;
        }

        if (Origami_1 != null)
        {
            isOnePaused = true;
            Origami_1.transform.DOPause();
            Origami_1.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>().DOPause();
            Origami_1.transform.GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().DOPause();
            Origami_1.transform.GetChild(2).gameObject.GetComponent<SkinnedMeshRenderer>().DOPause();
            Origami_1.transform.GetChild(3).gameObject.GetComponent<SkinnedMeshRenderer>().DOPause();
            StopCoroutine(Origami1Setup());
            Destroy(Origami_1);
        }    

        if(Origami_2 != null)
        {
            isTwoPaused = true;
            Origami_2.transform.DOPause();
            Origami_2.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>().DOPause();
            Origami_2.transform.GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().DOPause();
            Origami_2.transform.GetChild(2).gameObject.GetComponent<SkinnedMeshRenderer>().DOPause();
            Origami_2.transform.GetChild(3).gameObject.GetComponent<SkinnedMeshRenderer>().DOPause();
            StopCoroutine(Origami2Setup());
            Destroy(Origami_2);
        }
        
        if(Origami_3 != null)
        {
            isThreePaused = true;
            Origami_3.transform.DOPause();
            Origami_3.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>().DOPause();
            Origami_3.transform.GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().DOPause();
            Origami_3.transform.GetChild(2).gameObject.GetComponent<SkinnedMeshRenderer>().DOPause();
            Origami_3.transform.GetChild(3).gameObject.GetComponent<SkinnedMeshRenderer>().DOPause();
            StopCoroutine(Origami3Setup());
            Destroy(Origami_3);
        }
    }
}
