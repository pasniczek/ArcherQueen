using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject WeaponImage;
    public int selectedWeapon;
    public bool slotTaken;

    void Update()
    {
        if(selectedWeapon == 0)
        {
            WeaponImage.SetActive(false);
        }
        else
        {
            WeaponImage.SetActive(true);
        }
        
    }

}
