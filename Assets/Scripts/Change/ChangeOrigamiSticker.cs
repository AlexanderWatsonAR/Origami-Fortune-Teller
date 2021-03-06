using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class ChangeOrigamiSticker : Change
{
    public GameObject[] stickerButtons;
    public AssetReferenceSprite spriteRef;
    public AssetReferenceT<Material> stickerMatRef;
    public GameObject Preview;
    //public GameObject ScrollView;
    public int stickerHash;
    public bool isBorderActive;
    public bool doesSpriteStartInactive;

    private float stickerIndex;


    void Awake()
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform.parent.GetChild(i).name == name)
                stickerIndex = i;
        }

        isBorderActive = false;

        if (spriteRef == null)
            return;

        if(doesSpriteStartInactive == false)
            LoadSprite();
      

        //ScrollView.GetComponent<ScrollRect>().onValueChanged.AddListener(delegate
        //{
        //    IsThisVisible();
        //});
    }

    public void ChangePreviewSticker()
    {
        DataLoading.LoadMaterialData(Preview, stickerMatRef, null);
    }

    public void ChangeSticker()
    {
        for (int i = 0; i < OrigamiManager.instance.orgami.Length; i++)
        {
            GameObject origami = OrigamiManager.instance.orgami[i];

            switch (pickerIndex)
            {
                case 0:
                    DataLoading.LoadMaterialData(origami.transform.GetChild(12).gameObject, stickerMatRef, OrigamiManager.instance.CheckAllStickerBorders);
                    DataLoading.LoadMaterialData(origami.transform.GetChild(13).gameObject, stickerMatRef, OrigamiManager.instance.CheckAllStickerBorders);
                    OrigamiManager.instance.origamiStickerHash[0] = stickerHash;
                    DesignData.TopLeftStickerTex = stickerHash;
                    break;
                case 1:
                    DataLoading.LoadMaterialData(origami.transform.GetChild(14).gameObject, stickerMatRef, OrigamiManager.instance.CheckAllStickerBorders);
                    DataLoading.LoadMaterialData(origami.transform.GetChild(15).gameObject, stickerMatRef, OrigamiManager.instance.CheckAllStickerBorders);
                    OrigamiManager.instance.origamiStickerHash[1] = stickerHash;
                    DesignData.TopRightStickerTex = stickerHash;
                    break;
                case 2:
                    DataLoading.LoadMaterialData(origami.transform.GetChild(18).gameObject, stickerMatRef, OrigamiManager.instance.CheckAllStickerBorders);
                    DataLoading.LoadMaterialData(origami.transform.GetChild(19).gameObject, stickerMatRef, OrigamiManager.instance.CheckAllStickerBorders);
                    OrigamiManager.instance.origamiStickerHash[2] = stickerHash;
                    DesignData.BottomLeftStickerTex = stickerHash;
                    break;
                case 3:
                    DataLoading.LoadMaterialData(origami.transform.GetChild(16).gameObject, stickerMatRef, OrigamiManager.instance.CheckAllStickerBorders);
                    DataLoading.LoadMaterialData(origami.transform.GetChild(17).gameObject, stickerMatRef, OrigamiManager.instance.CheckAllStickerBorders);
                    OrigamiManager.instance.origamiStickerHash[3] = stickerHash;
                    DesignData.BottomRightStickerTex = stickerHash;
                    break;
            }
        }
        if(stickerButtons != null)
            DataLoading.GetSpriteFromRef(spriteRef, stickerButtons[pickerIndex].GetComponent<Image>());
    }

    public override void Border()
    {
        // First, Disable Border.
        transform.GetChild(transform.childCount - 2).GetComponent<Image>().enabled = false;
        isBorderActive = false;

        switch (pickerIndex)
        {
            case 0: // Top Left
                if (OrigamiManager.instance.origamiStickerHash[0] == stickerHash)
                {
                    // Enable border
                    transform.GetChild(transform.childCount - 2).GetComponent<Image>().enabled = true;
                    isBorderActive = true;                
                }
                break;
            case 1: // Top Right
                if (OrigamiManager.instance.origamiStickerHash[1] == stickerHash)
                {
                    transform.GetChild(transform.childCount - 2).GetComponent<Image>().enabled = true;
                    isBorderActive = true;
                }
                break;
            case 2: // Bottom Left
                if (OrigamiManager.instance.origamiStickerHash[2] == stickerHash)
                {
                    transform.GetChild(transform.childCount - 2).GetComponent<Image>().enabled = true;
                    isBorderActive = true;
                }
                break;
            case 3: // Bottom Right
                if (OrigamiManager.instance.origamiStickerHash[3] == stickerHash)
                {
                    transform.GetChild(transform.childCount - 2).GetComponent<Image>().enabled = true;
                    isBorderActive = true;
                }
                break;
        }
    }
    private void OnEnable()
    {
        if(stickerButtons.Length != 0)
            Border();
    }

    //public void IsThisVisible()
    //{
    //    if (GetComponent<Image>().sprite != null || spriteRef == null)
    //    {
    //        RemoveListener();
    //        return;
    //    }

    //    bool isVisible = RectTransformUtility.RectangleContainsScreenPoint(ScrollView.GetComponent<RectTransform>(), new Vector2(transform.position.x, transform.position.y));

    //    if (isVisible)
    //    {
    //        LoadSprite();
    //        RemoveListener();
    //    }
    //}

    public void LoadSprite()
    {
        Image tempImage = GetComponent<Image>();
        DataLoading.GetSpriteFromRef(spriteRef, tempImage);
    }

    //private void RemoveListener()
    //{
    //    ScrollView.GetComponent<ScrollRect>().onValueChanged.RemoveListener(delegate
    //    {
    //        IsThisVisible();
    //    });
    //}
}
