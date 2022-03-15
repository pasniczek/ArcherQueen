using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public GameObject KeysImageI;
    public int selectedKeys;
    public bool slotTaken;

    void Update()
    {
        if(selectedKeys == 0)
        {
            KeysImageI.SetActive(false);
        }
        else
        {
            KeysImageI.SetActive(true);
        }
        
    }
}
