using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class ConfigureDesigner : MonoBehaviour
{
    public GameObject[] PrimaryColourButtons;
    public GameObject[] SecondaryColourButtons;
    public GameObject[] primaryPatternButtons;
    public GameObject[] secondaryPatternButtons;
    public GameObject[] StickerButtons;

    public AssetReferenceSprite[] PatternSpriteRefs;
    public AssetReferenceSprite[] StickerSpriteRef;

    // Start is called before the first frame update
    void Start()
    {
        // Top Left
        PrimaryColourButtons[0].GetComponent<Image>().color = OrigamiManager.instance.orgami[0].transform.GetChild(2).GetComponent<Renderer>().material.GetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a");
        // Top Right
        PrimaryColourButtons[1].GetComponent<Image>().color = OrigamiManager.instance.orgami[0].transform.GetChild(3).GetComponent<Renderer>().material.GetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a");
        // Bottom Left
        PrimaryColourButtons[2].GetComponent<Image>().color = OrigamiManager.instance.orgami[0].transform.GetChild(0).GetComponent<Renderer>().material.GetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a");
        //Bottom Right
        PrimaryColourButtons[3].GetComponent<Image>().color = OrigamiManager.instance.orgami[0].transform.GetChild(1).GetComponent<Renderer>().material.GetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a");

        // Top Left
        SecondaryColourButtons[0].GetComponent<Image>().color = OrigamiManager.instance.orgami[0].transform.GetChild(2).GetComponent<Renderer>().material.GetColor("Color_27bc9690873845048adc1140e1c09a57");
        // Top Right
        SecondaryColourButtons[1].GetComponent<Image>().color = OrigamiManager.instance.orgami[0].transform.GetChild(3).GetComponent<Renderer>().material.GetColor("Color_27bc9690873845048adc1140e1c09a57");
        // Bottom Left
        SecondaryColourButtons[2].GetComponent<Image>().color = OrigamiManager.instance.orgami[0].transform.GetChild(0).GetComponent<Renderer>().material.GetColor("Color_27bc9690873845048adc1140e1c09a57");
        //Bottom Right
        SecondaryColourButtons[3].GetComponent<Image>().color = OrigamiManager.instance.orgami[0].transform.GetChild(1).GetComponent<Renderer>().material.GetColor("Color_27bc9690873845048adc1140e1c09a57");

        string entryIndex = CreateDecisionMaker.currentEntry.ToString();

        DataLoading.GetSpriteFromRef(PatternSpriteRefs[(int)PlayerPrefs.GetFloat("TopLeftTexPrimary" + entryIndex)], primaryPatternButtons[0].GetComponent<Image>());
        DataLoading.GetSpriteFromRef(PatternSpriteRefs[(int)PlayerPrefs.GetFloat("TopRightTexPrimary" + entryIndex)], primaryPatternButtons[1].GetComponent<Image>());
        DataLoading.GetSpriteFromRef(PatternSpriteRefs[(int)PlayerPrefs.GetFloat("BottomLeftTexPrimary" + entryIndex)], primaryPatternButtons[2].GetComponent<Image>());
        DataLoading.GetSpriteFromRef(PatternSpriteRefs[(int)PlayerPrefs.GetFloat("BottomRightTexPrimary" + entryIndex)], primaryPatternButtons[3].GetComponent<Image>());

        DataLoading.GetSpriteFromRef(PatternSpriteRefs[(int)PlayerPrefs.GetFloat("TopLeftTexSecondary" + entryIndex)], secondaryPatternButtons[0].GetComponent<Image>());
        DataLoading.GetSpriteFromRef(PatternSpriteRefs[(int)PlayerPrefs.GetFloat("TopRightTexSecondary" + entryIndex)], secondaryPatternButtons[1].GetComponent<Image>());
        DataLoading.GetSpriteFromRef(PatternSpriteRefs[(int)PlayerPrefs.GetFloat("BottomLeftTexSecondary" + entryIndex)], secondaryPatternButtons[2].GetComponent<Image>());
        DataLoading.GetSpriteFromRef(PatternSpriteRefs[(int)PlayerPrefs.GetFloat("BottomRightTexSecondary" + entryIndex)], secondaryPatternButtons[3].GetComponent<Image>());

        DataLoading.GetSpriteFromRef(StickerSpriteRef[(int)PlayerPrefs.GetFloat("TopLeftStickerTex" + entryIndex)], StickerButtons[0].GetComponent<Image>());
        DataLoading.GetSpriteFromRef(StickerSpriteRef[(int)PlayerPrefs.GetFloat("TopRightStickerTex" + entryIndex)], StickerButtons[1].GetComponent<Image>());
        DataLoading.GetSpriteFromRef(StickerSpriteRef[(int)PlayerPrefs.GetFloat("BottomLeftStickerTex" + entryIndex)], StickerButtons[2].GetComponent<Image>());
        DataLoading.GetSpriteFromRef(StickerSpriteRef[(int)PlayerPrefs.GetFloat("BottomRightStickerTex" + entryIndex)], StickerButtons[3].GetComponent<Image>());
    }
}
