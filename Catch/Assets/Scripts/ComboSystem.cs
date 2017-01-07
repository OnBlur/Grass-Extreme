using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboSystem : MonoBehaviour {

    public GameObject[] insectArray;
    public Text itemOne;
    public Text itemTwo;
    public Text itemThree;

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

    public GameObject[] comboArray = new GameObject[3];

    int index;

    //public static ComboSystem Instance { set; get; }

    void Start()
    {
        //Instance = this;
        GenerateNewCombo();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == comboArray[0].gameObject.tag && itemOneBool == false)
        {
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
        else if(comboFinish == true)
        {
            GenerateNewCombo();
            if(grassOne == isActiveAndEnabled && grassTwoBool == false)
            {
                grassTwo.SetActive(true);
                grassTwoBool = true;
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
            Debug.Log("Upgrade gras");
        }
    }

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
        while (i < 3)
        {
            index = Random.Range(0, insectArray.Length);
            comboArray[i] = insectArray[index];
            string tag = comboArray[i].gameObject.tag;

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
            i++;
        }
    }
}
