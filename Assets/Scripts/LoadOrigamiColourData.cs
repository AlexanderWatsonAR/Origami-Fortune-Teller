using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOrigamiColourData : MonoBehaviour
{
    public Color[] colours;
    public GameObject[] origami;

    // Start is called before the first frame update
    void Start()
    {
        LoadPrimary();
    }

    public void LoadPrimary()
    {
        string entryIndex = CreateDecisionMaker.currentEntry.ToString();

        foreach (GameObject go in origami)
        {
            if (entryIndex == "-1")
            {
                // Set Primary Colour.
                // Bottom Left
                go.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", colours[10]);
                // Bottom Right
                go.transform.GetChild(1).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", colours[7]);
                // Top Left
                go.transform.GetChild(2).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", colours[2]);
                // Top Right
                go.transform.GetChild(3).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", colours[4]);
            }
            else
            {
                // Set Primary Colour.
                // Bottom Left
                go.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", colours[(int)PlayerPrefs.GetFloat("BottomLeftColourPrimary" + entryIndex)]);
                // Bottom Right
                go.transform.GetChild(1).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", colours[(int)PlayerPrefs.GetFloat("BottomRightColourPrimary" + entryIndex)]);
                // Top Left
                go.transform.GetChild(2).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", colours[(int)PlayerPrefs.GetFloat("TopLeftColourPrimary" + entryIndex)]);
                // Top Right
                go.transform.GetChild(3).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", colours[(int)PlayerPrefs.GetFloat("TopRightColourPrimary" + entryIndex)]);
            }
        }
    }
}
