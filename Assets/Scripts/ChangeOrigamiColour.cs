using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeOrigamiColour : MonoBehaviour
{
    public GameObject SegmentDropdown;
    public GameObject ColourDropdown;


    private TMP_Dropdown segmentDropdown;
    private TMP_Dropdown colourDropdown;
    private float colourIndex;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform.parent.GetChild(i).name == name)
                colourIndex = i;
        }

        segmentDropdown = SegmentDropdown.GetComponent<TMP_Dropdown>();
        colourDropdown = ColourDropdown.GetComponent<TMP_Dropdown>();

        segmentDropdown.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(segmentDropdown);
        });

        colourDropdown.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(colourDropdown);
        });
    }

    private void DropdownValueChanged(TMP_Dropdown change)
    {
        Border();
    }

    public void ChangeColour()
    {
        foreach (GameObject orig in OrigamiManager.instance.orgami)
        {
            // Sets primary colour.  
            switch (segmentDropdown.options[segmentDropdown.value].text)
            {
                case "Top Right":
                    if (colourDropdown.options[colourDropdown.value].text == "Primary")
                    {
                        orig.transform.GetChild(3).gameObject.GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", GetComponent<Image>().color);
                        DesignData.TopRightColourPrimary = colourIndex;
                    }
                    else
                    {
                        orig.transform.GetChild(3).gameObject.GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", GetComponent<Image>().color);
                        DesignData.TopRightColourSecondary = colourIndex;
                    }
                    break;
                case "Top Left":
                    if (colourDropdown.options[colourDropdown.value].text == "Primary")
                    {
                        orig.transform.GetChild(2).gameObject.GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", GetComponent<Image>().color);
                        DesignData.TopLeftColourPrimary = colourIndex;
                    }
                    else
                    {
                        orig.transform.GetChild(2).gameObject.GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", GetComponent<Image>().color);
                        DesignData.TopLeftColourSecondary = colourIndex;
                    }
                    break;
                case "Bottom Right":
                    if (colourDropdown.options[colourDropdown.value].text == "Primary")
                    {
                        orig.transform.GetChild(1).gameObject.GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", GetComponent<Image>().color);
                        DesignData.BottomRightColourPrimary = colourIndex;
                    }
                    else
                    {
                        orig.transform.GetChild(1).gameObject.GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", GetComponent<Image>().color);
                        DesignData.BottomRightColourSecondary = colourIndex;
                    }
                    break;
                case "Bottom Left":
                    if (colourDropdown.options[colourDropdown.value].text == "Primary")
                    {
                        orig.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", GetComponent<Image>().color);
                        DesignData.BottomLeftColourPrimary = colourIndex;
                    }
                    else
                    {
                        orig.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", GetComponent<Image>().color);
                        DesignData.BottomLeftColourSecondary = colourIndex;
                    }
                    break;
            }

        }
    }
    private void OnEnable()
    {
        Border();
    }

    public void Border()
    {
        Color colour = new Color();
        Color imageColour = GetComponent<Image>().color;
        switch (segmentDropdown.options[segmentDropdown.value].text)
        {
            case "Top Right":
                if (colourDropdown.options[colourDropdown.value].text == "Primary")
                    colour = OrigamiManager.instance.orgami[0].transform.GetChild(3).GetComponent<Renderer>().material.GetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a");
                else
                    colour = OrigamiManager.instance.orgami[0].transform.GetChild(3).GetComponent<Renderer>().material.GetColor("Color_27bc9690873845048adc1140e1c09a57");
                break;
            case "Top Left":
                if (colourDropdown.options[colourDropdown.value].text == "Primary")
                    colour = OrigamiManager.instance.orgami[0].transform.GetChild(2).GetComponent<Renderer>().material.GetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a");
                else
                    colour = OrigamiManager.instance.orgami[0].transform.GetChild(2).GetComponent<Renderer>().material.GetColor("Color_27bc9690873845048adc1140e1c09a57");
                break;
            case "Bottom Right":
                if (colourDropdown.options[colourDropdown.value].text == "Primary")
                    colour = OrigamiManager.instance.orgami[0].transform.GetChild(1).GetComponent<Renderer>().material.GetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a");
                else
                    colour = OrigamiManager.instance.orgami[0].transform.GetChild(1).GetComponent<Renderer>().material.GetColor("Color_27bc9690873845048adc1140e1c09a57");
                break;
            case "Bottom Left":
                if (colourDropdown.options[colourDropdown.value].text == "Primary")
                    colour = OrigamiManager.instance.orgami[0].transform.GetChild(0).GetComponent<Renderer>().material.GetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a");
                else
                    colour = OrigamiManager.instance.orgami[0].transform.GetChild(0).GetComponent<Renderer>().material.GetColor("Color_27bc9690873845048adc1140e1c09a57");
                break;
        }

        if (Math.Round(colour.r, 3) == Math.Round(imageColour.r, 3) &&
            Math.Round(colour.g, 3) == Math.Round(imageColour.g, 3) &&
            Math.Round(colour.b, 3) == Math.Round(imageColour.b, 3))
        {
            transform.GetChild(0).GetComponent<Image>().enabled = true;
        }
        else
        {
            transform.GetChild(0).GetComponent<Image>().enabled = false;
        }

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Main")
            ChangeLastOrigami();
    }

    public static void ChangeLastOrigami()
    {
        Color[] secondaryColours =  new Color[4];

        secondaryColours[0] = OrigamiManager.instance.orgami[0].transform.GetChild(0).GetComponent<Renderer>().material.GetColor("Color_27bc9690873845048adc1140e1c09a57"); // Bottom Left
        secondaryColours[1] = OrigamiManager.instance.orgami[0].transform.GetChild(1).GetComponent<Renderer>().material.GetColor("Color_27bc9690873845048adc1140e1c09a57"); // Bottom Right.
        secondaryColours[2] = OrigamiManager.instance.orgami[0].transform.GetChild(2).GetComponent<Renderer>().material.GetColor("Color_27bc9690873845048adc1140e1c09a57"); // Top Left
        secondaryColours[3] = OrigamiManager.instance.orgami[0].transform.GetChild(3).GetComponent<Renderer>().material.GetColor("Color_27bc9690873845048adc1140e1c09a57"); // Top Right

        int last = OrigamiManager.instance.orgami.Length - 1;

        OrigamiManager.instance.orgami[last].transform.GetChild(0).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", secondaryColours[1]); // Bottom Right
        OrigamiManager.instance.orgami[last].transform.GetChild(0).GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", secondaryColours[0]); // Bottom Left

        OrigamiManager.instance.orgami[last].transform.GetChild(1).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", secondaryColours[0]); // Left Top
        OrigamiManager.instance.orgami[last].transform.GetChild(1).GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", secondaryColours[2]); // Left Bottom

        OrigamiManager.instance.orgami[last].transform.GetChild(2).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", secondaryColours[3]); // Right Bottom
        OrigamiManager.instance.orgami[last].transform.GetChild(2).GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", secondaryColours[1]); // Right Top

        OrigamiManager.instance.orgami[last].transform.GetChild(3).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", secondaryColours[2]); // Top Left
        OrigamiManager.instance.orgami[last].transform.GetChild(3).GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", secondaryColours[3]); // Top Right

        // 16, 17, 18, 19.
        OrigamiManager.instance.orgami[last].transform.GetChild(16).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", secondaryColours[1]); // Bottom Right
        OrigamiManager.instance.orgami[last].transform.GetChild(16).GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", secondaryColours[0]); // Bottom Left

        OrigamiManager.instance.orgami[last].transform.GetChild(17).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", secondaryColours[0]); // Left Top
        OrigamiManager.instance.orgami[last].transform.GetChild(17).GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", secondaryColours[2]); // Left Bottom

        OrigamiManager.instance.orgami[last].transform.GetChild(18).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", secondaryColours[3]); // Right Bottom
        OrigamiManager.instance.orgami[last].transform.GetChild(18).GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", secondaryColours[1]); // Right Top

        OrigamiManager.instance.orgami[last].transform.GetChild(19).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", secondaryColours[2]); // Top Left
        OrigamiManager.instance.orgami[last].transform.GetChild(19).GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", secondaryColours[3]); // Top Right

    }
}
