using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneIndex : MonoBehaviour
{
    public static int nextSceneIndex = 0;

    public void SetNextSceneIndexAfterLoad(int index)
    {
        nextSceneIndex = index;
    }
}
