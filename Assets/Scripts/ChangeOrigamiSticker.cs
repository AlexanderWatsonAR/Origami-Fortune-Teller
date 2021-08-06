using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class ChangeOrigamiSticker : MonoBehaviour
{
    public AssetReferenceSprite spriteRef;
    public AssetReferenceT<Material> stickerMatRef;
    public GameObject SegmentDropdown;
    public GameObject ColourDropdown;
    public GameObject ScrollView;
    public int stickerHash;
    public bool isBorderActive;

    private TMP_Dropdown segmentDropdown;
    private TMP_Dropdown colourDropdown;
    private SelectStickerPostion stickerPos;
    private float stickerIndex;

    void Awake()
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform.parent.GetChild(i).name == name)
                stickerIndex = i;
        }

        isBorderActive = false;
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

        stickerPos = FindObjectOfType<SelectStickerPostion>();

        if (spriteRef == null)
            return;

        ScrollView.GetComponent<ScrollRect>().onValueChanged.AddListener(delegate
        {
            IsThisVisible();
        });
    }

    private void DropdownValueChanged(TMP_Dropdown change)
    {
        Border();
        ChangePositionText();
    }

    public void ChangeSticker()
    {
        for (int i = 0; i < OrigamiManager.instance.orgami.Length; i++)
        {
            GameObject origami = OrigamiManager.instance.orgami[i];

            switch (segmentDropdown.options[segmentDropdown.value].text)
            {
                case "Top Right":
                    OrigamiManager.instance.LoadMaterialData(origami, 14, stickerMatRef);
                    OrigamiManager.instance.LoadMaterialData(origami, 15, stickerMatRef);
                    CheckPosition(origami.transform.GetChild(14).gameObject, origami.transform.GetChild(15).gameObject);
                    OrigamiManager.instance.origamiStickerHash[0] = stickerHash;
                    DesignData.TopRightStickerTex = stickerIndex;
                    DesignData.TopRightStickerTexPos = CheckPosition();
                    break;
                case "Top Left":
                    OrigamiManager.instance.LoadMaterialData(origami, 12, stickerMatRef);
                    OrigamiManager.instance.LoadMaterialData(origami, 13, stickerMatRef);
                    CheckPosition(origami.transform.GetChild(12).gameObject, origami.transform.GetChild(13).gameObject);
                    OrigamiManager.instance.origamiStickerHash[1] = stickerHash;
                    DesignData.TopLeftStickerTex = stickerIndex;
                    DesignData.TopLeftStickerTexPos = CheckPosition();
                    break;
                case "Bottom Right":
                    OrigamiManager.instance.LoadMaterialData(origami, 16, stickerMatRef);
                    OrigamiManager.instance.LoadMaterialData(origami, 17, stickerMatRef);
                    CheckPosition(origami.transform.GetChild(16).gameObject, origami.transform.GetChild(17).gameObject);
                    OrigamiManager.instance.origamiStickerHash[2] = stickerHash;
                    DesignData.BottomRightStickerTex = stickerIndex;
                    DesignData.BottomRightStickerTexPos = CheckPosition();
                    break;
                case "Bottom Left":
                    OrigamiManager.instance.LoadMaterialData(origami, 18, stickerMatRef);
                    OrigamiManager.instance.LoadMaterialData(origami, 19, stickerMatRef);
                    CheckPosition(origami.transform.GetChild(18).gameObject, origami.transform.GetChild(19).gameObject);
                    DesignData.BottomLeftStickerTex = stickerIndex;
                    OrigamiManager.instance.origamiStickerHash[3] = stickerHash;
                    DesignData.BottomLeftStickerTexPos = CheckPosition();
                    break;
            }
        }
    }

    public void ChangePositionText()
    {
        GameObject origami = OrigamiManager.instance.orgami[0];

        switch (segmentDropdown.options[segmentDropdown.value].text)
        {
            case "Top Right":
                stickerPos.ChangeText(GetActivePositionText(origami.transform.GetChild(14).gameObject, origami.transform.GetChild(15).gameObject));
                break;
            case "Top Left":
                stickerPos.ChangeText(GetActivePositionText(origami.transform.GetChild(12).gameObject, origami.transform.GetChild(13).gameObject));
                break;
            case "Bottom Right":
                stickerPos.ChangeText(GetActivePositionText(origami.transform.GetChild(16).gameObject, origami.transform.GetChild(17).gameObject));
                break;
            case "Bottom Left":
                stickerPos.ChangeText(GetActivePositionText(origami.transform.GetChild(18).gameObject, origami.transform.GetChild(19).gameObject));
                break;
        }
    }

    public int CheckPosition()
    {
        switch (stickerPos.ReturnPosition())
        {
            case "Empty":
                return 0;
            case "Position 1":
                return 1;
            case "Position 2":
                return 2;
            case "Both":
                return 3;
        }
        return 0;
    }

    public void CheckPosition(GameObject first, GameObject second)
    {
        switch(stickerPos.ReturnPosition())
        {
            case "Empty":
                first.SetActive(false);
                second.SetActive(false);
                break;
            case "Position 1":
                first.SetActive(true);
                second.SetActive(false);
                break;
            case "Position 2":
                first.SetActive(false);
                second.SetActive(true);
                break;
            case "Both":
                first.SetActive(true);
                second.SetActive(true);
                break;
        }
    }

    public static void CheckPosition(GameObject first, GameObject second, int pos)
    {
        switch (pos)
        {
            case 0:
                first.SetActive(false);
                second.SetActive(false);
                break;
            case 1:
                first.SetActive(true);
                second.SetActive(false);
                break;
            case 2:
                first.SetActive(false);
                second.SetActive(true);
                break;
            case 3:
                first.SetActive(true);
                second.SetActive(true);
                break;
        }
    }

    public int GetActivePositionText(GameObject first, GameObject second)
    {
        if (first.activeSelf == false && second.activeSelf == false)
            return 0;
        else if (first.activeSelf == true && second.activeSelf == false)
            return 1;
        else if (first.activeSelf == false && second.activeSelf == true)
            return 2;
        else
            return 3;
    }

    public void Border()
    {
        // First, Disable Border.
        transform.GetChild(transform.childCount - 1).GetComponent<Image>().enabled = false;
        isBorderActive = false;

        switch (segmentDropdown.options[segmentDropdown.value].text)
        {
            case "Top Right":
                if (OrigamiManager.instance.origamiStickerHash[0] == stickerHash)
                {
                    transform.GetChild(transform.childCount - 1).GetComponent<Image>().enabled = true;
                    isBorderActive = true;
                }
                break;
            case "Top Left":
                if (OrigamiManager.instance.origamiStickerHash[1] == stickerHash)
                {
                    transform.GetChild(transform.childCount - 1).GetComponent<Image>().enabled = true;
                    isBorderActive = true;
                }
                break;
            case "Bottom Right":
                if (OrigamiManager.instance.origamiStickerHash[2] == stickerHash)
                {
                    transform.GetChild(transform.childCount - 1).GetComponent<Image>().enabled = true;
                    isBorderActive = true;
                }
                break;
            case "Bottom Left":
                if (OrigamiManager.instance.origamiStickerHash[3] == stickerHash)
                {
                    transform.GetChild(transform.childCount - 1).GetComponent<Image>().enabled = true;
                    isBorderActive = true;
                }
                break;
        }
    }
    private void OnEnable()
    {
        Border();
    }

    public void IsThisVisible()
    {
        if (GetComponent<Image>().sprite != null || spriteRef == null)
        {
            RemoveListener();
            return;
        }
            
        Image tempImage = GetComponent<Image>();
        bool isVisible = RectTransformUtility.RectangleContainsScreenPoint(ScrollView.GetComponent<RectTransform>(), new Vector2(transform.position.x, transform.position.y));

        if (isVisible)
        {
            OrigamiManager.instance.GetSpriteFromRef(spriteRef, tempImage);
            RemoveListener();
        }
    }

    private void RemoveListener()
    {
        ScrollView.GetComponent<ScrollRect>().onValueChanged.RemoveListener(delegate
        {
            IsThisVisible();
        });
    }
}
