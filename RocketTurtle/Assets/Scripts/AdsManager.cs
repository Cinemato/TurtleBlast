﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdsManager : MonoBehaviour
{
    [SerializeField] GameObject noAds;

    public static AdsManager instance;

    private string appID = "ca-app-pub-2241590936123058~5678988540";

    private RewardBasedVideoAd rewardedAd;
    private string rewardedAdID = "ca-app-pub-2241590936123058/1890296089";

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        MobileAds.Initialize(appID);

        rewardedAd = RewardBasedVideoAd.Instance;
        RequestRewardedAd();

        rewardedAd.OnAdLoaded += HandleRewardBasedVideoLoaded;

        rewardedAd.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;

        rewardedAd.OnAdRewarded += HandleRewardBasedVideoRewarded;

        rewardedAd.OnAdClosed += HandleRewardBasedVideoClosed;
    }

    public void RequestRewardedAd()
    {
        AdRequest request = new AdRequest.Builder().Build();

        rewardedAd.LoadAd(request, rewardedAdID);
    }

    public void ShowRewardedAd()
    {
        if (rewardedAd.IsLoaded())
            rewardedAd.Show();
        else if(!noAds.activeInHierarchy)
        {
            Debug.Log("Rewarded Ad Not Loaded");
            noAds.SetActive(true);
            StartCoroutine(removeText());
        }        
    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        Debug.Log("Rewarded Video ad loaded successfully");

    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("Failed to load rewarded video ad : " + args.Message);


    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        Debug.Log("You have been rewarded with  " + amount.ToString() + " " + type);
        PlayerStats.instance.respawn();
    }


    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        Debug.Log("Rewarded video has closed");
        RequestRewardedAd();
    }

    IEnumerator removeText()
    {
        yield return new WaitForSeconds(3f);
        noAds.SetActive(false);
    }
}
