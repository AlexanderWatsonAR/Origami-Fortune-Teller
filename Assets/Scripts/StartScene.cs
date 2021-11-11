using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UDP;

public class StartScene : MonoBehaviour
{
    // Awake is called before Start
    void Awake()
    {
        Application.backgroundLoadingPriority = ThreadPriority.Low;
    }

}
