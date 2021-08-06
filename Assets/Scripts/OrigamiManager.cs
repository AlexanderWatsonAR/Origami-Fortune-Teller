using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

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
        string entryIndex = CreateDecisionMaker.currentEntry.ToString();
        GameObject[] origami = { instance.orgami[0] };

        if(orgami.Length > 1)
            origami = new GameObject[] { instance.orgami[0], instance.orgami[1], instance.orgami[2], instance.orgami[3]};

        foreach (GameObject go in origami)
        {
            LoadPrimaryColourData(go, entryIndex);
            LoadSecondaryColourData(go, entryIndex);
            LoadPrimaryTexData(go, entryIndex);
            LoadSecondaryTexData(go, entryIndex);
            LoadStickerTexData(go, entryIndex);

            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Main")
            {
                ChangeOrigamiColour.ChangeLastOrigami();
                ChangeOrigamiTexture.ChangeLastOrigami();
            }

        }
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
            origami.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", colours[10]);
            // Bottom Right
            origami.transform.GetChild(1).GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", colours[7]);
            // Top Left
            origami.transform.GetChild(2).GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", colours[2]);
            // Top Right
            origami.transform.GetChild(3).GetComponent<Renderer>().material.SetColor("Color_27bc9690873845048adc1140e1c09a57", colours[4]);
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

        LoadTexData(origami, 0, a, "Texture2D_b614431639584fc99463f96af57246a8");
        LoadTexData(origami, 1, b, "Texture2D_b614431639584fc99463f96af57246a8");
        LoadTexData(origami, 2, c, "Texture2D_b614431639584fc99463f96af57246a8");
        LoadTexData(origami, 3, d, "Texture2D_b614431639584fc99463f96af57246a8");


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

        LoadTexData(origami, 0, a, "Texture2D_62f72c9e26a6475faf78c7bf7415b950");
        LoadTexData(origami, 1, b, "Texture2D_62f72c9e26a6475faf78c7bf7415b950");
        LoadTexData(origami, 2, c, "Texture2D_62f72c9e26a6475faf78c7bf7415b950");
        LoadTexData(origami, 3, d, "Texture2D_62f72c9e26a6475faf78c7bf7415b950");

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
            LoadMaterialData(origami, 12, a);
            origami.transform.GetChild(12).gameObject.GetComponent<Renderer>().material.SetColor("Color_a699c866f1d14065bc7b7abae9858103", tlColour);
        }
        if (origami.transform.GetChild(13).gameObject.activeSelf)
        {
            LoadMaterialData(origami, 13, a);
            origami.transform.GetChild(13).gameObject.GetComponent<Renderer>().material.SetColor("Color_a699c866f1d14065bc7b7abae9858103", tlColour);
        }
        // Top Right
        if (origami.transform.GetChild(14).gameObject.activeSelf)
        {
            LoadMaterialData(origami, 14, b);
            origami.transform.GetChild(14).gameObject.GetComponent<Renderer>().material.SetColor("Color_a699c866f1d14065bc7b7abae9858103", trColour);
        }
        if (origami.transform.GetChild(15).gameObject.activeSelf)
        {
            LoadMaterialData(origami, 15, b);
            origami.transform.GetChild(15).gameObject.GetComponent<Renderer>().material.SetColor("Color_a699c866f1d14065bc7b7abae9858103", trColour);
        }
        // Bottom Right
        if (origami.transform.GetChild(16).gameObject.activeSelf)
        {
            LoadMaterialData(origami, 16, c);
            origami.transform.GetChild(16).gameObject.GetComponent<Renderer>().material.SetColor("Color_a699c866f1d14065bc7b7abae9858103", brColour);
        }
        if (origami.transform.GetChild(17).gameObject.activeSelf)
        {
            LoadMaterialData(origami, 17, c);
            origami.transform.GetChild(17).gameObject.GetComponent<Renderer>().material.SetColor("Color_a699c866f1d14065bc7b7abae9858103", brColour);
        }
        // Bottom Left
        if (origami.transform.GetChild(18).gameObject.activeSelf)
        {
            LoadMaterialData(origami, 18, d);
            origami.transform.GetChild(18).gameObject.GetComponent<Renderer>().material.SetColor("Color_a699c866f1d14065bc7b7abae9858103", blColour);
        }
        if (origami.transform.GetChild(19).gameObject.activeSelf)
        {
            LoadMaterialData(origami, 19, d);
            origami.transform.GetChild(19).gameObject.GetComponent<Renderer>().material.SetColor("Color_a699c866f1d14065bc7b7abae9858103", blColour);
        }

    }

    public void LoadMaterialData(GameObject origami, int childIndex, AssetReferenceT<Material> stickerRef)
    {
        if (stickerRef.OperationHandle.IsValid())
        {
            if (!stickerRef.OperationHandle.IsDone)
            {
                stickerRef.OperationHandle.Completed += (AsyncOperationHandle obj) =>
                {
                    if (obj.IsValid() && obj.Result != null)
                    {
                        origami.transform.GetChild(childIndex).GetComponent<Renderer>().material = obj.Convert<Material>().Result;
                        CheckAllStickerBorders();
                    }
                };
            }
            else
            {
                origami.transform.GetChild(childIndex).GetComponent<Renderer>().material = stickerRef.OperationHandle.Convert<Material>().Result;
                CheckAllStickerBorders();
            }
        }
        else
        {
            stickerRef.LoadAssetAsync<Material>().Completed += (AsyncOperationHandle<Material> obj) =>
            {
                if (obj.IsValid() && obj.Result != null)
                {
                    origami.transform.GetChild(childIndex).GetComponent<Renderer>().material = obj.Result;
                    CheckAllStickerBorders();
                }
            };
        }
    }

    public void LoadTexData(GameObject origami, int childIndex, AssetReferenceTexture texReference, string ID)
    {
        if(texReference.OperationHandle.IsValid())
        {
            if(!texReference.OperationHandle.IsDone)
            {
                texReference.OperationHandle.Completed += (AsyncOperationHandle obj) =>
                {
                    if(obj.IsValid() && obj.Result != null)
                    {
                        origami.transform.GetChild(childIndex).GetComponent<Renderer>().material.SetTexture(ID, obj.Convert<Texture>().Result);
                    }
                };
            }
            else
            {
                origami.transform.GetChild(childIndex).GetComponent<Renderer>().material.SetTexture(ID, texReference.OperationHandle.Convert<Texture>().Result);
            }
        }
        else
        {
            texReference.LoadAssetAsync<Texture>().Completed += (AsyncOperationHandle<Texture> obj) =>
            {
                if (obj.IsValid() && obj.Result != null)
                {
                    origami.transform.GetChild(childIndex).GetComponent<Renderer>().material.SetTexture(ID, obj.Result);
                }
            };
        }
    }

    public Texture GetTextureFromMaterial(AssetReferenceT<Material> stickerRef)
    {
        Texture temp = null;
        if (stickerRef.OperationHandle.IsValid())
        {
            if (!stickerRef.OperationHandle.IsDone)
            {
                stickerRef.OperationHandle.Completed += (AsyncOperationHandle obj) =>
                {
                    if (obj.IsValid() && obj.Result != null)
                    {
                        temp = obj.Convert<Material>().Result.mainTexture;
                    }
                };
            }
            else
            {
                temp = stickerRef.OperationHandle.Convert<Material>().Result.mainTexture;
            }
        }
        else
        {
            stickerRef.LoadAssetAsync<Material>().Completed += (AsyncOperationHandle<Material> obj) =>
            {
                if (obj.IsValid() && obj.Result != null)
                {
                    temp = obj.Result.mainTexture;
                }
            };
        }
        return temp;
    }

    public void GetSpriteFromRef(AssetReferenceSprite stickerRef, Image image)
    {
        // If asset has already started being loaded into memory.
        if (stickerRef.OperationHandle.IsValid())
        {
            // if loading is not already completed.
            if (!stickerRef.OperationHandle.IsDone)
            {
                stickerRef.OperationHandle.Completed += (AsyncOperationHandle obj) =>
                {
                    if (obj.IsValid() && obj.Result != null)
                    {
                        image.sprite = obj.Convert<Sprite>().Result;
                    }
                };
            }
            // if loading is completed.
            else
            {
                image.sprite = stickerRef.OperationHandle.Convert<Sprite>().Result;
            }
        }
        else
        {
            // if loading hasn't started.
            stickerRef.LoadAssetAsync<Sprite>().Completed += (AsyncOperationHandle<Sprite> obj) =>
            {
                if (obj.IsValid() && obj.Result != null)
                {
                    image.sprite = obj.Result;
                }
            };
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

    public void CheckAllStickerBorders()
    {
        ChangeOrigamiSticker[] stickerObjects = FindObjectsOfType<ChangeOrigamiSticker>();
        for (int i = 0; i < stickerObjects.Length; i++)
        {
            stickerObjects[i].Border();
        }
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

}
