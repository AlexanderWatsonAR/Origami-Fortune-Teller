using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOrigami : MonoBehaviour
{
    public void Close()
    {
        if(transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0) != 100)
        {
            GetComponent<Animator>().Play("PrimaryView");
        }
    }
}
