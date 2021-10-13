using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectStickerPostion : MonoBehaviour
{
    public GameObject text;
    public GameObject firstSticker;
    public GameObject secondSticker;
    public int designDataIndex;
    private int count;

    public int Count
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
        Count = 0;
        textMesh = text.GetComponent<TextMeshProUGUI>();
        textMesh.text = positions[Count];

        RetrieveDesignData();
    }

    public void Forward()
    {
        Count++;
        textMesh.text = positions[Count];
        CheckPosition();
        UpdateDesignData();
    }

    public void Backward()
    {
        Count--;
        textMesh.text = positions[Count];
        CheckPosition();
        UpdateDesignData();
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

    public void CheckPosition()
    {
        switch (count)
        {
            case 0: // Empty
                firstSticker.SetActive(false);
                secondSticker.SetActive(false);
                break;
            case 1: // Position 1
                firstSticker.SetActive(true);
                secondSticker.SetActive(false);
                break;
            case 2: // Position 2
                firstSticker.SetActive(false);
                secondSticker.SetActive(true);
                break;
            case 3: // Both
                firstSticker.SetActive(true);
                secondSticker.SetActive(true);
                break;
        }
    }

    public static void CheckPosition(GameObject first, GameObject second, int pos)
    {
        switch (pos)
        {
            case 0:
                first.SetActive(false);
                second.SetActive(false);
                break;
            case 1:
                first.SetActive(true);
                second.SetActive(false);
                break;
            case 2:
                first.SetActive(false);
                second.SetActive(true);
                break;
            case 3:
                first.SetActive(true);
                second.SetActive(true);
                break;
        }
    }

    private void UpdateDesignData()
    {
        switch (designDataIndex)
        {
            case 0:
                DesignData.TopLeftStickerTexPos = count;
                break;
            case 1:
                DesignData.TopRightStickerTexPos = count;
                break;
            case 2:
                DesignData.BottomLeftStickerTexPos = count;
                break;
            case 3:
                DesignData.BottomRightStickerTexPos = count;
                break;
        }
    }

    private void RetrieveDesignData()
    {
        switch (designDataIndex)
        {
            case 0:
                count = (int)DesignData.TopLeftStickerTexPos;
                break;
            case 1:
                count = (int)DesignData.TopRightStickerTexPos;
                break;
            case 2:
                count = (int)DesignData.BottomLeftStickerTexPos;
                break;
            case 3:
                count = (int)DesignData.BottomRightStickerTexPos;
                break;
        }
        ChangeText(Count);
    }
}
