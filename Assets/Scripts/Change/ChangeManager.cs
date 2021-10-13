using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeManager : MonoBehaviour
{
    public Change[] changes;

    public void CheckAllBorders()
    {
        foreach (Change change in changes)
        {
            change.Border();
        }
    }

    public void CheckAllBorders(int index)
    {
        foreach (Change change in changes)
        {
            change.SetPickerIndex(index);
            change.Border();
        }
    }
}
