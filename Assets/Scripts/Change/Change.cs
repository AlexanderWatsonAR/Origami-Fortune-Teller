using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Change : MonoBehaviour
{
    protected int pickerIndex;

    public virtual void Border()
    {

    }

    public virtual void ChangeState()
    {

    }

    public void SetPickerIndex(int index)
    {
        pickerIndex = index;
    }
}
