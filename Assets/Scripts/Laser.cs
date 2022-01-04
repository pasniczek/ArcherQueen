using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Hook Hook;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Material"))
        {
            Destroy(other.gameObject);
            Hook.Lr.enabled = false;
        }
    }
}
