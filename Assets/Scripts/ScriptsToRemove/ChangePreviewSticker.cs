using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class ChangePreviewSticker : MonoBehaviour
{
    public GameObject preview;
    public AssetReferenceSprite spriteRef;
    public AssetReferenceT<Material> stickerMatRef;
    public GameObject ScrollView;

    public void Start()
    {
        if (spriteRef == null)
            return;

        ScrollView.GetComponent<ScrollRect>().onValueChanged.AddListener(delegate
        {
            IsThisVisible();
        });
    }

    public void ChangeSticker()
    {
        DataLoading.LoadMaterialData(preview, stickerMatRef,null);
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
            DataLoading.GetSpriteFromRef(spriteRef, tempImage);
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
