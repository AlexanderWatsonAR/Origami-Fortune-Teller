using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshClick : MonoBehaviour
{
    public string AnimationName;
    public int OrigamiNumber;
    void OnMouseDown()
    {
        OrigamiManager.instance.orgami[OrigamiNumber - 1].SetActive(false);
        OrigamiManager.instance.orgami[OrigamiNumber].SetActive(true);
        OrigamiManager.instance.orgami[OrigamiNumber].GetComponent<Animator>().enabled = true;
        OrigamiManager.instance.PlayAnimation(OrigamiNumber, AnimationName);
        transform.parent.gameObject.SetActive(false);
        Debug.Log(AnimationName);
    }
}
