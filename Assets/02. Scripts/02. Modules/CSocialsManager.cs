using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class CSocialsManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		InitSocialsManager ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void InitSocialsManager()
	{
		// Google Play Game ------------------------------------
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
			// enables saving game progress.
			.EnableSavedGames()
			// registers a callback to handle game invitations received while the game is not running.
			//			.WithInvitationDelegate(<callback method>)
			// registers a callback for turn based match notifications received while the
			// game is not running.
			//			.WithMatchDelegate(<callback method>)
			// require access to a player's Google+ social graph (usually not needed)
			.RequireGooglePlus()
			.Build();

		PlayGamesPlatform.InitializeInstance(config);
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate();

		GameObject.Find ("Title").GetComponent<CTitleManager> ().WRITELOG ("Init SocialManager Finish");

		LoginGooglePlayGames ();
	}

	private void LoginGooglePlayGames()
	{
		GameObject.Find ("Title").GetComponent<CTitleManager> ().WRITELOG ("Authenticate");

		if (Social.localUser.authenticated)
			return;
		
		// authenticate user:
		Social.localUser.Authenticate((bool success) => {
			// handle success or failure
			GameObject.Find ("Title").GetComponent<CTitleManager> ().WRITELOG ("Authenticate Finish");

//			((GooglePlayGames.PlayGamesPlatform)Social.Active).GetIdToken(); 

			string strMsg = Social.localUser.id;
			GameObject.Find ("Title").GetComponent<CTitleManager> ().WRITELOG (strMsg);


		});
	}

	private void GetStatsGooglePlayGames()
	{
		((PlayGamesLocalUser)Social.localUser).GetStats((rc, stats) =>
			{
				// -1 means cached stats, 0 is succeess
				// see  CommonStatusCodes for all values.
				if (rc <= 0 && stats.HasDaysSinceLastPlayed()) {
					Debug.Log("It has been " + stats.DaysSinceLastPlayed + " days");
				}
			});
	}
}
