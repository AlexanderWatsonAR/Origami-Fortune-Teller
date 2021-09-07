using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistObject : MonoBehaviour
{
    public static GameObject instance;
    public GameObject[] dependents;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(instance);

        foreach(GameObject dependent in dependents)
        {
            DontDestroyOnLoad(dependent);
        }    
    }
}
