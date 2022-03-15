using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Addings : MonoBehaviour
{
    public bool slotITaken = false;
    public bool slotIITaken = false;
    public bool slotIIITaken = false;
    public bool slotIVTaken = false;
    public bool slotVTaken = false;
    public int slotINum;
    public int slotIINum;
    public int slotIIINum;
    public int slotIVNum;
    public int slotVNum;
    public GameObject chestImage1GO;
    public GameObject chestImage2GO;
    public GameObject chestImage3GO;
    public GameObject chestImage4GO;
    public GameObject chestImage5GO;
    public GameObject invImage1GO;
    public GameObject invImage2GO;
    public GameObject invImage3GO;
    public GameObject invImage4GO;
    public GameObject invImage5GO;
    public GameObject[] windows;

    void Update()
    {
        if(slotINum == 1 || slotIINum == 1 || slotIIINum == 1 || slotIVNum == 1 || slotVNum == 1)
        {
            //dotheonefunction
        }

        else if(slotINum == 2 || slotIINum == 2 || slotIIINum == 2 || slotIVNum == 2 || slotVNum == 2)
        {
            //dothetwofunction
        }

        else if(slotINum == 3 || slotIINum == 3 || slotIIINum == 3 || slotIVNum == 3 || slotVNum == 3)
        {
            //dothethreefunction
        }
    }
}
