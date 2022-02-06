using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class anvilScript : MonoBehaviour, IDropHandler
{
    public bool anvilOpen = false;
    public GameObject Anvil;
    public GameObject AnvilUI;
    private bool playerInRange;
    public buyingGeodes bG;
    private bool spawningGeodes = true;
    public Canvas canvas;
    public Vector2 spawnPosition;
    private bool destroyingGeodes = true;
    private bool readyToHammer;
    private int buttonPress;
    public int total;
    public int randomNumber;

    public GameObject GreenImageT1;
    private GameObject GT1;
    public GameObject GreenImageT2;
    private GameObject GT2;
    public GameObject GreenImageT3;
    private GameObject GT3;

    public GameObject RedImageT1;
    private GameObject RT1;
    public GameObject RedImageT2;
    private GameObject RT2;
    public GameObject RedImageT3;
    private GameObject RT3;

    public GameObject BlueImageT1;
    private GameObject BT1;
    public GameObject BlueImageT2;
    private GameObject BT2;
    public GameObject BlueImageT3;
    private GameObject BT3;

    public GameObject YellowImageT1;
    private GameObject YT1;
    public GameObject YellowImageT2;
    private GameObject YT2;
    public GameObject YellowImageT3;
    private GameObject YT3;


    public GameObject PinkImageT1;
    private GameObject PT1;
    public GameObject PinkImageT2;
    private GameObject PT2;
    public GameObject PinkImageT3;
    private GameObject PT3;


    public int[] table ={ 60, 30, 10};

    public List<GameObject> tools;

    void Start()
    {
        OpenGT1();
    }

    void Update()
    {

        if(playerInRange && Input.GetKeyDown("e"))
        {
            anvilOpen = !anvilOpen;
        } 

        if(anvilOpen)
        {
            AnvilOpen();
        }
        else
        {
            AnvilClose();
        }

        if(GT1 != null && GT1.transform.position.x > 640 && GT1.transform.position.x < 1500 && GT1.transform.position.y > 300 && GT1.transform.position.y < 720)
        {
            readyToHammer = true;
        }
        // if(GT2 != null && GT2.transform.position.x > 640 && GT2.transform.position.x < 1500 && GT2.transform.position.y > 300 && GT2.transform.position.y < 720)
        // {
            
        // }

        // if(GT3 != null && GT3.transform.position.x > 640 && GT3.transform.position.x < 1500 && GT3.transform.position.y > 300 && GT3.transform.position.y < 720)
        // {
            
        // }
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
            anvilOpen = false;
        }
    }

    void AnvilOpen()
    {
        Anvil.SetActive(true);
        destroyingGeodes = true;

        if(spawningGeodes) 
        {
            spawnGeodes();
        }
    }

    void AnvilClose()
    {
        Anvil.SetActive(false);
        spawningGeodes = true;

        if(destroyingGeodes)
        {
            GameObject[] geodes = GameObject.FindGameObjectsWithTag("Geode");
            foreach(GameObject geode in geodes) GameObject.Destroy(geode);
            destroyingGeodes = false;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            
        }
        else
        {
            
        }
    }

    void spawnGeodes()
    {
        for(int i = 0; i < bG.BuyGreenGTINum; i++) 
        {
            GT1 = Instantiate(GreenImageT1, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }

        for(int i = 0; i < bG.BuyGreenGTIINum; i++) 
        {
            GT2 = Instantiate(GreenImageT2, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }

        for(int i = 0; i < bG.BuyGreenGTIIINum; i++) 
        {
            GT3 = Instantiate(GreenImageT3, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }



        for(int i = 0; i < bG.BuyRedGTINum; i++) 
        {
            RT1 = Instantiate(RedImageT1, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }

        for(int i = 0; i < bG.BuyRedGTIINum; i++) 
        {
            RT2 = Instantiate(RedImageT2, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;

        }

        for(int i = 0; i < bG.BuyGreenGTIIINum; i++) 
        {
            RT3 = Instantiate(RedImageT3, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }




        for(int i = 0; i < bG.BuyBlueGTINum; i++) 
        {
            BT1 = Instantiate(BlueImageT1, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }

        for(int i = 0; i < bG.BuyBlueGTIINum; i++) 
        {
            BT2 = Instantiate(BlueImageT2, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }

        for(int i = 0; i < bG.BuyBlueGTIIINum; i++) 
        {
            BT3 = Instantiate(BlueImageT3, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }





        for(int i = 0; i < bG.BuyYellowGTINum; i++) 
        {
            YT1 = Instantiate(YellowImageT1, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }

        for(int i = 0; i < bG.BuyYellowGTIINum; i++) 
        {
            YT2 = Instantiate(YellowImageT2, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }

        for(int i = 0; i < bG.BuyYellowGTIIINum; i++) 
        {
            YT3 = Instantiate(YellowImageT3, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }





        for(int i = 0; i < bG.BuyPinkGTINum; i++) 
        {
            GameObject PT1 = Instantiate(PinkImageT1, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }

        for(int i = 0; i < bG.BuyPinkGTIINum; i++) 
        {
            GameObject PT2 = Instantiate(PinkImageT2, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }

        for(int i = 0; i < bG.BuyPinkGTIIINum; i++) 
        {
            GameObject PT3 = Instantiate(PinkImageT3, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }
        spawningGeodes = false;
    }

    void Hammer()
    {
        if(readyToHammer)
        {
            buttonPress += 1;
            if(buttonPress == 3)
            {
                Debug.Log("destroyed");
            }
        }
    }

    void OpenGT1()
    {
        foreach(var item in table)
        {
            total += 1;
        }

        randomNumber = Random.Range(0, total);

        for(int i = 0; i < table.Length; i++)
        {
            if(randomNumber <= table[i])
            {
                tools[i].SetActive(true);
                return;
            }
            else
            {
                randomNumber -= table[i];
            }
        }

    }
}
