using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleMobileAds.Api;

public class CAdsManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RequestBanner ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void RequestBanner()
	{
		string strAdsID;

		#if UNITY_ANDROID
		strAdsID = "ca-app-pub-4926797886000556/9832993624";
		#elif UNITY_IPHONE
		strAdsID = "ca-app-pub-4926797886000556/9832993624";
		#endif

		BannerView bannerView = new BannerView (strAdsID, AdSize.Banner, AdPosition.Bottom);

		AdRequest request = new AdRequest.Builder ().Build ();

		bannerView.LoadAd (request);
	}
}
