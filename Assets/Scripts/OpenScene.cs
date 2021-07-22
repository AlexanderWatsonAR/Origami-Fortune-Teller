using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScene : MonoBehaviour
{
    public string SceneName =  "Main";

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        Open();
    }

    public void Open()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != SceneName)
            return;
        else
        {
            OrigamiManager.instance.orgami[0].SetActive(true);
            OrigamiManager.instance.Canvas.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void SetSceneName(string name)
    {
        SceneName = name;
    }
}
