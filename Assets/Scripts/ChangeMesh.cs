using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeMesh : MonoBehaviour
{
    public GameObject NextOrigami;
    public GameObject text;
    public GameObject numberText;
    public GameObject selectText;
    public GameObject numberButtons;
    public GameObject flapButtons;
    private TextMeshProUGUI colourNameText;
    private TextMeshProUGUI numberNameText;

    private void Start()
    {
        if(text != null)
            colourNameText = text.GetComponent<TextMeshProUGUI>();
        if(numberText != null)
            numberNameText = numberText.GetComponent<TextMeshProUGUI>();
    }

    // Loops between 2 prefabs.
    public void NextMesh()
    {
        if ((int)OrigamiManager.instance.FoldCount != OrigamiManager.instance.MaxFoldCount)
        {
            NextOrigami.SetActive(true);
            NextOrigami.GetComponent<Animator>().enabled = true;
            NextOrigami.GetComponent<Animator>().Play(0);
            gameObject.SetActive(false);
            if (OrigamiManager.instance.FoldCount % 1 == 0)
            {
                if (colourNameText.text != OrigamiManager.instance.ColourName)
                {
                    char[] colourChars = OrigamiManager.instance.ColourName.ToCharArray();
                    colourNameText.text += colourChars[(int)OrigamiManager.instance.FoldCount];
                    OrigamiManager.instance.StartChangeColour(colourNameText, Color.white, OrigamiManager.instance.FindColourFromName(OrigamiManager.instance.ColourName));
                }
                else
                {
                    float a = (int)OrigamiManager.instance.FoldCount;
                    numberNameText.text = a.ToString();
                }
            }

            OrigamiManager.instance.FoldCount += 0.5f;
        }
        else
        {
            colourNameText.text = OrigamiManager.instance.ColourName;

            if (numberNameText.text == "" && OrigamiManager.instance.FoldCount == 1)
            {
                numberNameText.text = OrigamiManager.instance.FoldCount.ToString();
            }

            if (numberNameText.text == "")
            {
                numberButtons.SetActive(true);
                selectText.GetComponent<TextMeshProUGUI>().text = "Select a number";
            }
            else
            {
                numberNameText.text = OrigamiManager.instance.FoldCount.ToString();
                OrigamiManager.instance.orgami[3].SetActive(true);
                OrigamiManager.instance.orgami[3].GetComponent<Animator>().enabled = true;
                OrigamiManager.instance.orgami[3].GetComponent<Animator>().Play(0);
                selectText.GetComponent<TextMeshProUGUI>().text = "Pick a fold";
                flapButtons.SetActive(true);
                numberButtons.SetActive(false);
                gameObject.SetActive(false);
            }

            OrigamiManager.instance.FoldCount = 0.5f;
        }
    }

    public void NextOrigamiModel()
    {
        NextOrigami.SetActive(true);
        gameObject.SetActive(false);
    }

    public void NextOrigamiModelDontDisable()
    {
        NextOrigami.SetActive(true);

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<SkinnedMeshRenderer>() != null)
                transform.GetChild(i).GetComponent<SkinnedMeshRenderer>().enabled = false;
        }
    }

}
