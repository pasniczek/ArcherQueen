using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundDetection : MonoBehaviour
{
    public PlayerMovementImproved Pmi;
    public bool Grass;
    public bool Rock;
    public bool Wood;
    public bool Sand;
    public LayerMask playerLayer;

    void OnTriggerEnter2D(Collider2D target)
    {
        if((playerLayer.value & (1 << target.transform.gameObject.layer)) > 0)
        {
            if(Grass)Pmi.inGrass = true;
            if(Rock)Pmi.inRock = true;
        }
    }
    void OnTriggerExit2D(Collider2D target)
    {
        if((playerLayer.value & (1 << target.transform.gameObject.layer)) > 0)
        {
            if(Grass)Pmi.inGrass = false;
            if(Rock)Pmi.inRock = false;
        }
    }
}
