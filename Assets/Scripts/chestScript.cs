using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestScript : MonoBehaviour
{
    public bool chestOpen = false;
    public GameObject Chest_;
    private bool playerInRange;

    void Update()
    {

        if(playerInRange && Input.GetKeyDown("e"))
        {
            chestOpen = !chestOpen;
        } 

        if(chestOpen)
        {
            Chest_.SetActive(true);
        }
        else
        {
            Chest_.SetActive(false);
        }
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Player")
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if(other.tag == "Player")
        {
            playerInRange = false;
            chestOpen = false;
        }
    }
}
