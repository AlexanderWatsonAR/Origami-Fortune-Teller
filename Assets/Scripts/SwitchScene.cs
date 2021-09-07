using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SwitchScene : MonoBehaviour
{
    private static string sceneName;

    public static string SceneName
    {
        get
        {
            return sceneName;
        }
        set
        {
            sceneName = value;
        }
    }

    public void SetInternalSceneName(string name)
    {
        sceneName = name;
    }

    public void LoadInternalScene()
    {
        LoadScene(sceneName);
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
    public void LoadNextScene()
    {
        StartCoroutine(LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadSceneWithDelay(string sceneName)
    {
        StartCoroutine(LoadSceneDelayed(sceneName, 0.5f));
    }

    IEnumerator LoadSceneDelayed(string sceneName, float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        LoadScene(sceneName);
    }

    IEnumerator LoadSceneAsync(int levelIndex)
    {
        if(SceneManager.GetActiveScene().name == "Load")
        {
            levelIndex = NextSceneIndex.nextSceneIndex;
        }

        LoadSceneParameters sceneParameters = new LoadSceneParameters();
        sceneParameters.loadSceneMode = LoadSceneMode.Single;
        sceneParameters.localPhysicsMode = LocalPhysicsMode.None;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelIndex, sceneParameters);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void CloseLoadingScene()
    {
        GameObject orig1 = GameObject.Find("Load Origami 1");

        if (orig1 != null)
        {
            Destroy(orig1.GetComponent<PersistObject>().dependents[0]);
            Destroy(orig1);
        }

        OrigamiManager.instance.orgami[0].SetActive(true);
        OrigamiManager.instance.Canvas.SetActive(true);
        OrigamiManager.instance.SecondaryCanvas.SetActive(true);
        OrigamiManager.instance.orgami[0].GetComponent<Animator>().Play("NewFadeInTextureAnimation");
        Destroy(gameObject);
    }

    public void AdjustLoadSpeed()
    {
        if(SceneManager.GetActiveScene().buildIndex == NextSceneIndex.nextSceneIndex)
        {
            if(GetComponent<Animator>() != null)
            {
                GetComponent<Animator>().speed = 1.5f;
            }
        }
    }

    public void GoHome()
    {
        if(SceneManager.GetActiveScene().name == "IntroScene")
        {
            GameObject.Find("Secondary Canvas").GetComponent<Animator>().Play("NewSideBarAnimation");
        }
        else
        {
            LoadScene("IntroScene");
        }
    }
}
