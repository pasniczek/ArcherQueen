using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject WeaponImageI;
    public int selectedWeapon;
    public bool slotTaken;

    void Update()
    {
        if(selectedWeapon == 0)
        {
            WeaponImageI.SetActive(false);
        }
        else
        {
            WeaponImageI.SetActive(true);
        }
        
    }

}
