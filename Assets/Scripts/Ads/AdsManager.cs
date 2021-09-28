using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string androidGameId = "4238669";
    [SerializeField] string appleGameId = "4238668";
    [SerializeField] bool testMode = true;
    [SerializeField] bool enablePerPlacementMode = true;
    private string gameId;


    public static AdsManager instance;
    public InterstitialAd interAd;
    public BannerAd bannerAd;

    void Awake()
    {
        ///PlayerPrefs.SetInt("RemoveAdsPurchased", 0);
        if (instance == null)
        {
            instance = this;
            instance.interAd = interAd;
            instance.bannerAd = bannerAd;
            int adCount = PlayerPrefs.GetInt("interstitialAdCount");
            adCount++;
            PlayerPrefs.SetInt("interstitialAdCount", adCount);
        }
        else
        {
            return;
        }
        DontDestroyOnLoad(gameObject);

        if (PlayerPrefs.GetInt("RemoveAdsPurchased") == 1)
            return;

        InitializeAds();
    }

    public void InitializeAds()
    {
        // if the platform is ios then game id is apple game id. else gameid equals android id.
        gameId = (Application.platform == RuntimePlatform.IPhonePlayer) ? appleGameId: androidGameId;
        Advertisement.Initialize(gameId, testMode, enablePerPlacementMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        interAd.LoadAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error} - {message}");
    }

    public void RemoveAds()
    {
        bannerAd.HideBannerAd();
    }

    public void PlayInterstialAd()
    {
        int adCount = PlayerPrefs.GetInt("interstitialAdCount");
        adCount++;
        PlayerPrefs.SetInt("interstitialAdCount", adCount);

        if (adCount % 10 == 0)
        {
            instance.interAd.LoadAd();
            instance.interAd.ShowAd();
        }
    }
}
