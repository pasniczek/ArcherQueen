using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public GameObject ArmorImage;
    public int selectedArmor;
    public bool slotTaken;

    void Update()
    {
        if(selectedArmor == 0)
        {
            ArmorImage.SetActive(false);
        }
        else
        {
            ArmorImage.SetActive(true);
        }
        
    }
}
