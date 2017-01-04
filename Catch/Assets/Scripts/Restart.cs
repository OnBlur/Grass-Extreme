using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Restart : MonoBehaviour {

    public void RestartGame()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
