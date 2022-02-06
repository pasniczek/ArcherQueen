using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    public bool inventoryOpen = false;
    public GameObject Inventory_;

    void Update()
    {
        if(Input.GetKeyDown("q"))
        {
            inventoryOpen = !inventoryOpen;
        }

        if(inventoryOpen)
        {
            OpenInventory();
        }
        else
        {
            Inventory_.SetActive(false);
        }
    }

    void OpenInventory()
    {
        Inventory_.SetActive(true);
    }
}
