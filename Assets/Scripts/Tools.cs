using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tools : MonoBehaviour {

    public int selectedWeapon = 0;
    public int numOfWeapons = 0;
    public GameObject[] Images;
    public bool activatedHook;
    public Image image1;
    public Image image2;
    public Image image3;
    public Image Inventoryimage1;
    public Image Inventoryimage2;
    public Image Inventoryimage3;
    public GameObject image1GO;
    public GameObject image2GO;
    public GameObject image3GO;
    public GameObject Inventoryimage1GO;
    public GameObject Inventoryimage2GO;
    public GameObject Inventoryimage3GO;
    public Sprite FrstSprite;
    public Sprite ScndSprite;
    public Sprite ThrdSprite;
    public bool closeCanvas;



    private void Update()
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
    
            Inventoryimage1.sprite = ScndSprite;
            Inventoryimage2.sprite = FrstSprite;
            Inventoryimage3.sprite = ThrdSprite;


            if(numOfWeapons < 0 || closeCanvas)
            {
                image1GO.SetActive(false);
                image2GO.SetActive(false);
                image3GO.SetActive(false);
                Inventoryimage1GO.SetActive(false);
                Inventoryimage2GO.SetActive(false);
                Inventoryimage3GO.SetActive(false);
            }

            if(numOfWeapons == 0 && closeCanvas == false)
            {
                image1GO.SetActive(false);
                image2GO.SetActive(true);
                image3GO.SetActive(false);
                Inventoryimage1GO.SetActive(true);
                Inventoryimage2GO.SetActive(false);
                Inventoryimage3GO.SetActive(false);
            }
            else if(numOfWeapons == 1  && closeCanvas == false)
            {
                image1GO.SetActive(false);
                image2GO.SetActive(true);
                image3GO.SetActive(true);
                Inventoryimage1GO.SetActive(true);
                Inventoryimage2GO.SetActive(true);
                Inventoryimage3GO.SetActive(false);
            }
            else if(numOfWeapons == 2  && closeCanvas == false)
            {
                image1GO.SetActive(true);
                image2GO.SetActive(true);
                image3GO.SetActive(true);
                Inventoryimage1GO.SetActive(true);
                Inventoryimage2GO.SetActive(true);
                Inventoryimage3GO.SetActive(true);
            }

            if(selectedWeapon == 0 && numOfWeapons == 2)
            {
                image1.sprite = FrstSprite;
                image2.sprite = ScndSprite;
                image3.sprite = ThrdSprite;
                activatedHook = true;
            }
            else if(selectedWeapon == 1  && numOfWeapons == 2)
            {
                image1.sprite = ScndSprite;
                image2.sprite = ThrdSprite;
                image3.sprite = FrstSprite;
                activatedHook = false;
            }
            else if(selectedWeapon == 2  && numOfWeapons == 2)
            {
                image1.sprite = ThrdSprite;
                image2.sprite = FrstSprite;
                image3.sprite = ScndSprite;
                activatedHook = false;
            }



            if(selectedWeapon == 0 && numOfWeapons == 1)
            {
                image2.sprite = FrstSprite;
                image3.sprite = ScndSprite;
                activatedHook = false;
            }

            else if(selectedWeapon == 1  && numOfWeapons == 1)
            {
                image2.sprite = ScndSprite;
                image3.sprite = FrstSprite;
                activatedHook = true;
            }



            if(selectedWeapon == 0 && numOfWeapons == 0)
            {
                image2.sprite = ScndSprite;
                activatedHook = true;
            }
        
    }
}


 


