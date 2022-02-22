using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class anvilScript : MonoBehaviour
{
    [HideInInspector]public bool rewardOpen = false;
    private int goalNum;
    public bool anvilOpen = false;
    public GameObject Anvil;
    private bool playerInRange;
    public buyingGeodes bG;
    private bool spawningGeodes = true;
    public Canvas canvas;
    private  Vector2 spawnPosition;
    private bool destroyingGeodes = true;
    public GameObject button;
    public int randomNumber;
    public int total;
    public GameObject imageReward;
    public TextMeshProUGUI numOfPointsReward;
    public GameObject canvasReward;
    public int maxPoints = 20;
    private int round = -1;
    public Inventory Inventory;
    public Tools Tools;
    private float currentValue;
    public float changeSpeed;
    public SliderFill Sf;
    public GameObject openAfterAnim;
    public GameObject[] otherCanvas;
    public bool otherOpen;



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


    public int[] Greentable ={ 60, 30, 10};

    public List<GameObject> Greenitems;

    public int[] Redtable ={ 60, 30, 10};

    public List<GameObject> Reditems;

    public int[] Bluetable ={ 60, 30, 10};

    public List<GameObject> Blueitems;

    public int[] Yellowtable ={ 60, 30, 10};

    public List<GameObject> Yellowitems;

    public int[] Pinktable ={ 60, 30, 10};

    public List<GameObject> Pinkitems;

    void Start()
    {
        openAfterAnim.GetComponent<CanvasGroup>().alpha = 0;
    }

    void Update()
    {

        if(playerInRange && Input.GetKeyDown("e"))
        {
            anvilOpen = !anvilOpen;
        } 

        if(anvilOpen)
        {
            otherOpen = false;
            foreach(GameObject other in otherCanvas)
            {
                other.SetActive(false);
            }
            Inventory.inventoryOpen = false;
            Tools.closeCanvas = true;
            AnvilOpen();
        }
        else
        {
            if(otherOpen == false) AnvilClose();
        }
        if(rewardOpen && Input.GetKeyDown("e"))
        {
            XButton();
        }
    }

    public void XButton()
    {
        rewardOpen = false;
        openAfterAnim.GetComponent<CanvasGroup>().alpha = 0;
        canvasReward.SetActive(false);
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
        otherOpen = true;
        Anvil.SetActive(false);
        spawningGeodes = true;
        foreach(GameObject other in otherCanvas)
        {
            other.SetActive(true);
        }
        Tools.closeCanvas = false;
        if(destroyingGeodes)
        {
            GameObject[] geodes = GameObject.FindGameObjectsWithTag("Geode");
            foreach(GameObject geode in geodes) GameObject.Destroy(geode);
            destroyingGeodes = false;
        }
    }


    void spawnGeodes()
    {
        for(int i = 0; i < bG.BuyGreenGTINum; i++) 
        {
            randomNumber = Random.Range(300, 1400);
            spawnPosition = new Vector2(randomNumber, 150);
            GT1 = Instantiate(GreenImageT1, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }

        for(int i = 0; i < bG.BuyGreenGTIINum; i++) 
        {
            randomNumber = Random.Range(300, 1400);
            spawnPosition = new Vector2(randomNumber, 150);
            GT2 = Instantiate(GreenImageT2, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }

        for(int i = 0; i < bG.BuyGreenGTIIINum; i++) 
        {
            randomNumber = Random.Range(300, 1400);
            spawnPosition = new Vector2(randomNumber, 150);
            GT3 = Instantiate(GreenImageT3, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }



        for(int i = 0; i < bG.BuyRedGTINum; i++) 
        {
            randomNumber = Random.Range(300, 1400);
            spawnPosition = new Vector2(randomNumber, 150);
            RT1 = Instantiate(RedImageT1, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }

        for(int i = 0; i < bG.BuyRedGTIINum; i++) 
        {
            randomNumber = Random.Range(300, 1400);
            spawnPosition = new Vector2(randomNumber, 150);
            RT2 = Instantiate(RedImageT2, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }

        for(int i = 0; i < bG.BuyRedGTIIINum; i++) 
        {
            randomNumber = Random.Range(300, 1400);
            spawnPosition = new Vector2(randomNumber, 150);
            RT3 = Instantiate(RedImageT3, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }




        for(int i = 0; i < bG.BuyBlueGTINum; i++) 
        {
            randomNumber = Random.Range(300, 1400);
            spawnPosition = new Vector2(randomNumber, 150);
            BT1 = Instantiate(BlueImageT1, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }

        for(int i = 0; i < bG.BuyBlueGTIINum; i++) 
        {
            randomNumber = Random.Range(300, 1400);
            spawnPosition = new Vector2(randomNumber, 150);
            BT2 = Instantiate(BlueImageT2, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }

        for(int i = 0; i < bG.BuyBlueGTIIINum; i++) 
        {
            randomNumber = Random.Range(300, 1400);
            spawnPosition = new Vector2(randomNumber, 150);
            BT3 = Instantiate(BlueImageT3, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }





        for(int i = 0; i < bG.BuyYellowGTINum; i++) 
        {
            randomNumber = Random.Range(300, 1400);
            spawnPosition = new Vector2(randomNumber, 150);
            YT1 = Instantiate(YellowImageT1, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }

        for(int i = 0; i < bG.BuyYellowGTIINum; i++) 
        { 
            randomNumber = Random.Range(300, 1400);
            spawnPosition = new Vector2(randomNumber, 150);
            YT2 = Instantiate(YellowImageT2, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }

        for(int i = 0; i < bG.BuyYellowGTIIINum; i++) 
        { 
            randomNumber = Random.Range(300, 1400);
            spawnPosition = new Vector2(randomNumber, 150);
            YT3 = Instantiate(YellowImageT3, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }





        for(int i = 0; i < bG.BuyPinkGTINum; i++) 
        {
            randomNumber = Random.Range(300, 1400);
            spawnPosition = new Vector2(randomNumber, 150);
            GameObject PT1 = Instantiate(PinkImageT1, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }

        for(int i = 0; i < bG.BuyPinkGTIINum; i++) 
        {
            randomNumber = Random.Range(300, 1400);
            spawnPosition = new Vector2(randomNumber, 150);
            GameObject PT2 = Instantiate(PinkImageT2, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }

        for(int i = 0; i < bG.BuyPinkGTIIINum; i++) 
        {   
            randomNumber = Random.Range(300, 1400);
            spawnPosition = new Vector2(randomNumber, 150);
            GameObject PT3 = Instantiate(PinkImageT3, spawnPosition, Quaternion.identity, canvas.transform) as GameObject;
        }
        spawningGeodes = false;
    }

    void waitOS()
    {
        openAfterAnim.GetComponent<CanvasGroup>().alpha = 1;
    }

    void OpenGreen()
    {
        Debug.Log("green");
                randomNumber = 0;
                total = 0;
                foreach(var item in Greentable)
                {
                    total += item;
                }
                randomNumber = Random.Range(1, total);
                for(int j = 0; j < Greentable.Length; j++)
                {
                    if(randomNumber <= Greentable[j])
                    {
                        canvasReward.SetActive(true);
                        Invoke("waitOS", 1.2f);
                        imageReward.GetComponent<Image>().sprite = Greenitems[j].GetComponent<Image>().sprite; 
                        randomNumber = Random.Range(10, maxPoints);
                        Sf.curValue = Greenitems[j].GetComponent<numOfLevelPointsItem>().points;
                        Debug.Log("points:" + Greenitems[j].GetComponent<numOfLevelPointsItem>().points);
                        goalNum = randomNumber + Greenitems[j].GetComponent<numOfLevelPointsItem>().points;
                        Debug.Log(goalNum);
                        if(Greenitems[j].GetComponent<numOfLevelPointsItem>().level == 0)
                        {
                            Sf.slider.maxValue = Greenitems[j].GetComponent<numOfLevelPointsItem>().frstNum;
                            numOfPointsReward.SetText(goalNum.ToString() + "/" + Greenitems[j].GetComponent<numOfLevelPointsItem>().frstNum);
                        }
                        else if(Greenitems[j].GetComponent<numOfLevelPointsItem>().level == 1)
                        {
                            Sf.slider.maxValue = Greenitems[j].GetComponent<numOfLevelPointsItem>().scndNum;
                            numOfPointsReward.SetText(goalNum.ToString() + "/" + Greenitems[j].GetComponent<numOfLevelPointsItem>().scndNum);
                        }

                        else if(Greenitems[j].GetComponent<numOfLevelPointsItem>().level == 2)
                        {
                            Sf.slider.maxValue = Greenitems[j].GetComponent<numOfLevelPointsItem>().thrdNum;
                            numOfPointsReward.SetText(goalNum.ToString() + "/" + Greenitems[j].GetComponent<numOfLevelPointsItem>().thrdNum);
                        }

                        else if(Greenitems[j].GetComponent<numOfLevelPointsItem>().level == 3)
                        {
                            Sf.slider.maxValue = Greenitems[j].GetComponent<numOfLevelPointsItem>().forthNum;
                            numOfPointsReward.SetText(goalNum.ToString() + "/" + Greenitems[j].GetComponent<numOfLevelPointsItem>().forthNum);
                        }
                        Sf.targetValue = goalNum;
                        Debug.Log(randomNumber);
                        Greenitems[j].GetComponent<numOfLevelPointsItem>().points += randomNumber;
                        Sf.sliderOn = true;
                        rewardOpen = true;
                        break;
                    }
                    else
                    {
                        randomNumber -= Greentable[j];
                    }
                }


    }

    void OpenRed() 
    {
        Debug.Log("red");
                randomNumber = 0;
                total = 0;
                foreach(var item in Redtable)
                {
                    total += item;
                }
                randomNumber = Random.Range(1, total);
                for(int j = 0; j < Redtable.Length; j++)
                {
                    if(randomNumber <= Redtable[j])
                    {
                        canvasReward.SetActive(true);
                        Invoke("waitOS", 1.2f);
                        imageReward.GetComponent<Image>().sprite = Reditems[j].GetComponent<Image>().sprite; 
                        randomNumber = Random.Range(10, maxPoints);
                        Sf.curValue = Reditems[j].GetComponent<numOfLevelPointsItem>().points;
                        Debug.Log("points:" + Reditems[j].GetComponent<numOfLevelPointsItem>().points);
                        goalNum = randomNumber + Reditems[j].GetComponent<numOfLevelPointsItem>().points;
                        Debug.Log(goalNum);
                        if(Reditems[j].GetComponent<numOfLevelPointsItem>().level == 0)
                        {
                            Sf.slider.maxValue = Reditems[j].GetComponent<numOfLevelPointsItem>().frstNum;
                            numOfPointsReward.SetText(goalNum.ToString() + "/" + Reditems[j].GetComponent<numOfLevelPointsItem>().frstNum);
                        }
                        else if(Reditems[j].GetComponent<numOfLevelPointsItem>().level == 1)
                        {
                            Sf.slider.maxValue = Reditems[j].GetComponent<numOfLevelPointsItem>().scndNum;
                            numOfPointsReward.SetText(goalNum.ToString() + "/" + Reditems[j].GetComponent<numOfLevelPointsItem>().scndNum);
                        }

                        else if(Reditems[j].GetComponent<numOfLevelPointsItem>().level == 2)
                        {
                            Sf.slider.maxValue = Reditems[j].GetComponent<numOfLevelPointsItem>().thrdNum;
                            numOfPointsReward.SetText(goalNum.ToString() + "/" + Reditems[j].GetComponent<numOfLevelPointsItem>().thrdNum);
                        }

                        else if(Reditems[j].GetComponent<numOfLevelPointsItem>().level == 3)
                        {
                            Sf.slider.maxValue = Reditems[j].GetComponent<numOfLevelPointsItem>().forthNum;
                            numOfPointsReward.SetText(goalNum.ToString() + "/" + Reditems[j].GetComponent<numOfLevelPointsItem>().forthNum);
                        }
                        Sf.targetValue = goalNum;
                        Debug.Log(randomNumber);
                        Reditems[j].GetComponent<numOfLevelPointsItem>().points += randomNumber;
                        Sf.sliderOn = true;
                        rewardOpen = true;
                        break;
                        }
                    else
                    {
                        randomNumber -= Redtable[j];
                    }
                }


    }


    void OpenBlue()
    {
        Debug.Log("blue");
                randomNumber = 0;
                total = 0;
                foreach(var item in Bluetable)
                {
                    total += item;
                }
                randomNumber = Random.Range(1, total);
                for(int j = 0; j < Bluetable.Length; j++)
                {
                    if(randomNumber <= Bluetable[j])
                    {
                        canvasReward.SetActive(true);
                        Invoke("waitOS", 1.2f);
                        imageReward.GetComponent<Image>().sprite = Blueitems[j].GetComponent<Image>().sprite; 
                        randomNumber = Random.Range(10, maxPoints);
                        Sf.curValue = Blueitems[j].GetComponent<numOfLevelPointsItem>().points;
                        Debug.Log("points:" + Blueitems[j].GetComponent<numOfLevelPointsItem>().points);
                        goalNum = randomNumber + Blueitems[j].GetComponent<numOfLevelPointsItem>().points;
                        Debug.Log(goalNum);
                        if(Blueitems[j].GetComponent<numOfLevelPointsItem>().level == 0)
                        {
                            Sf.slider.maxValue = Blueitems[j].GetComponent<numOfLevelPointsItem>().frstNum;
                            numOfPointsReward.SetText(goalNum.ToString() + "/" + Blueitems[j].GetComponent<numOfLevelPointsItem>().frstNum);
                        }
                        else if(Blueitems[j].GetComponent<numOfLevelPointsItem>().level == 1)
                        {
                            Sf.slider.maxValue = Blueitems[j].GetComponent<numOfLevelPointsItem>().scndNum;
                            numOfPointsReward.SetText(goalNum.ToString() + "/" + Blueitems[j].GetComponent<numOfLevelPointsItem>().scndNum);
                        }

                        else if(Blueitems[j].GetComponent<numOfLevelPointsItem>().level == 2)
                        {
                            Sf.slider.maxValue = Blueitems[j].GetComponent<numOfLevelPointsItem>().thrdNum;
                            numOfPointsReward.SetText(goalNum.ToString() + "/" + Blueitems[j].GetComponent<numOfLevelPointsItem>().thrdNum);
                        }

                        else if(Blueitems[j].GetComponent<numOfLevelPointsItem>().level == 3)
                        {
                            Sf.slider.maxValue = Blueitems[j].GetComponent<numOfLevelPointsItem>().forthNum;
                            numOfPointsReward.SetText(goalNum.ToString() + "/" + Blueitems[j].GetComponent<numOfLevelPointsItem>().forthNum);
                        }
                        Sf.targetValue = goalNum;
                        Debug.Log(randomNumber);
                        Blueitems[j].GetComponent<numOfLevelPointsItem>().points += randomNumber;
                        Sf.sliderOn = true;
                        rewardOpen = true;
                        break;
                        }
                    else
                    {
                        randomNumber -= Bluetable[j];
                    }
                }


    }
    


    void OpenYellow()
    {
        Debug.Log("yellow");
                randomNumber = 0;
                total = 0;
                foreach(var item in Yellowtable)
                {
                    total += item;
                }
                randomNumber = Random.Range(1, total);
                for(int j = 0; j < Yellowtable.Length; j++)
                {
                    if(randomNumber <= Yellowtable[j])
                    {
                        canvasReward.SetActive(true);
                        Invoke("waitOS", 1.2f);
                        imageReward.GetComponent<Image>().sprite = Yellowitems[j].GetComponent<Image>().sprite; 
                        randomNumber = Random.Range(10, maxPoints);
                        Sf.curValue = Yellowitems[j].GetComponent<numOfLevelPointsItem>().points;
                        Debug.Log("points:" + Yellowitems[j].GetComponent<numOfLevelPointsItem>().points);
                        goalNum = randomNumber + Yellowitems[j].GetComponent<numOfLevelPointsItem>().points;
                        Debug.Log(goalNum);
                        if(Yellowitems[j].GetComponent<numOfLevelPointsItem>().level == 0)
                        {
                            Sf.slider.maxValue = Yellowitems[j].GetComponent<numOfLevelPointsItem>().frstNum;
                            numOfPointsReward.SetText(goalNum.ToString() + "/" + Yellowitems[j].GetComponent<numOfLevelPointsItem>().frstNum);
                        }
                        else if(Yellowitems[j].GetComponent<numOfLevelPointsItem>().level == 1)
                        {
                            Sf.slider.maxValue = Yellowitems[j].GetComponent<numOfLevelPointsItem>().scndNum;
                            numOfPointsReward.SetText(goalNum.ToString() + "/" + Yellowitems[j].GetComponent<numOfLevelPointsItem>().scndNum);
                        }

                        else if(Yellowitems[j].GetComponent<numOfLevelPointsItem>().level == 2)
                        {
                            Sf.slider.maxValue = Yellowitems[j].GetComponent<numOfLevelPointsItem>().thrdNum;
                            numOfPointsReward.SetText(goalNum.ToString() + "/" + Yellowitems[j].GetComponent<numOfLevelPointsItem>().thrdNum);
                        }

                        else if(Yellowitems[j].GetComponent<numOfLevelPointsItem>().level == 3)
                        {
                            Sf.slider.maxValue = Yellowitems[j].GetComponent<numOfLevelPointsItem>().forthNum;
                            numOfPointsReward.SetText(goalNum.ToString() + "/" + Yellowitems[j].GetComponent<numOfLevelPointsItem>().forthNum);
                        }
                        Sf.targetValue = goalNum;
                        Debug.Log(randomNumber);
                        Yellowitems[j].GetComponent<numOfLevelPointsItem>().points += randomNumber;
                        Sf.sliderOn = true;
                        rewardOpen = true;
                        break;
                        }
                    else
                    {
                        randomNumber -= Yellowtable[j];
                    }
                }


    }


    void OpenPink()
    {
        Debug.Log("pink");
                randomNumber = 0;
                total = 0;
                foreach(var item in Pinktable)
                {
                    total += item;
                }
                randomNumber = Random.Range(1, total);
                for(int j = 0; j < Pinktable.Length; j++)
                {
                    if(randomNumber <= Pinktable[j])
                    {
                        canvasReward.SetActive(true);
                        Invoke("waitOS", 1.2f);
                        imageReward.GetComponent<Image>().sprite = Pinkitems[j].GetComponent<Image>().sprite; 
                        randomNumber = Random.Range(10, maxPoints);
                        Sf.curValue = Pinkitems[j].GetComponent<numOfLevelPointsItem>().points;
                        Debug.Log("points:" + Pinkitems[j].GetComponent<numOfLevelPointsItem>().points);
                        goalNum = randomNumber + Pinkitems[j].GetComponent<numOfLevelPointsItem>().points;
                        Debug.Log(goalNum);
                        if(Pinkitems[j].GetComponent<numOfLevelPointsItem>().level == 0)
                        {
                            Sf.slider.maxValue = Pinkitems[j].GetComponent<numOfLevelPointsItem>().frstNum;
                            numOfPointsReward.SetText(goalNum.ToString() + "/" + Pinkitems[j].GetComponent<numOfLevelPointsItem>().frstNum);
                        }
                        else if(Pinkitems[j].GetComponent<numOfLevelPointsItem>().level == 1)
                        {
                            Sf.slider.maxValue = Pinkitems[j].GetComponent<numOfLevelPointsItem>().scndNum;
                            numOfPointsReward.SetText(goalNum.ToString() + "/" + Pinkitems[j].GetComponent<numOfLevelPointsItem>().scndNum);
                        }

                        else if(Pinkitems[j].GetComponent<numOfLevelPointsItem>().level == 2)
                        {
                            Sf.slider.maxValue = Pinkitems[j].GetComponent<numOfLevelPointsItem>().thrdNum;
                            numOfPointsReward.SetText(goalNum.ToString() + "/" + Pinkitems[j].GetComponent<numOfLevelPointsItem>().thrdNum);
                        }

                        else if(Pinkitems[j].GetComponent<numOfLevelPointsItem>().level == 3)
                        {
                            Sf.slider.maxValue = Pinkitems[j].GetComponent<numOfLevelPointsItem>().forthNum;
                            numOfPointsReward.SetText(goalNum.ToString() + "/" + Pinkitems[j].GetComponent<numOfLevelPointsItem>().forthNum);
                        }
                        Sf.targetValue = goalNum;
                        Debug.Log(randomNumber);
                        Pinkitems[j].GetComponent<numOfLevelPointsItem>().points += randomNumber;
                        Sf.sliderOn = true;
                        rewardOpen = true;
                        break;
                        }
                    else
                    {
                        randomNumber -= Pinktable[j];
                    }
                }


    }


    public void OpenGT1()
    {
        anvilOpen = false;
        round = -1;
        maxPoints = 20;
        for(int i = 0; i < 1; i++)
        {
            round += 1;
            randomNumber = Random.Range(1, 100);
            if(randomNumber <= 52)
            {
                OpenGreen();
            }
            else if(randomNumber > 52 && randomNumber <= 64)
            {
                OpenRed();
            }
            else if(randomNumber > 64 && randomNumber <= 76)
            {
                OpenBlue();
            }
            else if(randomNumber > 76 & randomNumber <= 88)
            {
                OpenYellow();
            }
            else if(randomNumber > 88 && randomNumber <= 100)
            {
                OpenPink();
            }
        }
    }



    public void OpenGT2()
    {
        anvilOpen = false;
        round = -1;
        maxPoints = 25;
        for(int i = 0; i < 1; i++)
        {
            round += 1;
            randomNumber = Random.Range(1, 100);
            if(randomNumber <= 60)
            {
                OpenGreen();
            }
            else if(randomNumber > 60 && randomNumber <= 70)
            {
                OpenRed();
            }
            else if(randomNumber > 70 && randomNumber <= 80)
            {
                OpenBlue();
            }
            else if(randomNumber > 80 & randomNumber <= 90)
            {
                OpenYellow();
            }
            else if(randomNumber > 90 && randomNumber <= 100)
            {
                OpenPink();   
            }
        }
    }



    public void OpenGT3()
    {
        anvilOpen = false;
        round = -1;
        maxPoints = 30;
        for(int i = 0; i < 1; i++)
        {
            round += 1;
            randomNumber = Random.Range(1, 100);
            if(randomNumber <= 72)
            {
               OpenGreen();
            }
            else if(randomNumber > 72 && randomNumber <= 79)
            {
                OpenRed();
            }
            else if(randomNumber > 79 && randomNumber <= 86)
            {
               OpenBlue();
            }
            else if(randomNumber > 86 & randomNumber <= 93)
            {
                OpenYellow();
            }
            else if(randomNumber > 93 && randomNumber <= 100)
            {
               OpenPink();
            }
        }
    }



    public void OpenRT1()
    {
        anvilOpen = false;
        round = -1;
        maxPoints = 20;
        for(int i = 0; i < 1; i++)
        {
            round += 1;
            randomNumber = Random.Range(1, 100);
            if(randomNumber <= 52)
            {
                OpenRed();
            }
            else if(randomNumber > 52 && randomNumber <= 64)
            {
                OpenGreen();
            }
            else if(randomNumber > 64 && randomNumber <= 76)
            {
                OpenBlue();
            }
            else if(randomNumber > 76 & randomNumber <= 88)
            {
                OpenYellow();
            }
            else if(randomNumber > 88 && randomNumber <= 100)
            {
                OpenPink();
            }
        }
    }



    public void OpenRT2()
    {
        anvilOpen = false;
        round = -1;
        maxPoints = 25;
        for(int i = 0; i < 1; i++)
        {
            round += 1;
            randomNumber = Random.Range(1, 100);
            if(randomNumber <= 60)
            {
                OpenRed();
            }
            else if(randomNumber > 60 && randomNumber <= 70)
            {
                OpenGreen();
            }
            else if(randomNumber > 70 && randomNumber <= 80)
            {
                OpenBlue();
            }
            else if(randomNumber > 80 & randomNumber <= 90)
            {
                OpenYellow();
            }
            else if(randomNumber > 90 && randomNumber <= 100)
            {
                OpenPink();   
            }
        }
    }



    public void OpenRT3()
    {
        anvilOpen = false;
        round = -1;
        maxPoints = 30;
        for(int i = 0; i < 1; i++)
        {
            round += 1;
            randomNumber = Random.Range(1, 100);
            if(randomNumber <= 72)
            {
               OpenRed();
            }
            else if(randomNumber > 72 && randomNumber <= 79)
            {
                OpenGreen();
            }
            else if(randomNumber > 79 && randomNumber <= 86)
            {
               OpenBlue();
            }
            else if(randomNumber > 86 & randomNumber <= 93)
            {
                OpenYellow();
            }
            else if(randomNumber > 93 && randomNumber <= 100)
            {
               OpenPink();
            }
        }
    }



    public void OpenBT1()
     {
        anvilOpen = false;
        round = -1;
        maxPoints = 20;
        for(int i = 0; i < 1; i++)
        {
            round += 1;
            randomNumber = Random.Range(1, 100);
            if(randomNumber <= 52)
            {
                OpenBlue();
            }
            else if(randomNumber > 52 && randomNumber <= 64)
            {
                OpenGreen();
            }
            else if(randomNumber > 64 && randomNumber <= 76)
            {
                OpenRed();
            }
            else if(randomNumber > 76 & randomNumber <= 88)
            {
                OpenYellow();
            }
            else if(randomNumber > 88 && randomNumber <= 100)
            {
                OpenPink();
            }
        }
    }



    public void OpenBT2()
    {
        anvilOpen = false;
        round = -1;
        maxPoints = 25;
        for(int i = 0; i < 1; i++)
        {
            round += 1;
            randomNumber = Random.Range(1, 100);
            if(randomNumber <= 60)
            {
                OpenBlue();
            }
            else if(randomNumber > 60 && randomNumber <= 70)
            {
                OpenGreen();
            }
            else if(randomNumber > 70 && randomNumber <= 80)
            {
                OpenRed();
            }
            else if(randomNumber > 80 & randomNumber <= 90)
            {
                OpenYellow();
            }
            else if(randomNumber > 90 && randomNumber <= 100)
            {
                OpenPink();   
            }
        }
    }



    public void OpenBT3()
     {
        anvilOpen = false;
        round = -1;
        maxPoints = 30;
        for(int i = 0; i < 1; i++)
        {
            round += 1;
            randomNumber = Random.Range(1, 100);
            if(randomNumber <= 72)
            {
               OpenBlue();
            }
            else if(randomNumber > 72 && randomNumber <= 79)
            {
                OpenGreen();
            }
            else if(randomNumber > 79 && randomNumber <= 86)
            {
               OpenRed();
            }
            else if(randomNumber > 86 & randomNumber <= 93)
            {
                OpenYellow();
            }
            else if(randomNumber > 93 && randomNumber <= 100)
            {
               OpenPink();
            }
        }
    }



    public void OpenYT1()
    {
        anvilOpen = false;
        round = -1;
        maxPoints = 20;
        for(int i = 0; i < 1; i++)
        {
            round += 1;
            randomNumber = Random.Range(1, 100);
            if(randomNumber <= 52)
            {
                OpenYellow();
            }
            else if(randomNumber > 52 && randomNumber <= 64)
            {
                OpenGreen();
            }
            else if(randomNumber > 64 && randomNumber <= 76)
            {
                OpenRed();
            }
            else if(randomNumber > 76 & randomNumber <= 88)
            {
                OpenBlue();
            }
            else if(randomNumber > 88 && randomNumber <= 100)
            {
                OpenPink();
            }
        }
    }



    public void OpenYT2()
    {
        anvilOpen = false;
        round = -1;
        maxPoints = 25;
        for(int i = 0; i < 1; i++)
        {
            round += 1;
            randomNumber = Random.Range(1, 100);
            if(randomNumber <= 60)
            {
                OpenYellow();
            }
            else if(randomNumber > 60 && randomNumber <= 70)
            {
                OpenGreen();
            }
            else if(randomNumber > 70 && randomNumber <= 80)
            {
                OpenRed();
            }
            else if(randomNumber > 80 & randomNumber <= 90)
            {
                OpenBlue();
            }
            else if(randomNumber > 90 && randomNumber <= 100)
            {
                OpenPink();   
            }
        }
    }



    public void OpenYT3()
    {
        anvilOpen = false;
        round = -1;
        maxPoints = 30;
        for(int i = 0; i < 1; i++)
        {
            round += 1;
            randomNumber = Random.Range(1, 100);
            if(randomNumber <= 72)
            {
               OpenYellow();
            }
            else if(randomNumber > 72 && randomNumber <= 79)
            {
                OpenGreen();
            }
            else if(randomNumber > 79 && randomNumber <= 86)
            {
               OpenRed();
            }
            else if(randomNumber > 86 & randomNumber <= 93)
            {
                OpenBlue();
            }
            else if(randomNumber > 93 && randomNumber <= 100)
            {
               OpenPink();
            }
        }
    }



    public void OpenPT1()
    {
        anvilOpen = false;
        round = -1;
        maxPoints = 20;
        for(int i = 0; i < 1; i++)
        {
            round += 1;
            randomNumber = Random.Range(1, 100);
            if(randomNumber <= 52)
            {
                OpenPink();
            }
            else if(randomNumber > 52 && randomNumber <= 64)
            {
                OpenGreen();
            }
            else if(randomNumber > 64 && randomNumber <= 76)
            {
                OpenRed();
            }
            else if(randomNumber > 76 & randomNumber <= 88)
            {
                OpenBlue();
            }
            else if(randomNumber > 88 && randomNumber <= 100)
            {
                OpenYellow();
            }
        }
    }



    public void OpenPT2()
    {
        anvilOpen = false;
        round = -1;
        maxPoints = 25;
        for(int i = 0; i < 1; i++)
        {
            round += 1;
            randomNumber = Random.Range(1, 100);
            if(randomNumber <= 60)
            {
                OpenPink();
            }
            else if(randomNumber > 60 && randomNumber <= 70)
            {
                OpenGreen();
            }
            else if(randomNumber > 70 && randomNumber <= 80)
            {
                OpenRed();
            }
            else if(randomNumber > 80 & randomNumber <= 90)
            {
                OpenBlue();
            }
            else if(randomNumber > 90 && randomNumber <= 100)
            {
                OpenYellow();   
            }
        }
    }



    public void OpenPT3()
    {
        anvilOpen = false;
        round = -1;
        maxPoints = 30;
        for(int i = 0; i < 1; i++)
        {
            round += 1;
            randomNumber = Random.Range(1, 100);
            if(randomNumber <= 72)
            {
               OpenPink();
            }
            else if(randomNumber > 72 && randomNumber <= 79)
            {
                OpenGreen();
            }
            else if(randomNumber > 79 && randomNumber <= 86)
            {
               OpenRed();
            }
            else if(randomNumber > 86 & randomNumber <= 93)
            {
                OpenBlue();
            }
            else if(randomNumber > 93 && randomNumber <= 100)
            {
               OpenYellow();
            }
        }
    }
}
