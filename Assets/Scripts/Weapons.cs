using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Weapons : MonoBehaviour {

    public int selectedWeapon = 0;
    public GameObject[] weapons;
    public bool activatedYoYo;
    public bool activatedHook;
    public Image image1;
    public Image image2;
    public Image image3;
    public Sprite hookSprite;
    public Sprite yoYoSprite;
    public Sprite TrdWS;
    public Sprite FrdWS;
    public Sprite FifWS;



    private void Update()
    {   
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(selectedWeapon >= 4)
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
                selectedWeapon = 4;
            }
            else
            {
                selectedWeapon--;
            }
        }
     
        if(selectedWeapon == 0)
        {      
            activatedHook = false;
            activatedYoYo = true;
            image1.sprite = FifWS;
            image2.sprite = yoYoSprite;
            image3.sprite = hookSprite;
        } 
        if(selectedWeapon == 1)
        {
            activatedHook = true;
            activatedYoYo = false;
            image1.sprite = yoYoSprite;
            image2.sprite = hookSprite;
            image3.sprite = TrdWS;
        }
        if(selectedWeapon == 2)
        {
            activatedHook = false;
            activatedYoYo = false;
            image1.sprite = hookSprite;
            image2.sprite = TrdWS;
            image3.sprite = FrdWS;
        }
        if(selectedWeapon == 3)
        {
            activatedHook = false;
            activatedYoYo = false;
            image1.sprite = TrdWS;
            image2.sprite = FrdWS;
            image3.sprite = FifWS;
        }
        if(selectedWeapon == 4)
        {
            activatedHook = false;
            activatedYoYo = false;
            image1.sprite = FrdWS;
            image2.sprite = FifWS;
            image3.sprite = yoYoSprite;
        }

    }
}


 


