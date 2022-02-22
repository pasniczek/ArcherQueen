using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public GameObject KeysImage;
    public int selectedKeys;
    public bool slotTaken;

    void Update()
    {
        if(selectedKeys == 0)
        {
            KeysImage.SetActive(false);
        }
        else
        {
            KeysImage.SetActive(true);
        }
        
    }
}
