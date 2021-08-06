using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNextAnimation : MonoBehaviour
{
    public int origamiNumber;

    public void PlayNext()
    {
        OrigamiManager.instance.orgami[origamiNumber].SetActive(true);
        OrigamiManager.instance.orgami[origamiNumber].GetComponent<Animator>().enabled = true;
        OrigamiManager.instance.orgami[origamiNumber].GetComponent<Animator>().Play(0);
        gameObject.SetActive(false);
    }
}
