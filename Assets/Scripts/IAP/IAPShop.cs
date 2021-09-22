using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class IAPShop : MonoBehaviour
{
    [SerializeField]
    private const string kawaiiStickerCollection1 = "com.onlyinvalid.origamidecisionmaker.kawaiicollectionone";

    [SerializeField]
    private const string removeAds = "com.onlyinvalid.origamidecisionmaker.removeads";

    public GameObject KawaiiCollection1StickerPicker;
    public GameObject KawaiiCollection1PurchaseButton;
    public GameObject removeAdsButton;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("KawaiiCollection1Purchased") == 1)
        {
            Unlock();
        }

        if (PlayerPrefs.GetInt("RemoveAdsPurchased") == 1)
        {
            RemoveAds();
        }
    }

    public void OnPurchaseComplete(Product product)
    {
        switch (product.definition.id)
        {
            case kawaiiStickerCollection1:
                Debug.Log("Purchase of " + product.definition.id + " has been successful");
                {
                    Unlock();
                    PlayerPrefs.SetInt("KawaiiCollection1Purchased", 1);
                }
                break;
            case removeAds:
                PlayerPrefs.SetInt("RemoveAdsPurchased", 1);
                RemoveAds();
                break;
        }
    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase of " + product.definition.id + " has failed");
    }

    private void Unlock()
    {
        for (int i = 0; i < KawaiiCollection1StickerPicker.transform.childCount; i++)
        {
            KawaiiCollection1StickerPicker.transform.GetChild(i).transform.GetChild(1).gameObject.SetActive(false);
        }

        for (int i = 0; i < KawaiiCollection1PurchaseButton.transform.childCount; i++)
        {
            if (KawaiiCollection1PurchaseButton.transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>() != null)
            {
                KawaiiCollection1PurchaseButton.transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().text = "Purchased";
            }
        }
        KawaiiCollection1PurchaseButton.GetComponent<Button>().interactable = false;
    }

    private void RemoveAds()
    {
        AdsManager.instance.RemoveAds();
        if (removeAdsButton != null)
        {
            removeAdsButton.GetComponent<Button>().interactable = false;
            removeAdsButton.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = null;
            removeAdsButton.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.gray;
            removeAdsButton.transform.GetChild(1).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.gray;
        }
    }
}
