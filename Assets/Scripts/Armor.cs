using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public GameObject ArmorImageI;
    public int selectedArmor;
    public bool slotTaken;

    void Update()
    {
        if(selectedArmor == 0)
        {
            ArmorImageI.SetActive(false);
        }
        else
        {
            ArmorImageI.SetActive(true);
        }
        
    }
}
