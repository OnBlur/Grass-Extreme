using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboSystem : MonoBehaviour {

    public GameObject[] insectArray;
    public GameObject[] comboArray = new GameObject[3];
    public Sprite[] comboImages = new Sprite[3];

    public Image itemOneImage;
    public Image itemTwoImage;
    public Image itemThreeImage;

    public Image itemOneFinish;
    public Image itemTwoFinish;
    public Image itemThreeFinish;

    public AudioSource source;

    public GameObject[] grass;
    public bool[] grassBool;
    public string achievementGrass;
    
    private Image image;
    private int index;

    private bool itemOneBool;
    private bool itemTwoBool;
    private bool comboFinish;
    
    void Start()
    {
        // Generate the first combo
        GenerateNewCombo();
		// Loading Audio
		source = GetComponent<AudioSource>();
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        // If gameobject is the same as the tag of the gameobject in array
        if (collision.gameObject.tag == comboArray[0].gameObject.tag && itemOneBool == false)
        {
            itemOneFinish.gameObject.SetActive(true);
            itemOneBool = true;
        }
        else if (collision.gameObject.tag == comboArray[1].gameObject.tag && itemOneBool == true && itemTwoBool == false)
        {
            itemTwoFinish.gameObject.SetActive(true);
            itemTwoBool = true;
        }
        else if (collision.gameObject.tag == comboArray[2].gameObject.tag && itemTwoBool == true && comboFinish == false)
        {
            itemThreeFinish.gameObject.SetActive(true);
            comboFinish = true;
            GrassGrow();
            GenerateNewCombo();
        }
    }
    
    private void GrassGrow()
    {
        for (int i = 0; i < 9; i++)
        {
            // If comboFinish is true, generate new combo by invoking GenerateNewCombo
            if (comboFinish == true)
            {
                /*
                GrassOne is always enabled, check Grass_1 in the Unity hierarchy
                So if grassOne is enabled and GrassTwoBool is false, run the if statement
                */
                if (grass[i] == isActiveAndEnabled && grassBool[i] == false)
                {
                    // Set Grass_2 visible in Unity hierarchy and set GrassTwoBool to true
                    grass[i].SetActive(true);
                    grassBool[i] = true;
                    source.Play();
                    // Set achievement progress to 12% of 100%
                    Social.ReportProgress(achievementGrass, 12.0f, (bool success) => {
                        // handle success or failure
                    });
                    break;
                }
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

        itemOneFinish.gameObject.SetActive(false);
        itemTwoFinish.gameObject.SetActive(false);
        itemThreeFinish.gameObject.SetActive(false);

        itemOneBool = false;
        itemTwoBool = false;
        comboFinish = false;
        
        // Do a loop if i is smaller than 3
        for (int i = 0;  i < 3; i++)
        {
            // Take Random item from insectArray and save it to index
            index = Random.Range(0, insectArray.Length);
            // Save the index from isectArray in comboArray number i.
            comboArray[i] = insectArray[index];

            comboImages[i] = comboArray[i].gameObject.GetComponent<SpriteRenderer>().sprite;
            // Get gameObject tag and save it in tag as string
            string tag = comboArray[i].gameObject.tag;

            // if i is 0 set item 1 text to the tag of the gameobject
            if (i == 0)
            {
                itemOneImage.sprite = comboImages[i];
            }
            else if (i == 1)
            {
                itemTwoImage.sprite = comboImages[i];
            }
            else if (i == 2)
            {
                itemThreeImage.sprite = comboImages[i];
            }
        }
    }
}
