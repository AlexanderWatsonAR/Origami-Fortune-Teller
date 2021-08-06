using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFortuneTeller : MonoBehaviour
{
    public int loopNumberOfTimes;
    private int count;

    private void Start()
    {
        //Time.timeScale = 0.2f;
        count = 0;
    }

    public void Rotate()
    {
        transform.Rotate(Vector3.up, 90);
        count++;

        if (count == loopNumberOfTimes)
        {
            GetComponent<Animator>().enabled = false;
            //FirstOrigami.SetActive(true);
            //FirstOrigami.GetComponent<Animator>().enabled = true;
            //FirstOrigami.GetComponent<Animator>().Play("CloseAnimation");

            OrigamiManager.instance.orgami[2].SetActive(true);
            OrigamiManager.instance.orgami[2].GetComponent<Animator>().enabled = true;
            OrigamiManager.instance.orgami[2].GetComponent<Animator>().Play(0);
            count = 0;
            gameObject.SetActive(false);
        }
    }
}
