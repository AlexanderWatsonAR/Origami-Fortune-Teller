using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectStickerPostion : MonoBehaviour
{
    public GameObject text;

    private static int count;

    public static int Count
    {
        get
        {
            return count;
        }

        set
        {
            if (value < 0)
                count = 3;
            else if (value > 3)
                count = 0;
            else
                count = value;
        }
    }

    private string [] positions = {"Empty", "Position 1", "Position 2", "Both"};
    private TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        textMesh = text.GetComponent<TextMeshProUGUI>();
        textMesh.text = positions[Count];
    }

    public void Forward()
    {
        Count++;
        textMesh.text = positions[Count];
    }

    public void Backward()
    {
        Count--;
        textMesh.text = positions[Count];
    }

    public string ReturnPosition()
    {
        return positions[count];
    }

    public void ChangeText(int index)
    {
        textMesh.text = positions[index];
        Count = index;
    }
}
