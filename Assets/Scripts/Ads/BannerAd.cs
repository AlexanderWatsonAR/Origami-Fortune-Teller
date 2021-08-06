using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class BannerAd : MonoBehaviour
{
    // For the purpose of this example, these buttons are for functionality testing:
    [SerializeField] Button loadBannerButton;
    [SerializeField] Button showBannerButton;
    [SerializeField] Button hideBannerButton;

    [SerializeField] BannerPosition bannerPosition = BannerPosition.CENTER;

    [SerializeField] string androidAdUnitId = "Banner_Android";
    [SerializeField] string appleAdUnitId = "Banner_iOS";
    string _adUnitId;

    void Start()
    {
        // Disable the button until an ad is ready to show:
        showBannerButton.interactable = false;
        hideBannerButton.interactable = false;

        // Set the banner position:
        Advertisement.Banner.SetPosition(bannerPosition);

        // Configure the Load Banner button to call the LoadBanner() method when clicked:
        loadBannerButton.onClick.AddListener(LoadBanner);
        loadBannerButton.interactable = true;

        StartCoroutine(ShowBanner());
    }

    private IEnumerator ShowBanner()
    {
        yield return new WaitForSeconds(1);
        LoadBanner();
        yield return new WaitForSeconds(5);
        ShowBannerAd();
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

        // Configure the Show Banner button to call the ShowBannerAd() method when clicked:
        showBannerButton.onClick.AddListener(ShowBannerAd);
        // Configure the Hide Banner button to call the HideBannerAd() method when clicked:
        hideBannerButton.onClick.AddListener(HideBannerAd);

        // Enable both buttons:
        showBannerButton.interactable = true;
        hideBannerButton.interactable = true;
    }

    // Implement code to execute when the load errorCallback event triggers:
    void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
        // Optionally execute additional code, such as attempting to load another ad.
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
    void HideBannerAd()
    {
        // Hide the banner:
        Advertisement.Banner.Hide();
    }

    void OnBannerClicked() { }
    void OnBannerShown() { }
    void OnBannerHidden() { }

    void OnDestroy()
    {
        // Clean up the listeners:
        loadBannerButton.onClick.RemoveAllListeners();
        showBannerButton.onClick.RemoveAllListeners();
        hideBannerButton.onClick.RemoveAllListeners();
    }
}
