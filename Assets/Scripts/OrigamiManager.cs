using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OrigamiManager : MonoBehaviour
{
    private int maxFoldCount;
    private float foldCount;
    private string colourName;
    private string numberName;

    public GameObject Canvas;
    public GameObject SecondaryCanvas;
    public GameObject[] orgami;
    public Color[] colours;
    public string[] colourNames;
    public int[] origamiTextureHashPrimary;
    public int[] origamiTextureHashSecondary;
    public int[] origamiStickerHash;
    public AssetReferenceTexture[] TextureRefs;
    public AssetReferenceT<Material>[] StickerMaterialRefs;

    public GameObject ColourPallette;

    public static OrigamiManager instance;

    public float FoldCount
    {
        get
        {
            return foldCount;
        }
        set
        {
            foldCount = value;
        }
    }

    public int MaxFoldCount
    {
        get
        {
            return maxFoldCount;
        }
        set
        {
            maxFoldCount = value;
        }
    }

    public string ColourName
    {
        get
        {
            return colourName;
        }
        set
        {
            colourName = value;
        }
    }

    public string NumberName
    {
        get
        {
            return numberName;
        }
        set
        {
            numberName = value;
        }
    }

    private void Awake()
    {
        foldCount = 0;
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        LoadOrigamiDesignData();
        instance.FoldCount = 0;
        instance.MaxFoldCount = MaxFoldCount;
        if(ColourPallette != null)
            ColourPallette.SetActive(true);
    }

    public void PlayAnimation(int origamiIndex)
    {
        if (instance.orgami[origamiIndex].activeSelf)
        {
            instance.orgami[origamiIndex].GetComponent<Animator>().enabled = true;
            instance.orgami[origamiIndex].GetComponent<Animator>().Play(0);
        }
    }

    public void PlayAnimation(int origamiIndex, string animationName)
    {
        if (instance.orgami[origamiIndex].activeSelf)
        {
            instance.orgami[origamiIndex].GetComponent<Animator>().enabled = true;
            instance.orgami[origamiIndex].GetComponent<Animator>().Play(animationName);
        }
    }

    // Index will be relate to Top Left, Top Right, Bottom Left or Bottom Right segment of Origami.
    // Colour Buttons Trigger this.
    public void OrigamiSetup(int index)
    {
        Color tempColour = instance.orgami[0].transform.GetChild(index).GetComponent<Renderer>().material.GetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a");
        string tempColourName = "";

        for(int i = 0; i < colours.Length; i++)
        {
            if(Math.Round(tempColour.r, 3) == Math.Round(colours[i].r, 3) &&
               Math.Round(tempColour.g, 3) == Math.Round(colours[i].g, 3) &&
               Math.Round(tempColour.b, 3) == Math.Round(colours[i].b, 3))
            {
                tempColourName = colourNames[i];
                break;
            }
        }
        instance.MaxFoldCount = tempColourName.Length;
        instance.colourName = tempColourName;
        
    }

    public void LoadOrigamiDesignData()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            SceneManager.sceneLoaded += ChangeLast;
        }

        string entryIndex = CreateDecisionMaker.currentEntry.ToString();
        GameObject[] origami = { instance.orgami[0] };

        if(orgami.Length > 1)
            origami = new GameObject[] { instance.orgami[0], instance.orgami[1], instance.orgami[2], instance.orgami[3]};

        foreach (GameObject go in instance.orgami)
        {
            LoadPrimaryColourData(go, entryIndex);
            LoadSecondaryColourData(go, entryIndex);
            LoadPrimaryTexData(go, entryIndex);
            LoadSecondaryTexData(go, entryIndex);
            if(go.name != "origami 4")
                LoadStickerTexData(go, entryIndex);
        }


    }

    public void ChangeLast()
    {
        ChangeOrigamiColour.ChangeLastOrigami();
        ChangeOrigamiTexture.ChangeLastOrigami();
    }

    private void ChangeLast(Scene current, LoadSceneMode mode)
    {
        ChangeLast();
    }

    public void LoadPrimaryColourData(GameObject origami, string entryIndex)
    {
        if (entryIndex == "-1")
        {
            // Set Primary Colour.
            // Bottom Left
            origami.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", colours[10]);
            // Bottom Right
            origami.transform.GetChild(1).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", colours[7]);
            // Top Left
            origami.transform.GetChild(2).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", colours[2]);
            // Top Right
            origami.transform.GetChild(3).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", colours[4]);

        }
        else
        {
            // Set Primary Colour.
            // Bottom Left
            origami.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", colours[(int)PlayerPrefs.GetFloat("BottomLeftColourPrimary" + entryIndex)]);
            // Bottom Right
            origami.transform.GetChild(1).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", colours[(int)PlayerPrefs.GetFloat("BottomRightColourPrimary" + entryIndex)]);
            // Top Left
            origami.transform.GetChild(2).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", colours[(int)PlayerPrefs.GetFloat("TopLeftColourPrimary" + entryIndex)]);
            // Top Right
            origami.transform.GetChild(3).GetComponent<Renderer>().material.SetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a", colours[(int)PlayerPrefs.GetFloat("TopRightColourPrimary" + entryIndex)]);
        }
    }

    public void LoadSecondaryColourData(GameObject origami, string entryIndex)
    {
        if (entryIndex == "-1")
        {
            // Set Secondary Colour.
            // Bottom Left
            origami.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", colours[14]);
            // Bottom Right
            origami.transform.GetChild(1).GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", colours[14]);
            // Top Left
            origami.transform.GetChild(2).GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", colours[14]);
            // Top Right
            origami.transform.GetChild(3).GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", colours[14]);
        }
        else
        {
            // Set Secondary Colour.
            // Bottom Left
            origami.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", colours[(int)PlayerPrefs.GetFloat("BottomLeftColourSecondary" + entryIndex)]);
            // Bottom Right
            origami.transform.GetChild(1).GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", colours[(int)PlayerPrefs.GetFloat("BottomRightColourSecondary" + entryIndex)]);
            // Top Left
            origami.transform.GetChild(2).GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", colours[(int)PlayerPrefs.GetFloat("TopLeftColourSecondary" + entryIndex)]);
            // Top Right
            origami.transform.GetChild(3).GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", colours[(int)PlayerPrefs.GetFloat("TopRightColourSecondary" + entryIndex)]);
        }
    }

    public void LoadPrimaryTexData(GameObject origami, string entryIndex)
    {
        if (entryIndex == "-1")
            return;

        AssetReferenceTexture a = TextureRefs[(int)PlayerPrefs.GetFloat("BottomLeftTexPrimary" + entryIndex)];
        AssetReferenceTexture b = TextureRefs[(int)PlayerPrefs.GetFloat("BottomRightTexPrimary" + entryIndex)];
        AssetReferenceTexture c = TextureRefs[(int)PlayerPrefs.GetFloat("TopLeftTexPrimary" + entryIndex)];
        AssetReferenceTexture d = TextureRefs[(int)PlayerPrefs.GetFloat("TopRightTexPrimary" + entryIndex)];

        DataLoading.LoadTexData(origami, 0, a, "Texture2D_b614431639584fc99463f96af57246a8");
        DataLoading.LoadTexData(origami, 1, b, "Texture2D_b614431639584fc99463f96af57246a8");
        DataLoading.LoadTexData(origami, 2, c, "Texture2D_b614431639584fc99463f96af57246a8");
        DataLoading.LoadTexData(origami, 3, d, "Texture2D_b614431639584fc99463f96af57246a8");


        origamiTextureHashPrimary[0] = (int)PlayerPrefs.GetFloat("BottomLeftTexPrimary" + entryIndex);
        origamiTextureHashPrimary[1] = (int)PlayerPrefs.GetFloat("BottomRightTexPrimary" + entryIndex);
        origamiTextureHashPrimary[2] = (int)PlayerPrefs.GetFloat("TopLeftTexPrimary" + entryIndex);
        origamiTextureHashPrimary[3] = (int)PlayerPrefs.GetFloat("TopRightTexPrimary" + entryIndex);
    }

    public void LoadSecondaryTexData(GameObject origami, string entryIndex)
    {
        if (entryIndex == "-1")
            return;

        AssetReferenceTexture a = TextureRefs[(int)PlayerPrefs.GetFloat("BottomLeftTexSecondary" + entryIndex)];
        AssetReferenceTexture b = TextureRefs[(int)PlayerPrefs.GetFloat("BottomRightTexSecondary" + entryIndex)];
        AssetReferenceTexture c = TextureRefs[(int)PlayerPrefs.GetFloat("TopLeftTexSecondary" + entryIndex)];
        AssetReferenceTexture d = TextureRefs[(int)PlayerPrefs.GetFloat("TopRightTexSecondary" + entryIndex)];

        DataLoading.LoadTexData(origami, 0, a, "Texture2D_62f72c9e26a6475faf78c7bf7415b950");
        DataLoading.LoadTexData(origami, 1, b, "Texture2D_62f72c9e26a6475faf78c7bf7415b950");
        DataLoading.LoadTexData(origami, 2, c, "Texture2D_62f72c9e26a6475faf78c7bf7415b950");
        DataLoading.LoadTexData(origami, 3, d, "Texture2D_62f72c9e26a6475faf78c7bf7415b950");

        origamiTextureHashSecondary[0] = (int)PlayerPrefs.GetFloat("BottomLeftTexSecondary" + entryIndex);
        origamiTextureHashSecondary[1] = (int)PlayerPrefs.GetFloat("BottomRightTexSecondary" + entryIndex);
        origamiTextureHashSecondary[2] = (int)PlayerPrefs.GetFloat("TopLeftTexSecondary" + entryIndex);
        origamiTextureHashSecondary[3] = (int)PlayerPrefs.GetFloat("TopRightTexSecondary" + entryIndex);
    }

    public void LoadStickerTexData(GameObject origami, string entryIndex)
    {
        if (entryIndex == "-1")
            return;

        // Bottom Left
        Color blColour = origami.transform.GetChild(0).GetComponent<Renderer>().material.GetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a");
        // Bottom Right
        Color brColour = origami.transform.GetChild(1).GetComponent<Renderer>().material.GetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a");
        // Top Left
        Color tlColour = origami.transform.GetChild(2).GetComponent<Renderer>().material.GetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a");
        // Top Right
        Color trColour = origami.transform.GetChild(3).GetComponent<Renderer>().material.GetColor("Color_cc2877fbd4c8430591cd0e4dc9d8ad1a");

        ChangeOrigamiSticker.CheckPosition(origami.transform.GetChild(12).gameObject, origami.transform.GetChild(13).gameObject, (int)PlayerPrefs.GetFloat("TopLeftStickerTexPos" + entryIndex));
        ChangeOrigamiSticker.CheckPosition(origami.transform.GetChild(14).gameObject, origami.transform.GetChild(15).gameObject, (int)PlayerPrefs.GetFloat("TopRightStickerTexPos" + entryIndex));
        ChangeOrigamiSticker.CheckPosition(origami.transform.GetChild(16).gameObject, origami.transform.GetChild(17).gameObject, (int)PlayerPrefs.GetFloat("BottomRightStickerTexPos" + entryIndex));
        ChangeOrigamiSticker.CheckPosition(origami.transform.GetChild(18).gameObject, origami.transform.GetChild(19).gameObject, (int)PlayerPrefs.GetFloat("BottomLeftStickerTexPos" + entryIndex));

        AssetReferenceT<Material> a = StickerMaterialRefs[(int)PlayerPrefs.GetFloat("TopLeftStickerTex" + entryIndex)];
        AssetReferenceT<Material> b = StickerMaterialRefs[(int)PlayerPrefs.GetFloat("TopRightStickerTex" + entryIndex)];
        AssetReferenceT<Material> c = StickerMaterialRefs[(int)PlayerPrefs.GetFloat("BottomRightStickerTex" + entryIndex)];
        AssetReferenceT<Material> d = StickerMaterialRefs[(int)PlayerPrefs.GetFloat("BottomLeftStickerTex" + entryIndex)];
        
        origamiStickerHash[0] = (int)PlayerPrefs.GetFloat("TopRightStickerTex" + entryIndex);
        origamiStickerHash[1] = (int)PlayerPrefs.GetFloat("TopLeftStickerTex" + entryIndex);
        origamiStickerHash[2] = (int)PlayerPrefs.GetFloat("BottomRightStickerTex" + entryIndex);
        origamiStickerHash[3] = (int)PlayerPrefs.GetFloat("BottomLeftStickerTex" + entryIndex);

        // Top Left
        if (origami.transform.GetChild(12).gameObject.activeSelf)
        {
            DataLoading.LoadMaterialData(origami.transform.GetChild(12).gameObject, a, CheckAllStickerBorders);
            origami.transform.GetChild(12).gameObject.GetComponent<Renderer>().material.SetColor("Color_a699c866f1d14065bc7b7abae9858103", tlColour);
        }
        if (origami.transform.GetChild(13).gameObject.activeSelf)
        {
            DataLoading.LoadMaterialData(origami.transform.GetChild(13).gameObject, a, CheckAllStickerBorders);
            origami.transform.GetChild(13).gameObject.GetComponent<Renderer>().material.SetColor("Color_a699c866f1d14065bc7b7abae9858103", tlColour);
        }
        // Top Right
        if (origami.transform.GetChild(14).gameObject.activeSelf)
        {
            DataLoading.LoadMaterialData(origami.transform.GetChild(14).gameObject, b, CheckAllStickerBorders);
            origami.transform.GetChild(14).gameObject.GetComponent<Renderer>().material.SetColor("Color_a699c866f1d14065bc7b7abae9858103", trColour);
        }
        if (origami.transform.GetChild(15).gameObject.activeSelf)
        {
            DataLoading.LoadMaterialData(origami.transform.GetChild(15).gameObject, b, CheckAllStickerBorders);
            origami.transform.GetChild(15).gameObject.GetComponent<Renderer>().material.SetColor("Color_a699c866f1d14065bc7b7abae9858103", trColour);
        }
        // Bottom Right
        if (origami.transform.GetChild(16).gameObject.activeSelf)
        {
            DataLoading.LoadMaterialData(origami.transform.GetChild(16).gameObject, c, CheckAllStickerBorders);
            origami.transform.GetChild(16).gameObject.GetComponent<Renderer>().material.SetColor("Color_a699c866f1d14065bc7b7abae9858103", brColour);
        }
        if (origami.transform.GetChild(17).gameObject.activeSelf)
        {
            DataLoading.LoadMaterialData(origami.transform.GetChild(17).gameObject, c, CheckAllStickerBorders);
            origami.transform.GetChild(17).gameObject.GetComponent<Renderer>().material.SetColor("Color_a699c866f1d14065bc7b7abae9858103", brColour);
        }
        // Bottom Left
        if (origami.transform.GetChild(18).gameObject.activeSelf)
        {
            DataLoading.LoadMaterialData(origami.transform.GetChild(18).gameObject, d, CheckAllStickerBorders);
            origami.transform.GetChild(18).gameObject.GetComponent<Renderer>().material.SetColor("Color_a699c866f1d14065bc7b7abae9858103", blColour);
        }
        if (origami.transform.GetChild(19).gameObject.activeSelf)
        {
            DataLoading.LoadMaterialData(origami.transform.GetChild(19).gameObject, d, CheckAllStickerBorders);
            origami.transform.GetChild(19).gameObject.GetComponent<Renderer>().material.SetColor("Color_a699c866f1d14065bc7b7abae9858103", blColour);
        }

    }
    public int ColourIndex(Color colour)
    {
        for (int i = 0; i < colours.Length; i++)
        {
            if (Math.Round(colour.r, 3) == Math.Round(colours[i].r, 3) &&
               Math.Round(colour.g, 3) == Math.Round(colours[i].g, 3) &&
               Math.Round(colour.b, 3) == Math.Round(colours[i].b, 3))
            {
                return i;
            }
        }

        return 0;
    }

    public void CheckAllBorders()
    {
        ChangeOrigamiColour[] objects = FindObjectsOfType<ChangeOrigamiColour>();
        for(int i = 0; i < objects.Length; i++)
        {
            objects[i].Border();
        }
    }

    public void CheckAllTextureBorders()
    {

        ChangeOrigamiTexture[] textureObjects = FindObjectsOfType<ChangeOrigamiTexture>();
        for (int i = 0; i < textureObjects.Length; i++)
        {
            textureObjects[i].Border();
        }
    }

    public int CheckAllStickerBorders()
    {
        ChangeOrigamiSticker[] stickerObjects = FindObjectsOfType<ChangeOrigamiSticker>();
        for (int i = 0; i < stickerObjects.Length; i++)
        {
            if(stickerObjects[i].ColourDropdown != null)
                stickerObjects[i].Border();
        }
        return 0;
    }

    public void CheckAllStickerPositions()
    {
        ChangeOrigamiSticker[] stickerObjects = FindObjectsOfType<ChangeOrigamiSticker>();
        for (int i = 0; i < stickerObjects.Length; i++)
        {
            if(stickerObjects[i].isBorderActive)
                stickerObjects[i].ChangeSticker();
        }
    }

    public Color FindColourFromName(string thisColourName)
    {
        for(int i = 0; i < colourNames.Length; i++)
        {
            if(thisColourName == colourNames[i])
            {
                return colours[i];
            }
        }
        return Color.white;
    }

    public void StartChangeColour(TMPro.TextMeshProUGUI text, Color startColour, Color endColour)
    {
        StartCoroutine(ChangeColour(text, startColour, endColour));
    }

    public IEnumerator ChangeColour(TMPro.TextMeshProUGUI text, Color startColour, Color endColour)
    {
        float onePercent = 0.01666666666f;
        Vector3 from = new Vector3(startColour.r, startColour.g, startColour.b);
        Vector3 to = new Vector3(endColour.r, endColour.g, endColour.b);
        float interp = 1.0f;

        while (interp > 0.0f)
        {
            Vector3 result = Vector3.Lerp(from, to, interp);
            Color newColour = new Color(result.x, result.y, result.z, 1.0f);
            interp -= onePercent;
            text.color = newColour;

            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
    }
}
