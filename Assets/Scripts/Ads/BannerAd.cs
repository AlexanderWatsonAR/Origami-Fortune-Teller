using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using DG.Tweening;

public class BannerAd : MonoBehaviour
{
    // For the purpose of this example, these buttons are for functionality testing:
    //[SerializeField] Button loadBannerButton;
    //[SerializeField] Button showBannerButton;
    //[SerializeField] Button hideBannerButton;

    [SerializeField] BannerPosition bannerPosition = BannerPosition.CENTER;

    [SerializeField] string androidAdUnitId = "Banner_Android";
    [SerializeField] string appleAdUnitId = "Banner_iOS";
    string _adUnitId;

    void Start()
    {
        if (PlayerPrefs.GetInt("RemoveAdsPurchased") == 1)
            return;

        // Set the banner position:
        Advertisement.Banner.SetPosition(bannerPosition);
        StartCoroutine(ShowBanner());
        StartCoroutine(CloseBannerAd(246.0f));

        float myvalue = 0;

        
    }

    private IEnumerator ShowBanner()
    {
        // Delay so AdsInitializer can finish awake routine.
        yield return new WaitForSeconds(1);
        LoadBanner();
        yield return new WaitForSeconds(5);
        ShowBannerAd();
    }

    private IEnumerator CloseBannerAd(float timeInSeconds)
    {
        yield return new WaitForSeconds(timeInSeconds);
        HideBannerAd();
    }

    // Implement a method to call when the Load Banner button is clicked:
    public void LoadBanner()
    {
        // Set up options to notify the SDK of load events:
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        // Load the Ad Unit with banner content:
        Advertisement.Banner.Load(_adUnitId, options);
    }

    // Implement code to execute when the loadCallback event triggers:
    void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");
        ShowBannerAd();
    }

    // Implement code to execute when the load errorCallback event triggers:
    void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
    }

    // Implement a method to call when the Show Banner button is clicked:
    void ShowBannerAd()
    {
        // Set up options to notify the SDK of show events:
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };

        // Show the loaded Banner Ad Unit:
        Advertisement.Banner.Show(_adUnitId, options);
    }

    // Implement a method to call when the Hide Banner button is clicked:
    public void HideBannerAd()
    {
        // Hide the banner:
        Advertisement.Banner.Hide();
    }

    void OnBannerClicked() { }
    void OnBannerShown() { }
    void OnBannerHidden() { }

    void OnDestroy()   {}
}
