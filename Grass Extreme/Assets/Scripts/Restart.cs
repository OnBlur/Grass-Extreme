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
        //%50 percent chance to show ad
        if (Advertisement.IsReady() && ads == 0 && Random.value > 0.5f)
        {
            Advertisement.Show();
        }

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
