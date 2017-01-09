using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboSystem : MonoBehaviour {

    public GameObject[] insectArray;
    public Text itemOne;
    public Text itemTwo;
    public Text itemThree;

    public Text scoreText;
    public Text scoreGain;
    public float score;

    public GameObject grassOne;
    public GameObject grassTwo;
    public GameObject grassThree;
    public GameObject grassFour;
    public GameObject grassFive;
    
    private bool grassTwoBool;
    private bool grassThreeBool;
    private bool grassFourBool;
    private bool grassFiveBool;

    private bool itemOneBool;
    private bool itemTwoBool;
    private bool comboFinish;

    // Array with max 3 items
    public GameObject[] comboArray = new GameObject[3];

    int index;

    void Start()
    {
        // Generate the first combo
        GenerateNewCombo();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // If gameobject is the same as the tag of the gameobject in array and itemOneBool is true
        if (collision.gameObject.tag == comboArray[0].gameObject.tag && itemOneBool == false)
        {
            //Set itemOne color to green and set itemOneBool to true
            itemOne.color = Color.green;
            itemOneBool = true;
        }
        else if (collision.gameObject.tag == comboArray[1].gameObject.tag && itemOneBool == true && itemTwoBool == false)
        {
            itemTwo.color = Color.green;
            itemTwoBool = true;
        }
        else if (collision.gameObject.tag == comboArray[2].gameObject.tag && itemTwoBool == true)
        {
            itemThree.color = Color.green;
            comboFinish = true;
        }
        // If comboFinish is true, generate new combo by invoking GenerateNewCombo
        else if(comboFinish == true)
        {
            GenerateNewCombo();
            /*
            GrassOne is always enabled, check Grass_1 in the Unity hierarchy
            So if grassOne is enabled and GrassTwoBool is false, run the if statement
            */
            if (grassOne == isActiveAndEnabled && grassTwoBool == false)
            {
                // Set Grass_2 visible in Unity hierarchy and set GrassTwoBool to true
                grassTwo.SetActive(true);
                grassTwoBool = true;
                // Set achievement progress to 20% of 100%
                Social.ReportProgress("CgkIqaSYpNwIEAIQBw", 20.0f, (bool success) => {
                    // handle success or failure
                });
            }
            else if(grassTwo == isActiveAndEnabled && grassThreeBool == false)
            {
                grassThree.SetActive(true);
                grassThreeBool = true;
                Social.ReportProgress("CgkIqaSYpNwIEAIQBw", 20.0f, (bool success) => {
                    // handle success or failure
                });
            }
            else if (grassThree == isActiveAndEnabled && grassFourBool == false)
            {
                grassFour.SetActive(true);
                grassFourBool = true;
                Social.ReportProgress("CgkIqaSYpNwIEAIQBw", 20.0f, (bool success) => {
                    // handle success or failure
                });
            }
            else if (grassFour == isActiveAndEnabled && grassFiveBool == false)
            {
                grassFive.SetActive(true);
                grassFiveBool = true;
                Social.ReportProgress("CgkIqaSYpNwIEAIQBw", 20.0f, (bool success) => {
                    // handle success or failure
                });
            }
        }
    }

    /// <summary>
    /// Generates new combo, sets the bools to the original false state so the loop can start over again.
    /// Sets the Text items to color RED.
    /// </summary>
    private void GenerateNewCombo()
    {
        Debug.Log("Generating new combo...");

        itemOneBool = false;
        itemTwoBool = false;
        comboFinish = false;

        itemOne.color = Color.red;
        itemTwo.color = Color.red;
        itemThree.color = Color.red;

        int i = 0;
        // Do a loop if i is smaller than 3
        while (i < 3)
        {
            // Take Random item from insectArray and save it to index
            index = Random.Range(0, insectArray.Length);
            // Save the index from isectArray in comboArray number i.
            comboArray[i] = insectArray[index];
            // Get gameObject tag and save it in tag as string
            string tag = comboArray[i].gameObject.tag;

            // if i is 0 set item 1 text to the tag of the gameobject
            if (i == 0)
            {
                itemOne.text = tag;
            }
            else if (i == 1)
            {
                itemTwo.text = tag;
            }
            else if (i == 2)
            {
                itemThree.text = tag;
            }
            // i + 1
            i++;
        }
    }
}
