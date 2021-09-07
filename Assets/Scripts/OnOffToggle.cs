using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffToggle : MonoBehaviour
{
    public GameObject knob;
    public GameObject toggleBackground;
    public GameObject background;
    public Color onColour;
    public Color offColour;
    public GameObject onText;
    public GameObject offText;

    public void ToggleKnob()
    {
        RectTransform rectTransform = knob.transform as RectTransform;
        Image image = toggleBackground.GetComponent<Image>();

        // If Right Pos set to left pos.
        if (rectTransform.anchoredPosition.x == 60)
        {
            rectTransform.anchoredPosition = new Vector2(-60, 0);
            image.color = offColour;
            offText.SetActive(true);
            onText.SetActive(false);
            toggleBackground.GetComponent<Mask>().enabled = false;
            background.SetActive(false);
        }
        // Else set to right pos.
        else
        {
            rectTransform.anchoredPosition = new Vector2(60, 0);
            image.color = onColour;
            offText.SetActive(false);
            onText.SetActive(true);
            toggleBackground.GetComponent<Mask>().enabled = true;
            background.SetActive(true);
        }
    }
}
