using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class ChangeOrigamiTexture : Change
{
    public GameObject primaryTextures;
    public GameObject secondaryTextures;

    public AssetReferenceSprite spriteRef;
    public AssetReferenceTexture texture;
    public int textureHash;
    private float textureIndex;

    void Awake()
    {
        for(int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform.parent.GetChild(i).name == name)
                textureIndex = i;
        }

        Image tempImage = GetComponent<Image>();
        DataLoading.GetSpriteFromRef(spriteRef, tempImage);
        Border();
    }

    public override void ChangeState()
    {
        ChangeTexture();
    }

    public void ChangeTexture()
    {
        foreach (GameObject origami in OrigamiManager.instance.orgami)
        {
            switch (pickerIndex)
            {
                case 0:
                    DataLoading.LoadTexData(origami, 2, texture, "Texture2D_b614431639584fc99463f96af57246a8");
                    OrigamiManager.instance.origamiTextureHashPrimary[2] = textureHash;
                    DesignData.TopLeftTexPrimary = textureIndex;
                    break;
                case 1:
                    DataLoading.LoadTexData(origami, 3, texture, "Texture2D_b614431639584fc99463f96af57246a8");
                    OrigamiManager.instance.origamiTextureHashPrimary[3] = textureHash;
                    DesignData.TopRightTexPrimary = textureIndex;
                    break;
                case 2:
                    DataLoading.LoadTexData(origami, 0, texture, "Texture2D_b614431639584fc99463f96af57246a8");
                    OrigamiManager.instance.origamiTextureHashPrimary[0] = textureHash;
                    DesignData.BottomLeftTexPrimary = textureIndex;
                    break;
                case 3:
                    DataLoading.LoadTexData(origami, 1, texture, "Texture2D_b614431639584fc99463f96af57246a8");
                    OrigamiManager.instance.origamiTextureHashPrimary[1] = textureHash;
                    DesignData.BottomRightTexPrimary = textureIndex;
                    break;
                case 4:
                    DataLoading.LoadTexData(origami, 2, texture, "Texture2D_62f72c9e26a6475faf78c7bf7415b950");
                    OrigamiManager.instance.origamiTextureHashSecondary[2] = textureHash;
                    DesignData.TopLeftTexSecondary = textureIndex;
                    break;
                case 5:
                    DataLoading.LoadTexData(origami, 3, texture, "Texture2D_62f72c9e26a6475faf78c7bf7415b950");
                    OrigamiManager.instance.origamiTextureHashSecondary[3] = textureHash;
                    DesignData.TopRightTexSecondary = textureIndex;
                    break;
                case 6:
                    DataLoading.LoadTexData(origami, 0, texture, "Texture2D_62f72c9e26a6475faf78c7bf7415b950");
                    OrigamiManager.instance.origamiTextureHashSecondary[0] = textureHash;
                    DesignData.BottomLeftTexSecondary = textureIndex;
                    break;
                case 7:
                    DataLoading.LoadTexData(origami, 1, texture, "Texture2D_62f72c9e26a6475faf78c7bf7415b950");
                    OrigamiManager.instance.origamiTextureHashSecondary[1] = textureHash;
                    DesignData.BottomRightTexSecondary = textureIndex;
                    break;
            }

            if (pickerIndex > -1 && pickerIndex < 4)
            {
                Image tempImage = primaryTextures.transform.GetChild(pickerIndex + 1).gameObject.GetComponent<Image>();
                DataLoading.GetSpriteFromRef(spriteRef, tempImage);
            }
            else
            {
                Image tempImage = secondaryTextures.transform.GetChild(pickerIndex - 3).gameObject.GetComponent<Image>();
                DataLoading.GetSpriteFromRef(spriteRef, tempImage);
            }
        }
    }

    public static void ChangeLastOrigami()
    {
        Texture[] secondaryTextures = new Texture[4];

        secondaryTextures[0] = OrigamiManager.instance.orgami[0].transform.GetChild(0).GetComponent<Renderer>().material.GetTexture("Texture2D_62f72c9e26a6475faf78c7bf7415b950"); // Bottom Left
        secondaryTextures[1] = OrigamiManager.instance.orgami[0].transform.GetChild(1).GetComponent<Renderer>().material.GetTexture("Texture2D_62f72c9e26a6475faf78c7bf7415b950"); // Bottom Right.
        secondaryTextures[2] = OrigamiManager.instance.orgami[0].transform.GetChild(2).GetComponent<Renderer>().material.GetTexture("Texture2D_62f72c9e26a6475faf78c7bf7415b950"); // Top Left
        secondaryTextures[3] = OrigamiManager.instance.orgami[0].transform.GetChild(3).GetComponent<Renderer>().material.GetTexture("Texture2D_62f72c9e26a6475faf78c7bf7415b950"); // Top Right

        if (secondaryTextures[0] == null)
            return;

        int last = OrigamiManager.instance.orgami.Length - 1;

        OrigamiManager.instance.orgami[last].transform.GetChild(0).GetComponent<Renderer>().material.SetTexture("Texture2D_62f72c9e26a6475faf78c7bf7415b950", secondaryTextures[0]); // Bottom Right 2 - P
        OrigamiManager.instance.orgami[last].transform.GetChild(0).GetComponent<Renderer>().material.SetTexture("Texture2D_b614431639584fc99463f96af57246a8", secondaryTextures[1]); // Bottom Left 1  - S

        OrigamiManager.instance.orgami[last].transform.GetChild(1).GetComponent<Renderer>().material.SetTexture("Texture2D_62f72c9e26a6475faf78c7bf7415b950", secondaryTextures[2]); // Left Top 2 Correct 
        OrigamiManager.instance.orgami[last].transform.GetChild(1).GetComponent<Renderer>().material.SetTexture("Texture2D_b614431639584fc99463f96af57246a8", secondaryTextures[0]); // Left Bottom 1 Correct

        OrigamiManager.instance.orgami[last].transform.GetChild(2).GetComponent<Renderer>().material.SetTexture("Texture2D_62f72c9e26a6475faf78c7bf7415b950", secondaryTextures[1]); // Right Bottom 2 Correct
        OrigamiManager.instance.orgami[last].transform.GetChild(2).GetComponent<Renderer>().material.SetTexture("Texture2D_b614431639584fc99463f96af57246a8", secondaryTextures[3]); // Right Top 1 Correct

        OrigamiManager.instance.orgami[last].transform.GetChild(3).GetComponent<Renderer>().material.SetTexture("Texture2D_62f72c9e26a6475faf78c7bf7415b950", secondaryTextures[3]); // Top Left 2
        OrigamiManager.instance.orgami[last].transform.GetChild(3).GetComponent<Renderer>().material.SetTexture("Texture2D_b614431639584fc99463f96af57246a8", secondaryTextures[2]); // Top Right 1
    }

    public override void Border()
    {
        transform.GetChild(0).GetComponent<Image>().enabled = false;

        switch (pickerIndex)
        {
            case 0:
                if (OrigamiManager.instance.origamiTextureHashPrimary[2] == textureHash)
                {
                    transform.GetChild(0).GetComponent<Image>().enabled = true;
                }
                break;
            case 1:
                if (OrigamiManager.instance.origamiTextureHashPrimary[3] == textureHash)
                {
                    transform.GetChild(0).GetComponent<Image>().enabled = true;
                }
                break;
            case 2:
                if (OrigamiManager.instance.origamiTextureHashPrimary[0] == textureHash)
                {
                    transform.GetChild(0).GetComponent<Image>().enabled = true;
                }
                
                break;
            case 3:
                if (OrigamiManager.instance.origamiTextureHashPrimary[1] == textureHash)
                {
                    transform.GetChild(0).GetComponent<Image>().enabled = true;
                }
                break;
            case 4:
                if (OrigamiManager.instance.origamiTextureHashSecondary[2] == textureHash)
                {
                    transform.GetChild(0).GetComponent<Image>().enabled = true;
                }
                break;
            case 5:
                if (OrigamiManager.instance.origamiTextureHashSecondary[3] == textureHash)
                {
                    transform.GetChild(0).GetComponent<Image>().enabled = true;
                }
                break;
            case 6:
                if (OrigamiManager.instance.origamiTextureHashSecondary[0] == textureHash)
                {
                    transform.GetChild(0).GetComponent<Image>().enabled = true;
                }
                break;
            case 7:
                if (OrigamiManager.instance.origamiTextureHashSecondary[1] == textureHash)
                {
                    transform.GetChild(0).GetComponent<Image>().enabled = true;
                }
                break;
        }
    }
}
