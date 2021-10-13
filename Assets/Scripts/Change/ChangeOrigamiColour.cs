using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeOrigamiColour : Change
{
    public GameObject primaryColours;
    public GameObject secondaryColours;

    private float colourIndex;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform.parent.GetChild(i).name == name)
                colourIndex = i;
        }

        Border();
    }

    public override void ChangeState()
    {
        ChangeColour();
    }

    public void ChangeColour()
    {
        foreach (GameObject orig in OrigamiManager.instance.orgami)
        {
            switch (pickerIndex)
            {
                case 0:
                    orig.transform.GetChild(2).gameObject.GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", GetComponent<Image>().color);
                    DesignData.TopLeftColourPrimary = colourIndex;
                    break;
                case 1:
                    orig.transform.GetChild(3).gameObject.GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", GetComponent<Image>().color);
                    DesignData.TopRightColourPrimary = colourIndex;
                    break;
                case 2:
                    orig.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", GetComponent<Image>().color);
                    DesignData.BottomLeftColourPrimary = colourIndex;
                    break;
                case 3:
                    orig.transform.GetChild(1).gameObject.GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", GetComponent<Image>().color);
                    DesignData.BottomRightColourPrimary = colourIndex;
                    break;
                case 4:
                    orig.transform.GetChild(2).gameObject.GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", GetComponent<Image>().color);
                    DesignData.TopLeftColourSecondary = colourIndex;
                    break;
                case 5:
                    orig.transform.GetChild(3).gameObject.GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", GetComponent<Image>().color);
                    DesignData.TopRightColourSecondary = colourIndex;
                    break;
                case 6:
                    orig.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", GetComponent<Image>().color);
                    DesignData.BottomLeftColourSecondary = colourIndex;
                    break;
                case 7:
                    orig.transform.GetChild(1).gameObject.GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", GetComponent<Image>().color);
                    DesignData.BottomRightColourSecondary = colourIndex;
                    break;
            }

            if(pickerIndex > -1 && pickerIndex < 4)
            {
                primaryColours.transform.GetChild(pickerIndex + 1).gameObject.GetComponent<Image>().color = GetComponent<Image>().color;
            }
            else
            {
                secondaryColours.transform.GetChild(pickerIndex - 3).gameObject.GetComponent<Image>().color = GetComponent<Image>().color;
            }
        }
    }

    public override void Border()
    {
        Color colour = new Color();
        Color imageColour = GetComponent<Image>().color;

        switch (pickerIndex)
        {
            case 0:
                // Top Left Primary
                colour = OrigamiManager.instance.orgami[0].transform.GetChild(2).GetComponent<Renderer>().material.GetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a");
                break;
            case 1:
                // Top Right Primary
                colour = OrigamiManager.instance.orgami[0].transform.GetChild(3).GetComponent<Renderer>().material.GetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a");
                break;
            case 2:
                // Bottom Left Primary
                colour = OrigamiManager.instance.orgami[0].transform.GetChild(0).GetComponent<Renderer>().material.GetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a");
                break;
            case 3:
                // Bottom Right Primary
                colour = OrigamiManager.instance.orgami[0].transform.GetChild(1).GetComponent<Renderer>().material.GetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a");
                break;
            case 4:
                // Top Left Secondary
                colour = OrigamiManager.instance.orgami[0].transform.GetChild(2).GetComponent<Renderer>().material.GetColor("Color_27bc9690873845048adc1140e1c09a57");
                break;
            case 5:
                // Top Right Secondary
                colour = OrigamiManager.instance.orgami[0].transform.GetChild(3).GetComponent<Renderer>().material.GetColor("Color_27bc9690873845048adc1140e1c09a57");
                break;
            case 6:
                // Bottom Left Secondary
                colour = OrigamiManager.instance.orgami[0].transform.GetChild(0).GetComponent<Renderer>().material.GetColor("Color_27bc9690873845048adc1140e1c09a57");
                break;
            case 7:
                // Bottom Right Secondary
                colour = OrigamiManager.instance.orgami[0].transform.GetChild(1).GetComponent<Renderer>().material.GetColor("Color_27bc9690873845048adc1140e1c09a57");
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
    }
}
