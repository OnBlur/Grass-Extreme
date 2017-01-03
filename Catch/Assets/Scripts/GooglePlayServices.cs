using System.Collections;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms;
using UnityEngine;
using GooglePlayGames;


public class GooglePlayServices : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.DebugLogEnabled = true;

        Social.localUser.Authenticate((bool success) => {
            // handle success or failure
        });
    }

    public void ToAchievement()
    {
        if (Social.localUser.authenticated)
        {
            // show achievements UI
            Social.ShowAchievementsUI();
        }
    }

    public void ToLeaderBoard()
    {
        if (Social.localUser.authenticated)
        {
            // show leaderboard UI
            PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIqaSYpNwIEAIQBg");
        }
    }
}
