using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestScript : MonoBehaviour
{
    public bool chestOpen = false;
    public GameObject Chest_;
    private bool playerInRange;
    private bool ITabOpen;
    public GameObject[] ITabUi;
    private bool IITabOpen;
    public GameObject[] IITabUi;
    private bool IIITabOpen;
    public GameObject[] IIITabUi;
    private bool IVTabOpen;
    public GameObject[] IVTabUi;
    private bool VTabOpen;
    public GameObject[] VTabUi;
    public GameObject[] otherCanvas;
    public Inventory Inventory;
    public Tools Tools;
    public bool closeBook;

    void Start()
    {
        ITabOpen = true;
    }

    void Update()
    {

        if(playerInRange && Input.GetKeyDown("e"))
        {
            chestOpen = !chestOpen;
        } 

        if(chestOpen)
        {
            closeBook = false;
            foreach(GameObject other in otherCanvas)
            {
                other.SetActive(false);
            }
            Inventory.inventoryOpen = false;
            Tools.closeCanvas = true;
            Chest_.SetActive(true);
        }
        else
        {
            if(closeBook == false) Close();
        }

        void Close()
        {
            closeBook = true;
            Chest_.SetActive(false);
            foreach(GameObject other in otherCanvas)
            {
                other.SetActive(true);
            }
            Tools.closeCanvas = false;
        }

        if(ITabOpen)
        {
            foreach(GameObject Ui in ITabUi)
            {
                Ui.SetActive(true);
            }
        }
        else
        {
            foreach(GameObject Ui in ITabUi)
            {
                Ui.SetActive(false);
            }
        }


        if(IITabOpen)
        {
            foreach(GameObject Ui in IITabUi)
            {
                Ui.SetActive(true);
            }
        }
        else
        {
            foreach(GameObject Ui in IITabUi)
            {
                Ui.SetActive(false);
            }
        }



        if(IIITabOpen)
        {
            foreach(GameObject Ui in IIITabUi)
            {
                Ui.SetActive(true);
            }
        }
        else
        {
            foreach(GameObject Ui in IIITabUi)
            {
                Ui.SetActive(false);
            }
        }



        if(IVTabOpen)
        {
            foreach(GameObject Ui in IVTabUi)
            {
                Ui.SetActive(true);
            }
        }
        else
        {
            foreach(GameObject Ui in IVTabUi)
            {
                Ui.SetActive(false);
            }
        }



        if(VTabOpen)
        {
            foreach(GameObject Ui in VTabUi)
            {
                Ui.SetActive(true);
            }
        }
        else
        {
            foreach(GameObject Ui in VTabUi)
            {
                Ui.SetActive(false);
            }
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

    public void firstTabOpen()
    {
        ITabOpen = true;
        IITabOpen = false;
        IIITabOpen = false;
        IVTabOpen = false;
        VTabOpen = false;
    }


    public void secondTabOpen()
    {
        ITabOpen = false;
        IITabOpen = true;
        IIITabOpen = false;
        IVTabOpen = false;
        VTabOpen = false;
    }

    public void thirdTabOpen()
    {
        ITabOpen = false;
        IITabOpen = false;
        IIITabOpen = true;
        IVTabOpen = false;
        VTabOpen = false;
    }


    public void fourthTabOpen()
    {
        ITabOpen = false;
        IITabOpen = false;
        IIITabOpen = false;
        IVTabOpen = true;
        VTabOpen = false;
    }


    public void fifthTabOpen()
    {
        ITabOpen = false;
        IITabOpen = false;
        IIITabOpen = false;
        IVTabOpen = false;
        VTabOpen = true;
    }
}
