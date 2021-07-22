using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class ChangeOrigamiTexture : MonoBehaviour
{
    public AssetReferenceTexture texture;
    public int textureHash;
    private float textureIndex;

    public GameObject SegmentDropdown;
    public GameObject ColourDropdown;

    private TMP_Dropdown segmentDropdown;
    private TMP_Dropdown colourDropdown;
    void Awake()
    {
        for(int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform.parent.GetChild(i).name == name)
                textureIndex = i;
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

        //if (texture == null)
        //    texture = new Texture2D(0,0);
    }

    private void DropdownValueChanged(TMP_Dropdown change)
    {
        Border();
    }

    public void ChangeTexture()
    {
        foreach (GameObject origami in OrigamiManager.instance.orgami)
        {
            switch (segmentDropdown.options[segmentDropdown.value].text)
            {
                case "Top Right":
                    if (colourDropdown.options[colourDropdown.value].text == "Primary")
                    {
                        OrigamiManager.instance.LoadTexData(origami, 3, texture, "Texture2D_b614431639584fc99463f96af57246a8");
                        //origami.transform.GetChild(3).GetComponent<Renderer>().material.SetTexture("Texture2D_b614431639584fc99463f96af57246a8", texture);
                        OrigamiManager.instance.origamiTextureHashPrimary[3] = textureHash;
                        DesignData.TopRightTexPrimary = textureIndex;
                    }
                    else
                    {
                        OrigamiManager.instance.LoadTexData(origami, 3, texture, "Texture2D_62f72c9e26a6475faf78c7bf7415b950");
                        //origami.transform.GetChild(3).GetComponent<Renderer>().material.SetTexture("Texture2D_62f72c9e26a6475faf78c7bf7415b950", texture);
                        OrigamiManager.instance.origamiTextureHashSecondary[3] = textureHash;
                        DesignData.TopRightTexSecondary = textureIndex;
                    }
                    break;
                case "Top Left":
                    if (colourDropdown.options[colourDropdown.value].text == "Primary")
                    {
                        OrigamiManager.instance.LoadTexData(origami, 2, texture, "Texture2D_b614431639584fc99463f96af57246a8");
                        //origami.transform.GetChild(2).GetComponent<Renderer>().material.SetTexture("Texture2D_b614431639584fc99463f96af57246a8", texture);
                        OrigamiManager.instance.origamiTextureHashPrimary[2] = textureHash;
                        DesignData.TopLeftTexPrimary = textureIndex;
                    }
                    else
                    {
                        OrigamiManager.instance.LoadTexData(origami, 2, texture, "Texture2D_62f72c9e26a6475faf78c7bf7415b950");
                        //origami.transform.GetChild(2).GetComponent<Renderer>().material.SetTexture("Texture2D_62f72c9e26a6475faf78c7bf7415b950", texture);
                        OrigamiManager.instance.origamiTextureHashSecondary[2] = textureHash;
                        DesignData.TopLeftTexSecondary = textureIndex;
                    }
                    break;
                case "Bottom Right":
                    if (colourDropdown.options[colourDropdown.value].text == "Primary")
                    {
                        OrigamiManager.instance.LoadTexData(origami, 1, texture, "Texture2D_b614431639584fc99463f96af57246a8");
                        //origami.transform.GetChild(1).GetComponent<Renderer>().material.SetTexture("Texture2D_b614431639584fc99463f96af57246a8", texture);
                        OrigamiManager.instance.origamiTextureHashPrimary[1] = textureHash;
                        DesignData.BottomRightTexPrimary = textureIndex;
                    }
                    else
                    {
                        OrigamiManager.instance.LoadTexData(origami, 1, texture, "Texture2D_62f72c9e26a6475faf78c7bf7415b950");
                        //origami.transform.GetChild(1).GetComponent<Renderer>().material.SetTexture("Texture2D_62f72c9e26a6475faf78c7bf7415b950", texture);
                        OrigamiManager.instance.origamiTextureHashSecondary[1] = textureHash;
                        DesignData.BottomRightTexSecondary = textureIndex;
                    }
                    break;
                case "Bottom Left":
                    if (colourDropdown.options[colourDropdown.value].text == "Primary")
                    {
                        OrigamiManager.instance.LoadTexData(origami, 0, texture, "Texture2D_b614431639584fc99463f96af57246a8");
                        //origami.transform.GetChild(0).GetComponent<Renderer>().material.SetTexture("Texture2D_b614431639584fc99463f96af57246a8", texture);
                        OrigamiManager.instance.origamiTextureHashPrimary[0] = textureHash;
                        DesignData.BottomLeftTexPrimary = textureIndex;
                    }
                    else
                    {
                        OrigamiManager.instance.LoadTexData(origami, 0, texture, "Texture2D_62f72c9e26a6475faf78c7bf7415b950");
                        //origami.transform.GetChild(0).GetComponent<Renderer>().material.SetTexture("Texture2D_62f72c9e26a6475faf78c7bf7415b950", texture);
                        OrigamiManager.instance.origamiTextureHashSecondary[0] = textureHash;
                        DesignData.BottomLeftTexSecondary = textureIndex;
                    }
                    break;
            }
        }

        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Main")
            ChangeLastOrigami();
    }

    public static void ChangeLastOrigami()
    {
        Texture[] secondaryTextures = new Texture[4];

        secondaryTextures[0] = OrigamiManager.instance.orgami[0].transform.GetChild(0).GetComponent<Renderer>().material.GetTexture("Texture2D_62f72c9e26a6475faf78c7bf7415b950"); // Bottom Left
        secondaryTextures[1] = OrigamiManager.instance.orgami[0].transform.GetChild(1).GetComponent<Renderer>().material.GetTexture("Texture2D_62f72c9e26a6475faf78c7bf7415b950"); // Bottom Right.
        secondaryTextures[2] = OrigamiManager.instance.orgami[0].transform.GetChild(2).GetComponent<Renderer>().material.GetTexture("Texture2D_62f72c9e26a6475faf78c7bf7415b950"); // Top Left
        secondaryTextures[3] = OrigamiManager.instance.orgami[0].transform.GetChild(3).GetComponent<Renderer>().material.GetTexture("Texture2D_62f72c9e26a6475faf78c7bf7415b950"); // Top Right

        int last = OrigamiManager.instance.orgami.Length - 1;

        OrigamiManager.instance.orgami[last].transform.GetChild(0).GetComponent<Renderer>().material.SetTexture("Texture2D_62f72c9e26a6475faf78c7bf7415b950", secondaryTextures[0]); // Bottom Right 2
        OrigamiManager.instance.orgami[last].transform.GetChild(0).GetComponent<Renderer>().material.SetTexture("Texture2D_b614431639584fc99463f96af57246a8", secondaryTextures[1]); // Bottom Left 1

        OrigamiManager.instance.orgami[last].transform.GetChild(1).GetComponent<Renderer>().material.SetTexture("Texture2D_62f72c9e26a6475faf78c7bf7415b950", secondaryTextures[2]); // Left Top 2 Correct 
        OrigamiManager.instance.orgami[last].transform.GetChild(1).GetComponent<Renderer>().material.SetTexture("Texture2D_b614431639584fc99463f96af57246a8", secondaryTextures[0]); // Left Bottom 1 Correct

        OrigamiManager.instance.orgami[last].transform.GetChild(2).GetComponent<Renderer>().material.SetTexture("Texture2D_62f72c9e26a6475faf78c7bf7415b950", secondaryTextures[1]); // Right Bottom 2 Correct
        OrigamiManager.instance.orgami[last].transform.GetChild(2).GetComponent<Renderer>().material.SetTexture("Texture2D_b614431639584fc99463f96af57246a8", secondaryTextures[3]); // Right Top 1 Correct

        OrigamiManager.instance.orgami[last].transform.GetChild(3).GetComponent<Renderer>().material.SetTexture("Texture2D_62f72c9e26a6475faf78c7bf7415b950", secondaryTextures[3]); // Top Left 2
        OrigamiManager.instance.orgami[last].transform.GetChild(3).GetComponent<Renderer>().material.SetTexture("Texture2D_b614431639584fc99463f96af57246a8", secondaryTextures[2]); // Top Right 1
    }

    public void Border()
    {
        transform.GetChild(0).GetComponent<Image>().enabled = false;

        switch (segmentDropdown.options[segmentDropdown.value].text)
        {
            case "Top Right":
                if (colourDropdown.options[colourDropdown.value].text == "Primary")
                {
                    if(OrigamiManager.instance.origamiTextureHashPrimary[3] == textureHash)
                    {
                        transform.GetChild(0).GetComponent<Image>().enabled = true;
                    }
                }
                else
                {
                    if (OrigamiManager.instance.origamiTextureHashSecondary[3] == textureHash)
                    {
                        transform.GetChild(0).GetComponent<Image>().enabled = true;
                    }
                }
                break;
            case "Top Left":
                if (colourDropdown.options[colourDropdown.value].text == "Primary")
                {
                    if (OrigamiManager.instance.origamiTextureHashPrimary[2] == textureHash)
                    {
                        transform.GetChild(0).GetComponent<Image>().enabled = true;
                    }
                }
                else
                {
                    if (OrigamiManager.instance.origamiTextureHashSecondary[2] == textureHash)
                    {
                        transform.GetChild(0).GetComponent<Image>().enabled = true;
                    }
                }
                break;
            case "Bottom Right":
                if (colourDropdown.options[colourDropdown.value].text == "Primary")
                {
                    if (OrigamiManager.instance.origamiTextureHashPrimary[1] == textureHash)
                    {
                        transform.GetChild(0).GetComponent<Image>().enabled = true;
                    }
                }
                else
                {
                    if (OrigamiManager.instance.origamiTextureHashSecondary[1] == textureHash)
                    {
                        transform.GetChild(0).GetComponent<Image>().enabled = true;
                    }
                }
                break;
            case "Bottom Left":
                if (colourDropdown.options[colourDropdown.value].text == "Primary")
                {
                    if (OrigamiManager.instance.origamiTextureHashPrimary[0] == textureHash)
                    {
                        transform.GetChild(0).GetComponent<Image>().enabled = true;
                    }
                }
                else
                {
                    if (OrigamiManager.instance.origamiTextureHashSecondary[0] == textureHash)
                    {
                        transform.GetChild(0).GetComponent<Image>().enabled = true;
                    }
                }
                break;
        }
    }

    private void OnEnable()
    {
        Border();
    }
}
