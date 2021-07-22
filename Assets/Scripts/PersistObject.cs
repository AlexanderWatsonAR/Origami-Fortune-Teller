using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistObject : MonoBehaviour
{
    public GameObject[] dependents;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        foreach(GameObject dependent in dependents)
        {
            DontDestroyOnLoad(dependent);
        }    
    }
}
