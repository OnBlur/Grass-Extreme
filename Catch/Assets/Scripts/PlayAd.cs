using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements; // Using the Unity Ads namespace.

public class PlayAd : MonoBehaviour
{
    private void Start()
    {
        Advertisement.Show();
    }
}