using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Restart : MonoBehaviour {

    private int ads;

    void Start()
    {
        ads = PlayerPrefs.GetInt("AdFree", ads);
        Debug.Log(ads);
    }

    public void RestartGame()
    {
        if (Advertisement.IsReady() && ads == 0)
        {
            Advertisement.Show();
        }

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
