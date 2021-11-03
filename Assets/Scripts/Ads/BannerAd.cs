using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class BannerAd : MonoBehaviour
{
    [SerializeField] BannerPosition bannerPosition = BannerPosition.BOTTOM_CENTER;

    [SerializeField] string androidAdUnitId = "Banner_Android";
    [SerializeField] string appleAdUnitId = "Banner_iOS";
    string _adUnitId;

    public static bool isBannerShowing;

    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? appleAdUnitId
            : androidAdUnitId;

        Advertisement.Banner.SetPosition(bannerPosition);
        //if (PlayerPrefs.GetInt("RemoveAdsPurchased") == 1)
        //    return;
    }

    public IEnumerator ShowBanner()
    {
        // Delay so AdsInitializer can finish awake routine.
        yield return new WaitForSeconds(1.0f);
        LoadBanner();
    }

    public IEnumerator CloseBannerAd(float timeInSeconds)
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
        if (isBannerShowing == false)
        {
            Debug.Log("Banner loaded" + "Method: OnBannerLoaded()");
            
            ShowBannerAd();
        }
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
        SceneManager.activeSceneChanged += HideBannerActiveSceneChanged;
        isBannerShowing = true;
    }

    private void HideBannerActiveSceneChanged(Scene current, Scene next)
    {
        HideBannerAd();
        SceneManager.activeSceneChanged -= HideBannerActiveSceneChanged;
    }

    // Implement a method to call when the Hide Banner button is clicked:
    public void HideBannerAd()
    {
        if (isBannerShowing == false)
            return;

        // Hide the banner:
        Advertisement.Banner.Hide();
        isBannerShowing = false;
    }

    void OnBannerClicked() 
    {
        HideBannerAd();
    }
    void OnBannerShown() { }
    void OnBannerHidden() { }
}
