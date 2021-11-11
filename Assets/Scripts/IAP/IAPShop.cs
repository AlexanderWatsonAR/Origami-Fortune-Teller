using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;
//using UnityEngine.UDP;

public class ShopCatalog 
{
    private ProductCatalog catalog;

    public ShopCatalog()
    {
        catalog = ProductCatalog.LoadDefaultCatalog();

        StandardPurchasingModule module = StandardPurchasingModule.Instance();

        ConfigurationBuilder builder = ConfigurationBuilder.Instance(module);

        foreach (ProductCatalogItem product in catalog.allProducts)
        {
            if (product.allStoreIDs.Count > 0)
            {
                var ids = new IDs();
                foreach (var storeID in product.allStoreIDs)
                {
                    ids.Add(storeID.id, storeID.store);
                }
                builder.AddProduct(product.id, product.type, ids);
            }
            else
            {
                builder.AddProduct(product.id, product.type);
            }
        }
    }

    // Check to See if item exists in Catalog
    public bool IsProductInCatalog(string productID)
    {
        foreach (ProductCatalogItem product in catalog.allProducts)
        {
            if (product.id == productID)
            {
                return true;
            }
        }
        return false;
    }
}


public class IAPShop : MonoBehaviour
{
    [SerializeField]
    private const string kawaiiStickerCollection1 = "com.onlyinvalid.origami.kawaiicollectionone";

    [SerializeField]
    private const string halloween2021Collection = "com.onlyinvalid.origami.halloween2021";

    [SerializeField]
    private const string removeAds = "com.onlyinvalid.origami.removeads";

    public GameObject KawaiiCollection1StickerPicker;
    public GameObject KawaiiCollection1PurchaseButton;
    public GameObject halloween2021CollectionStickerPicker;
    public GameObject halloween2021PurchaseButton;
    public GameObject removeAdsButton;


    private void Start()
    {
        //if (UDPListener.instance != null)
        //{
        //    IInitListener listener = new UDPListener();
        //    StoreService.Initialize(listener);
        //}

        TextMeshProUGUI kawaiiPriceText = KawaiiCollection1PurchaseButton.GetComponent<IAPButton>().priceText.transform.parent.gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI halloweenText = halloween2021PurchaseButton.GetComponent<IAPButton>().priceText.transform.parent.gameObject.GetComponent<TextMeshProUGUI>();

        kawaiiPriceText.text = KawaiiCollection1PurchaseButton.GetComponent<IAPButton>().priceText.text;
        halloweenText.text = halloween2021PurchaseButton.GetComponent<IAPButton>().priceText.text;

        kawaiiPriceText.text = kawaiiPriceText.text == "" ? "$0.99" : kawaiiPriceText.text;
        halloweenText.text = halloweenText.text == "" ? "$0.99" : halloweenText.text;

        if (PlayerPrefs.GetInt("KawaiiCollection1Purchased") == 1)
        {
            Unlock(KawaiiCollection1StickerPicker, KawaiiCollection1PurchaseButton);
        }

        if (PlayerPrefs.GetInt("Halloween2021CollectionPurchased") == 1)
        {
            Unlock(halloween2021CollectionStickerPicker, halloween2021PurchaseButton);
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
                    Unlock(KawaiiCollection1StickerPicker, KawaiiCollection1PurchaseButton);
                    PlayerPrefs.SetInt("KawaiiCollection1Purchased", 1);
                }
                break;
            case halloween2021Collection:
                Debug.Log("Purchase of " + product.definition.id + " has been successful");
                {
                    Unlock(halloween2021CollectionStickerPicker, halloween2021PurchaseButton);
                    PlayerPrefs.SetInt("Halloween2021CollectionPurchased", 1);
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

        switch(product.definition.id)
        {
            case kawaiiStickerCollection1:
                if (product.hasReceipt == true)
                {
                    Unlock(KawaiiCollection1StickerPicker, KawaiiCollection1PurchaseButton);
                    PlayerPrefs.SetInt("KawaiiCollection1Purchased", 1);
                }
                break;
            case halloween2021Collection:
                if (product.hasReceipt == true)
                {
                    Unlock(halloween2021CollectionStickerPicker, halloween2021PurchaseButton);
                    PlayerPrefs.SetInt("Halloween2021CollectionPurchased", 1);
                }
                break;
            case removeAds:
                if (product.hasReceipt == true)
                {
                    PlayerPrefs.SetInt("RemoveAdsPurchased", 1);
                    RemoveAds();
                }
                break;
        }
    }

    private void Unlock(GameObject collection, GameObject purchaseButton)
    {
        for (int i = 0; i < collection.transform.childCount; i++)
        {
            collection.transform.GetChild(i).transform.GetChild(1).gameObject.SetActive(false);
        }

        for (int i = 0; i < purchaseButton.transform.childCount; i++)
        {
            if (purchaseButton.transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>() != null)
            {
                purchaseButton.transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().text = "Purchased";
            }
        }
        purchaseButton.GetComponent<Button>().interactable = false;
    }

    private void RemoveAds()
    {
        AdsManager.instance.RemoveAds();
        if (removeAdsButton != null)
        {
            removeAdsButton.GetComponent<Button>().interactable = false;
            removeAdsButton.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.gray;
            removeAdsButton.transform.GetChild(1).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.gray;
        }
    }
}
