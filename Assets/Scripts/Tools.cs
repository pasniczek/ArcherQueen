using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tools : MonoBehaviour 
{

    public int slotONum;
    public int slotTNum;
    public int slotFNum;
    public bool slotOTaken = false;
    public bool slotTTaken = false;
    public bool slotFTaken = false;
    public int selectedWeapon = 0;
    public int numOfWeapons;
    public GameObject image1GO;
    public GameObject image2GO;
    public GameObject image3GO;
    public GameObject InventoryImage1GO;
    public GameObject InventoryImage2GO;
    public GameObject InventoryImage3GO;
    public GameObject chestImage1GO;
    public GameObject chestImage2GO;
    public GameObject chestImage3GO;
    public Sprite FrstSprite;
    public Sprite ScndSprite;
    public Sprite ThrdSprite;
    public bool closeCanvas;
    private GameObject[] items;

    void Awake()
    {
        items = GameObject.FindGameObjectsWithTag("Item");
    }

    void Update()
    {   
        if(numOfWeapons > 0)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if(selectedWeapon >= numOfWeapons)
                {
                    selectedWeapon = 0;
                }
                else
                {
                    selectedWeapon++;
                }
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if(selectedWeapon <= 0)
                {
                    selectedWeapon = numOfWeapons;
                }
                else
                {
                    selectedWeapon--;
                }
            }
        } 

        if(numOfWeapons <= -2)
        {
            numOfWeapons = -1;
        }
        else if(numOfWeapons >= 3)
        {
            numOfWeapons = 2;
        }
    
        InventoryImage1GO.GetComponent<Image>().sprite = ScndSprite;
        InventoryImage2GO.GetComponent<Image>().sprite = ThrdSprite;
        InventoryImage3GO.GetComponent<Image>().sprite = FrstSprite;


        if(numOfWeapons < 0 || closeCanvas)
        {
            image1GO.SetActive(false);
            image2GO.SetActive(false);
            image3GO.SetActive(false);
            InventoryImage1GO.SetActive(false);
            InventoryImage2GO.SetActive(false);
            InventoryImage3GO.SetActive(false);
        }

        if(numOfWeapons == 0 && closeCanvas == false)
        {
            image1GO.SetActive(false);
            image2GO.SetActive(true);
            image3GO.SetActive(false);
            InventoryImage1GO.SetActive(true);
            InventoryImage2GO.SetActive(false);
            InventoryImage3GO.SetActive(false);
        }
        else if(numOfWeapons == 1  && closeCanvas == false)
        {
            image1GO.SetActive(false);
            image2GO.SetActive(true);
            image3GO.SetActive(true);
            InventoryImage1GO.SetActive(true);
            InventoryImage2GO.SetActive(true);
            InventoryImage3GO.SetActive(false);
        }
        else if(numOfWeapons == 2  && closeCanvas == false)
        {
            image1GO.SetActive(true);
            image2GO.SetActive(true);
            image3GO.SetActive(true);
            InventoryImage1GO.SetActive(true);
            InventoryImage2GO.SetActive(true);
            InventoryImage3GO.SetActive(true);
        }

        if(selectedWeapon == 0 && numOfWeapons == 2)
        {
            image1GO.GetComponent<Image>().sprite = ThrdSprite;
            image2GO.GetComponent<Image>().sprite = ScndSprite;
            image3GO.GetComponent<Image>().sprite = FrstSprite;
        }
        else if(selectedWeapon == 1  && numOfWeapons == 2)
        {
            image1GO.GetComponent<Image>().sprite = ScndSprite;
            image2GO.GetComponent<Image>().sprite = FrstSprite;
            image3GO.GetComponent<Image>().sprite = ThrdSprite;
        }
        else if(selectedWeapon == 2  && numOfWeapons == 2)
        {
            image1GO.GetComponent<Image>().sprite = FrstSprite;
            image2GO.GetComponent<Image>().sprite = ThrdSprite;
            image3GO.GetComponent<Image>().sprite = ScndSprite;
        }



        if(selectedWeapon == 0 && numOfWeapons == 1)
        {
            image2GO.GetComponent<Image>().sprite = ScndSprite;
            image3GO.GetComponent<Image>().sprite = FrstSprite;
        }

        else if(selectedWeapon == 1  && numOfWeapons == 1)
        {
            image2GO.GetComponent<Image>().sprite = FrstSprite;
            image3GO.GetComponent<Image>().sprite = ScndSprite;
        }



        if(selectedWeapon == 0 && numOfWeapons == 0)
        {
            image2GO.GetComponent<Image>().sprite = ScndSprite;
        }

        if(items != null)
        {
            foreach (GameObject It in items)
            {
                if(It.GetComponent<numOfLevelPointsItem>().IDNum == 2  && selectedWeapon == It.GetComponent<draggable>().location && It.GetComponent<numOfLevelPointsItem>().stuck == false && closeCanvas == false)
                {
                    GetComponent<Hook>().enabled = true;
                }
                else if(It.GetComponent<numOfLevelPointsItem>().IDNum == 2 && selectedWeapon != It.GetComponent<draggable>().location || It.GetComponent<numOfLevelPointsItem>().IDNum == 2 && It.GetComponent<numOfLevelPointsItem>().stuck == false)
                {
                    GetComponent<Hook>().enabled = false;
                }
            }
        }
    }
}


 


