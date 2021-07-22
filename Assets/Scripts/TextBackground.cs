using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextBackground : MonoBehaviour
{
    public Sprite[] borderImages;
    public GameObject border;
    public GameObject questionContainer;
    public GameObject borderContainer;

    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    //IEnumerator Start()
    //{
    //    text = GetComponent<TextMeshProUGUI>();
    //    yield return new WaitForSeconds(0.1f);
    //    BreakUpTextObject();
    //}

    public void BreakUpTextObject()
    {
        // Removes children from question & border Containers.
        Clear();

        int lineCount = text.textInfo.lineCount;

        if (lineCount == 0)
            return;

        int startIndex = 0;
        for (int i = 0; i < lineCount; i++)
        {
            GameObject newText = new GameObject();
            newText.name = "Line " + i.ToString();
            newText.AddComponent<RectTransform>();
            newText.AddComponent<TextMeshProUGUI>();
            newText.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1.0f);
            newText.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1.0f);
            newText.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Midline;
            newText.GetComponent<RectTransform>().sizeDelta = new Vector2(280, 100);
            newText.GetComponent<TextMeshProUGUI>().enableAutoSizing = false;
            newText.GetComponent<TextMeshProUGUI>().fontSize = text.fontSize;
            newText.GetComponent<TextMeshProUGUI>().font = text.font;
            newText.GetComponent<TextMeshProUGUI>().fontMaterial = text.fontMaterial;
            newText.GetComponent<TextMeshProUGUI>().fontSharedMaterial = text.fontSharedMaterial;
            newText.GetComponent<TextMeshProUGUI>().UpdateFontAsset();
            newText.GetComponent<TextMeshProUGUI>().text = "";

            int charsInLine = text.textInfo.lineInfo[i].characterCount;

            newText.GetComponent<TextMeshProUGUI>().text = text.text.Substring(startIndex, charsInLine);
            startIndex += charsInLine;

            newText.GetComponent<TextMeshProUGUI>().color = Color.black;

            Vector2 preferedSize = newText.GetComponent<TextMeshProUGUI>().GetPreferredValues();

            if(i != 0)
            {
                // if current width is greater than the width of the previous text AND
                // the current width - 15 is less than the width of the previous text.
                if (preferedSize.x > questionContainer.transform.GetChild(i - 1).GetComponent<RectTransform>().sizeDelta.x &&
                    preferedSize.x - 20 < questionContainer.transform.GetChild(i - 1).GetComponent<RectTransform>().sizeDelta.x)
                {
                    preferedSize.x = questionContainer.transform.GetChild(i - 1).GetComponent<RectTransform>().sizeDelta.x + 20;
                }
                // if current width is less than the width of the previous text AND
                // the current width + 20 is grester than the width of the previous text.
                if (preferedSize.x < questionContainer.transform.GetChild(i - 1).GetComponent<RectTransform>().sizeDelta.x &&
                   preferedSize.x + 20 > questionContainer.transform.GetChild(i - 1).GetComponent<RectTransform>().sizeDelta.x)
                {
                    Vector2 newSize = preferedSize;
                    newSize.x += 20;

                    questionContainer.transform.GetChild(i - 1).GetComponent<RectTransform>().sizeDelta = newSize;
                }
            }

            if (preferedSize.x < 65)
                preferedSize.x += 20;

            else if (preferedSize.x >= 65 && preferedSize.x <= 85)
                preferedSize.x += 15;

            else if (preferedSize.x > 85 && preferedSize.x < 160)
                preferedSize.x += 10;

            newText.GetComponent<RectTransform>().sizeDelta = preferedSize;
            newText.transform.SetParent(questionContainer.transform, true);
            newText.transform.localScale = Vector3.one;
        }

        if (lineCount == 5)
            questionContainer.GetComponent<VerticalLayoutGroup>().spacing = 1;
        
        AddBackground();

    }

    private void AddBackground()
    {
        switch (questionContainer.transform.childCount)
        {
            case 2:
                borderContainer.GetComponent<VerticalLayoutGroup>().spacing = -6.3f;
                break;

            case 4:
                borderContainer.GetComponent<VerticalLayoutGroup>().spacing = -6.2f;
                break;
        }

        //int count = 0;

        for (int i = 0; i < questionContainer.transform.childCount; i++)
        {
            GameObject newBorder = Instantiate(border);
            newBorder.name = "Border " + i.ToString();
            Vector2 prefferedSize = questionContainer.transform.GetChild(i).gameObject.GetComponent<RectTransform>().sizeDelta;
            prefferedSize.x -= (prefferedSize.x * 0.33f);

            newBorder.GetComponent<RectTransform>().sizeDelta = prefferedSize;
            newBorder.transform.SetParent(borderContainer.transform, true);
            newBorder.transform.localScale = Vector3.one;

            if (i != questionContainer.transform.childCount - 1)
            {
                if (questionContainer.transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x <
               questionContainer.transform.GetChild(i + 1).GetComponent<RectTransform>().sizeDelta.x)
                {

                    newBorder.GetComponent<Image>().sprite = borderImages[2];
                }
            }

            if (i != 0)
            {
                if (questionContainer.transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x <
                questionContainer.transform.GetChild(i - 1).GetComponent<RectTransform>().sizeDelta.x)
                {

                    newBorder.GetComponent<Image>().sprite = borderImages[0];
                }

                if (i == questionContainer.transform.childCount - 1)
                {
                    if (questionContainer.transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x ==
                    questionContainer.transform.GetChild(i - 1).GetComponent<RectTransform>().sizeDelta.x)
                    {

                        newBorder.GetComponent<Image>().sprite = borderImages[4];
                    }
                }
            }

            if (i != 0 && i != questionContainer.transform.childCount - 1)
            {
                if (questionContainer.transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x <
                questionContainer.transform.GetChild(i - 1).GetComponent<RectTransform>().sizeDelta.x &&
                questionContainer.transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x <
                questionContainer.transform.GetChild(i + 1).GetComponent<RectTransform>().sizeDelta.x)
                {

                    newBorder.GetComponent<Image>().sprite = borderImages[1];
                }
            }
        }
    }

    private void Clear()
    {
        for (int i = 0; i < questionContainer.transform.childCount; i++)
        {
            GameObject graveKeeper = questionContainer.transform.GetChild(i).gameObject;
            graveKeeper.transform.SetParent(null, false);
            Destroy(graveKeeper);
        }

        for (int i = 0; i < borderContainer.transform.childCount; i++)
        {
            GameObject graveKeeper = borderContainer.transform.GetChild(i).gameObject;
            graveKeeper.transform.SetParent(null, false);
            Destroy(graveKeeper);
        }

        if (questionContainer.transform.childCount != 0)
            Clear();

        if (borderContainer.transform.childCount != 0)
            Clear();
    }

}
