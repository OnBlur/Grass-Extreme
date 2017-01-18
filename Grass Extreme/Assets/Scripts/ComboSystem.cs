using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboSystem : MonoBehaviour {

    public AudioSource source;
    public string achievementGrass;

    public GameObject[] insectArray;
    public GameObject[] comboArray = new GameObject[3];
    
    public Image[] comboImages;
    public Image[] comboFinishImages;

    public GameObject[] grass;
    public bool[] grassBool;

    private Sprite[] comboSprites = new Sprite[3];
    private bool[] comboBools = new bool[3];
    private int index;
    
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
        if (collision.gameObject.tag == comboArray[0].gameObject.tag && comboBools[0] == false)
        {
            comboFinishImages[0].gameObject.SetActive(true);
            comboBools[0] = true;
        }
        else if (collision.gameObject.tag == comboArray[1].gameObject.tag && comboBools[0] == true && comboBools[1] == false)
        {
            comboFinishImages[1].gameObject.SetActive(true);
            comboBools[1] = true;
        }
        else if (collision.gameObject.tag == comboArray[2].gameObject.tag && comboBools[1] == true && comboBools[2] == false)
        {
            comboFinishImages[2].gameObject.SetActive(true);
            comboBools[2] = true;
            GrassGrow();
            GenerateNewCombo();
        }
    }
    
    private void GrassGrow()
    {
        for (int i = 0; i < grass.Length; i++)
        {
            // If comboFinish is true, generate new combo by invoking GenerateNewCombo
            if (comboBools[2] == true)
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
    /// </summary>
    private void GenerateNewCombo()
    {
        Debug.Log("Generating new combo...");

        // Do a loop if i is smaller than 3
        for (int i = 0;  i < 3; i++)
        {
            if(comboFinishImages[2] == isActiveAndEnabled)
            {
                comboFinishImages[i].gameObject.SetActive(false);
                comboBools[i] = false; 
            }

            // Take Random item from insectArray and save it to index
            index = Random.Range(0, insectArray.Length);
            // Save the index from isectArray in comboArray number i.
            comboArray[i] = insectArray[index];
            comboSprites[i] = comboArray[i].gameObject.GetComponent<SpriteRenderer>().sprite;
            comboImages[i].sprite = comboSprites[i];
        }
    }
}
