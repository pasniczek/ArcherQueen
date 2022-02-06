using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingBackground : MonoBehaviour
{

    public  GameObject background; 
    public bool startAwake;
    public LayerMask playerLayer;

    void Awake()
    {
        if(!startAwake)
        {
            background.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if((playerLayer.value & (1 << target.transform.gameObject.layer)) > 0)
        {
            background.SetActive(true);        
        }
    }
    void OnTriggerExit2D(Collider2D target)
    {
        if((playerLayer.value & (1 << target.transform.gameObject.layer)) > 0)
        {
            background.SetActive(false);        
        }
    }
}
