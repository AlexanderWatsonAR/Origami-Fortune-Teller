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
            OrigamiManager.instance.orgami[0].transform.GetChild(0).GetComponent<Renderer>().material.SetInt("Vector1_1866b2cf3a5d44f69aa3bc86840b54d5", 1);
            OrigamiManager.instance.orgami[0].transform.GetChild(1).GetComponent<Renderer>().material.SetInt("Vector1_1866b2cf3a5d44f69aa3bc86840b54d5", 1);
            OrigamiManager.instance.orgami[0].transform.GetChild(2).GetComponent<Renderer>().material.SetInt("Vector1_1866b2cf3a5d44f69aa3bc86840b54d5", 1);
            OrigamiManager.instance.orgami[0].transform.GetChild(3).GetComponent<Renderer>().material.SetInt("Vector1_1866b2cf3a5d44f69aa3bc86840b54d5", 1);
            ChangeOrigamiTexture.ChangeLastOrigami();
            ChangeOrigamiColour.ChangeLastOrigami();
            Destroy(gameObject);
        }
    }

    public void SetSceneName(string name)
    {
        SceneName = name;
    }
}
