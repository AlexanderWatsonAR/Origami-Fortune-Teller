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
    private int interstitialAdCount;

    public static AdsManager instance;
    public InterstitialAd interAd;
    public BannerAd bannerAd;
    public bool isInitialised;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            instance.interAd = interAd;
            instance.bannerAd = bannerAd;
            int adCount = PlayerPrefs.GetInt("interstitialAdCount");
            adCount++;
            PlayerPrefs.SetInt("interstitialAdCount", adCount);
            interstitialAdCount = adCount;
            StartCoroutine(ShowAds());
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
        isInitialised = true;
        instance.isInitialised = true;
    }

    public IEnumerator ShowAds()
    {
        while(instance.isInitialised != true)
        {
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }

        StartCoroutine(bannerAd.ShowBanner());
        StartCoroutine(bannerAd.CloseBannerAd(246.0f));

        if (interstitialAdCount % 6 == 0)
        {
            interAd.LoadAd();
        }

        yield return null; 
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error} - {message}");
        isInitialised = false;
    }

    public void RemoveAds()
    {
        if(bannerAd != null)
            bannerAd.HideBannerAd();
    }

    public void PlayInterstialAd()
    {
        if (PlayerPrefs.GetInt("RemoveAdsPurchased") == 1)
            return;

        int adCount = PlayerPrefs.GetInt("interstitialAdCount");
        adCount++;
        PlayerPrefs.SetInt("interstitialAdCount", adCount);
        interstitialAdCount = adCount;

        if (adCount % 6 == 0)
        {
            instance.interAd.LoadAd();
            instance.interAd.ShowAd();
        }
    }
}
