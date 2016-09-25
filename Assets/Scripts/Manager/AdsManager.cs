using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class AdsManager : MonoBehaviour {

    public static AdsManager instance = null;

    private string gameID;
    private ShapeGlobalVars.RewardTypes currentReward;

    void Awake()
    {
        if (AdsManager.instance == null)
        {
            AdsManager.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }

        // **************************************** PLEASE DONT CHANGE **********************************
        //The following game ID's have been picked up from the Ads Manager admin from my account (Rishit) 
        // **************************************** PLEASE DONT CHANGE **********************************
#if UNITY_ANDROID
        gameID = "1144481";
#endif

#if UNITY_IOS
        gameID = "1144482";
#endif
        Advertisement.Initialize(gameID,false);
    }


    /// <summary>
    /// Shows a rewardedAd (That cannot be skipped)
    /// </summary>
    public void ShowRewardedAd(ShapeGlobalVars.RewardTypes rewardType)
    {
        currentReward = rewardType;

        //#if UNITY_EDITOR
        //    StartCoroutine(WaitForAd());
        //#endif

        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    /// <summary>
    /// Callback function fired after Ad is shown
    /// Also handles the state for the ad
    /// </summary>
    /// <param name="result">Result of the Ad shown</param>
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                // REWARD LOGIC
                switch (currentReward)
                {
                    case ShapeGlobalVars.RewardTypes.Hint:
                        HintsManager.instance.ShowLevelHint();
                        break;

                    default:
                        break;
                }
                //Resetting current reward to None
                currentReward = ShapeGlobalVars.RewardTypes.None;
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }

    IEnumerator WaitForAd()
    {
        float currentTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        yield return null;

        while (Advertisement.isShowing)
            yield return null;

        Time.timeScale = currentTimeScale;
    }
}
