using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScene : MonoBehaviour
{
    public GameObject ReverseButton;
    public ReverseAnimation reverseAnimation;
    public TextMeshProUGUI instructionText;

    public void EndSceneEvent()
    {
        instructionText.text = "Tap to Replay";
        ReverseButton.SetActive(true);
        ReverseButton.GetComponent<MeshCollider>().enabled = true;
        OrigamiManager.instance.FoldCount = 0;
        //Time.timeScale = 0.5f;
    }

    public void Add(string animationName)
    {
        reverseAnimation.Add("Reverse"+animationName);
    }
}
