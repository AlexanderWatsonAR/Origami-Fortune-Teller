using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayActivate : MonoBehaviour
{
    public GameObject target;
    public IEnumerator ActiveIn(float time)
    {
        yield return new WaitForSeconds(time);
        target.SetActive(true);
    }

    public IEnumerator DeactiveIn(float time)
    {
        yield return new WaitForSeconds(time);
        target.SetActive(false);
    }
}
