using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public enum Mesh_Button_Type
{
    Flap,
    Number,
    Reverse
};


public class MeshClick : MonoBehaviour
{
    public ReverseAnimation reverseAnimation;
    public string AnimationName;
    public int OrigamiNumber;
    public int MaxFoldCount;
    public Mesh_Button_Type Mesh_Button_Type;


    void OnMouseDown()
    {
        switch(Mesh_Button_Type)
        {
            case Mesh_Button_Type.Flap:
                FlapButton();
                break;
            case Mesh_Button_Type.Number:
                NumberButton();
                break;
            case Mesh_Button_Type.Reverse:
                Reverse();
                break;
        }
    }

    private void FlapButton()
    {
        OrigamiManager.instance.orgami[OrigamiNumber - 1].SetActive(false);
        OrigamiManager.instance.orgami[OrigamiNumber].SetActive(true);
        OrigamiManager.instance.orgami[OrigamiNumber].GetComponent<Animator>().enabled = true;
        OrigamiManager.instance.PlayAnimation(OrigamiNumber, AnimationName);
        transform.parent.gameObject.SetActive(false);
        Debug.Log(AnimationName);
    }

    private void NumberButton()
    {
        OrigamiManager.instance.MaxFoldCount = MaxFoldCount;
        OrigamiManager.instance.PlayAnimation(1, "NewFirstFoldAnimation");
        OrigamiManager.instance.PlayAnimation(2, "NewFortuneTellerAnimation2point5");
    }

    private void Reverse()
    {
        StartCoroutine(reverseAnimation.ReverseOrigamiAnimation());
    }
}
