using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    public string SceneName =  "Main";

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.activeSceneChanged += Open;
        DontDestroyOnLoad(this);
    }

    public void Open(Scene current, Scene next)
    {
        if (SceneManager.GetActiveScene().name != SceneName)
            return;
        else
        {
            OrigamiManager.instance.orgami[0].SetActive(true);
            OrigamiManager.instance.Canvas.SetActive(true);
            OrigamiManager.instance.SecondaryCanvas.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void SetSceneName(string name)
    {
        SceneName = name;
    }
}
