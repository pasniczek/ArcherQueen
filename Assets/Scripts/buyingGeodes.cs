using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class buyingGeodes : MonoBehaviour
{

    private bool playerInRange;
    public GameObject WebsiteCanvas;
    public GameObject[] otherCanvas;
    public GameObject ConfirmCanvas;
    private bool webClosed = false;
    public TextMeshProUGUI moneyDisplay;
    public TextMeshProUGUI ConfiramtionText;
    public Laser SellingMaterialsScript;
    public Inventory Inventory;
    public Tools Tools;
    public GameObject[] allYesButtons;
    public int GeodeNumber;

    //Greeen Geodes
    [Header("Green")]
    public int BuyGreenGTIPrice;
    public int BuyGreenGTINum = 0;
    public TextMeshProUGUI textGreenGTI;
    public GameObject buttonGreenGTI;
        	[Space(5)]
    public int BuyGreenGTIIPrice;
    public int BuyGreenGTIINum = 0;
    public TextMeshProUGUI textGreenGTII;
    public GameObject buttonGreenGTII;
        	[Space(5)]
    public int BuyGreenGTIIIPrice;
    public int BuyGreenGTIIINum = 0;
    public TextMeshProUGUI textGreenGTIII;
    public GameObject buttonGreenGTIII;

    //Red Geodes
    [Header("Red")]
    public int BuyRedGTIPrice;
    public int BuyRedGTINum = 0;
    public TextMeshProUGUI textRedGTI;
    public GameObject buttonRedGTI;
    	[Space(5)]
    public int BuyRedGTIIPrice;
    public int BuyRedGTIINum = 0;
    public TextMeshProUGUI textRedGTII;
    public GameObject buttonRedGTII;
    	[Space(5)]
    public int BuyRedGTIIIPrice;
    public int BuyRedGTIIINum = 0;
    public TextMeshProUGUI textRedGTIII;
    public GameObject buttonRedGTIII;

    //Blue Geodes
    [Header("Blue")]
    public int BuyBlueGTIPrice;
    public int BuyBlueGTINum = 0;
    public TextMeshProUGUI textBlueGTI;
    public GameObject buttonBlueGTI;
    	[Space(5)]
    public int BuyBlueGTIIPrice;
    public int BuyBlueGTIINum = 0;
    public TextMeshProUGUI textBlueGTII;
    public GameObject buttonBlueGTII;
    	[Space(5)]
    public int BuyBlueGTIIIPrice;
    public int BuyBlueGTIIINum = 0;
    public TextMeshProUGUI textBlueGTIII;
    public GameObject buttonBlueGTIII;

    //Yellow Geodes
    [Header("Yellow")]
    public int BuyYellowGTIPrice;
    public int BuyYellowGTINum = 0;
    public TextMeshProUGUI textYellowGTI;
    public GameObject buttonYellowGTI;
    	[Space(5)]
    public int BuyYellowGTIIPrice;
    public int BuyYellowGTIINum = 0;
    public TextMeshProUGUI textYellowGTII;
    public GameObject buttonYellowGTII;
    	[Space(5)]
    public int BuyYellowGTIIIPrice;
    public int BuyYellowGTIIINum = 0;
    public TextMeshProUGUI textYellowGTIII;
    public GameObject buttonYellowGTIII;

    //Pink Geodes
    [Header("Pink")]
    public int BuyPinkGTIPrice;
    public int BuyPinkGTINum = 0;
    public TextMeshProUGUI textPinkGTI;
    public GameObject buttonPinkGTI;
    	[Space(5)]
    public int BuyPinkGTIIPrice;
    public int BuyPinkGTIINum = 0;
    public TextMeshProUGUI textPinkGTII;
    public GameObject buttonPinkGTII;
    	[Space(5)]
    public int BuyPinkGTIIIPrice;
    public int BuyPinkGTIIINum = 0;
    public TextMeshProUGUI textPinkGTIII;
    public GameObject buttonPinkGTIII;
   
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
            webClosed = false;
        }
    }

    void Awake()
    {
        WebsiteCanvas.SetActive(false);
    }

    public void XButton()
    {
        webClosed = !webClosed;
    }

    void Update()
    {
        if(playerInRange && Input.GetKeyDown("e"))
        {
            webClosed = !webClosed;
        }

        if(webClosed)
        {
            WebsiteCanvas.SetActive(true);

            foreach(GameObject other in otherCanvas)
            {
                other.SetActive(false);
            }
            Inventory.inventoryOpen = false;
            Tools.closeCanvas = true;
        }
        else
        {
            CloseWebsite();
        }

        GeodeNumber = BuyBlueGTIIINum + BuyBlueGTIINum + BuyBlueGTINum + 
        BuyGreenGTIIINum + BuyGreenGTIINum + BuyGreenGTINum + 
        BuyPinkGTIIINum + BuyPinkGTIINum + BuyPinkGTINum + 
        BuyYellowGTIIINum + BuyYellowGTIINum + BuyYellowGTINum + 
        BuyRedGTIIINum + BuyRedGTIINum + BuyRedGTINum;

        if(Inventory.inventoryOpen)
        {
            textGreenGTI.SetText(BuyGreenGTINum.ToString());
            textGreenGTII.SetText(BuyGreenGTIINum.ToString());
            textGreenGTIII.SetText(BuyGreenGTIIINum.ToString());

            textRedGTI.SetText(BuyRedGTINum.ToString());
            textRedGTII.SetText(BuyRedGTIINum.ToString());
            textRedGTIII.SetText(BuyRedGTIIINum.ToString());

            textBlueGTI.SetText(BuyBlueGTINum.ToString());
            textBlueGTII.SetText(BuyBlueGTIINum.ToString());
            textBlueGTIII.SetText(BuyBlueGTIIINum.ToString());

            textYellowGTI.SetText(BuyYellowGTINum.ToString());
            textYellowGTII.SetText(BuyYellowGTIINum.ToString());
            textYellowGTIII.SetText(BuyYellowGTIIINum.ToString());

            textPinkGTI.SetText(BuyPinkGTINum.ToString());
            textPinkGTII.SetText(BuyPinkGTIINum.ToString());
            textPinkGTIII.SetText(BuyPinkGTIIINum.ToString());
        }
    }
    
    public void CancelBuy()
    {
        ConfirmCanvas.SetActive(false);
    }

    public void CloseWebsite()
    {
        WebsiteCanvas.SetActive(false);
        ConfirmCanvas.SetActive(false);

        foreach(GameObject other in otherCanvas)
        {
            other.SetActive(true);
        }
        Tools.closeCanvas = false;
    }

    public void BuyGreenGTI()
    {
        ConfirmCanvas.SetActive(true);
        foreach(GameObject yesButton in allYesButtons)
        {
            yesButton.SetActive(false);
        }
        buttonGreenGTI.SetActive(true);
        ConfiramtionText.text = "Would you like to buy green geode Tier I for " + BuyGreenGTIPrice + "$";
    }

    public void BuyGreenGII()
    {
        ConfirmCanvas.SetActive(true);
        foreach(GameObject yesButton in allYesButtons)
        {
            yesButton.SetActive(false);
        }
        buttonGreenGTII.SetActive(true);
        ConfiramtionText.text = "Would you like to buy green geode Tier II for " + BuyGreenGTIIPrice + "$";
    }

    public void BuyGreenGTIII()
    {
        ConfirmCanvas.SetActive(true);
        foreach(GameObject yesButton in allYesButtons)
        {
            yesButton.SetActive(false);
        }
        buttonGreenGTIII.SetActive(true);
        ConfiramtionText.text = "Would you like to buy green geode Tier III for " + BuyGreenGTIIIPrice + "$";
    }
    
    public void BuyRedGTI()
    {
        ConfirmCanvas.SetActive(true);
        foreach(GameObject yesButton in allYesButtons)
        {
            yesButton.SetActive(false);
        }
        buttonRedGTI.SetActive(true);
        ConfiramtionText.text = "Would you like to buy red geode Tier I for " + BuyRedGTIPrice + "$";
    }

    public void BuyRedGTII()
    {
        ConfirmCanvas.SetActive(true);
        foreach(GameObject yesButton in allYesButtons)
        {
            yesButton.SetActive(false);
        }
        buttonRedGTII.SetActive(true);
        ConfiramtionText.text = "Would you like to buy red geode Tier II for " + BuyRedGTIIPrice + "$";
    }

    public void BuyRedGTIII()
    {
        ConfirmCanvas.SetActive(true);
        foreach(GameObject yesButton in allYesButtons)
        {
            yesButton.SetActive(false);
        }
        buttonRedGTIII.SetActive(true);
        ConfiramtionText.text = "Would you like to buy red geode Tier III for " + BuyRedGTIIIPrice + "$";
    }

    public void BuyBlueGTI()
    {
        ConfirmCanvas.SetActive(true);
        foreach(GameObject yesButton in allYesButtons)
        {
            yesButton.SetActive(false);
        }
        buttonBlueGTI.SetActive(true);
        ConfiramtionText.text = "Would you like to buy blue geode Tier I for " + BuyBlueGTIPrice + "$";
    }

    public void BuyBlueGTII()
    {
        ConfirmCanvas.SetActive(true);
        foreach(GameObject yesButton in allYesButtons)
        {
            yesButton.SetActive(false);
        }
        buttonBlueGTII.SetActive(true);
        ConfiramtionText.text = "Would you like to buy blue geode Tier II for " + BuyBlueGTIIPrice + "$";
    }

    
    public void BuyBlueGTIII()
    {
        ConfirmCanvas.SetActive(true);
        foreach(GameObject yesButton in allYesButtons)
        {
            yesButton.SetActive(false);
        }
        buttonBlueGTIII.SetActive(true);
        ConfiramtionText.text = "Would you like to buy blue geode Tier III for " + BuyBlueGTIIIPrice + "$";
    }

    public void BuyYellowGTI()
    {
        ConfirmCanvas.SetActive(true);
        foreach(GameObject yesButton in allYesButtons)
        {
            yesButton.SetActive(false);
        }
        buttonYellowGTI.SetActive(true);
        ConfiramtionText.text = "Would you like to buy yellow geode Tier I for " + BuyYellowGTIPrice + "$";
    }

    public void BuyYellowGTII()
    {
        ConfirmCanvas.SetActive(true);
        foreach(GameObject yesButton in allYesButtons)
        {
            yesButton.SetActive(false);
        }
        buttonYellowGTII.SetActive(true);
        ConfiramtionText.text = "Would you like to buy yellow geode Tier II for " + BuyYellowGTIIPrice + "$";
    }

    public void BuyYellowGTIII()
    {
        ConfirmCanvas.SetActive(true);
        foreach(GameObject yesButton in allYesButtons)
        {
            yesButton.SetActive(false);
        }
        buttonYellowGTIII.SetActive(true);
        ConfiramtionText.text = "Would you like to buy yellow geode Tier III for " + BuyYellowGTIIIPrice + "$";
    }

    public void BuyPinkGTI()
    {
        ConfirmCanvas.SetActive(true);
        foreach(GameObject yesButton in allYesButtons)
        {
            yesButton.SetActive(false);
        }
        buttonPinkGTI.SetActive(true);
        ConfiramtionText.text = "Would you like to buy pink geode Tier I for " + BuyPinkGTIPrice + "$";
    }

    public void BuyPinkGTII()
    {
        ConfirmCanvas.SetActive(true);
        foreach(GameObject yesButton in allYesButtons)
        {
            yesButton.SetActive(false);
        }
        buttonPinkGTII.SetActive(true);
        ConfiramtionText.text = "Would you like to buy pink geode Tier II for " + BuyPinkGTIIPrice + "$";
    }

    public void BuyPinkGTIII()
    {
        ConfirmCanvas.SetActive(true);
        foreach(GameObject yesButton in allYesButtons)
        {
            yesButton.SetActive(false);
        }
        buttonPinkGTIII.SetActive(true);
        ConfiramtionText.text = "Would you like to buy pink geode Tier III for " + BuyPinkGTIIIPrice + "$";
    }


    public void BuyGreenGTIBuy()
    {
        if(SellingMaterialsScript.Money >= BuyGreenGTIPrice)
        {
            Debug.Log("Bought green geode Tier I");
            BuyGreenGTINum += 1;
            SellingMaterialsScript.Money -= BuyGreenGTIPrice;
        }
        else
        {
            Debug.Log("not enough money");
            ConfirmCanvas.SetActive(false);
        }
    }

    public void BuyGreenGTIIBuy()
    {
        if(SellingMaterialsScript.Money >= BuyGreenGTIIPrice)
        {
            Debug.Log("Bought green geode Tier II");
            BuyGreenGTIINum += 1;
            SellingMaterialsScript.Money -= BuyGreenGTIIPrice;
        }
        else
        {
            Debug.Log("not enough money");
            ConfirmCanvas.SetActive(false);
        }
    }

    public void BuyGreenGTIIIBuy()
    {
        if(SellingMaterialsScript.Money >= BuyGreenGTIIIPrice)
        {
            Debug.Log("Bought green geode Tier III");
            BuyGreenGTIIINum += 1;
            SellingMaterialsScript.Money -= BuyGreenGTIIIPrice;
        }
        else
        {
            Debug.Log("not enough money");
            ConfirmCanvas.SetActive(false);
        }
    }

    public void BuyRedGTIBuy()
    {
        if(SellingMaterialsScript.Money >= BuyRedGTIPrice)
        {
            Debug.Log("Bought red geode Tier I");
            BuyRedGTINum += 1;
            SellingMaterialsScript.Money -= BuyRedGTIPrice;
        }
        else
        {
            Debug.Log("not enough money");
            ConfirmCanvas.SetActive(false);
        }
    }

    public void BuyRedGTIIBuy()
    {
        if(SellingMaterialsScript.Money >= BuyRedGTIIPrice)
        {
            Debug.Log("Bought red geode Tier II");
            BuyRedGTIINum += 1;
            SellingMaterialsScript.Money -= BuyRedGTIIPrice;
        }
        else
        {
            Debug.Log("not enough money");
            ConfirmCanvas.SetActive(false);
        }
    }

    public void BuyRedGTIIIBuy()
    {
        if(SellingMaterialsScript.Money >= BuyRedGTIIIPrice)
        {
            Debug.Log("Bought red geode Tier III");
            BuyRedGTIIINum += 1;
            SellingMaterialsScript.Money -= BuyRedGTIIIPrice;
        }
        else
        {
            Debug.Log("not enough money");
            ConfirmCanvas.SetActive(false);
        }
    }

    public void BuyBlueGTIBuy()
    {
        if(SellingMaterialsScript.Money >= BuyBlueGTIPrice)
        {
            Debug.Log("Bought blue geode Tier I");
            BuyBlueGTINum += 1;
            SellingMaterialsScript.Money -= BuyBlueGTIPrice;
        }
        else
        {
            Debug.Log("not enough money");
            ConfirmCanvas.SetActive(false);
        }
    }

    public void BuyBlueGTIIBuy()
    {
        if(SellingMaterialsScript.Money >= BuyBlueGTIIPrice)
        {
            Debug.Log("Bought blue geode Tier II");
            BuyBlueGTIINum += 1;
            SellingMaterialsScript.Money -= BuyBlueGTIIPrice;
        }
        else
        {
            Debug.Log("not enough money");
            ConfirmCanvas.SetActive(false);
        }
    }

    public void BuyBlueGTIIIBuy()
    {
        if(SellingMaterialsScript.Money >= BuyBlueGTIIIPrice)
        {
            Debug.Log("Bought blue geode Tier III");
            BuyBlueGTIIINum += 1;
            SellingMaterialsScript.Money -= BuyBlueGTIIIPrice;
        }
        else
        {
            Debug.Log("not enough money");
            ConfirmCanvas.SetActive(false);
        }
    }

    public void BuyYellowGTIBuy()
    {
        if(SellingMaterialsScript.Money >= BuyYellowGTIPrice)
        {
            Debug.Log("Bought yellow geode Tier I");
            BuyYellowGTINum += 1;
            SellingMaterialsScript.Money -= BuyYellowGTIPrice;
        }
        else
        {
            Debug.Log("not enough money");
            ConfirmCanvas.SetActive(false);
        }
    }

    public void BuyYellowGTIIBuy()
    {
        if(SellingMaterialsScript.Money >= BuyYellowGTIIPrice)
        {
            Debug.Log("Bought yellow geode Tier II");
            BuyYellowGTIINum += 1;
            SellingMaterialsScript.Money -= BuyYellowGTIIPrice;
        }
        else
        {
            Debug.Log("not enough money");
            ConfirmCanvas.SetActive(false);
        }
    }

    public void BuyYellowGTIIIBuy()
    {
        if(SellingMaterialsScript.Money >= BuyYellowGTIIIPrice)
        {
            Debug.Log("Bought yellow geode Tier III");
            BuyYellowGTIIINum += 1;
            SellingMaterialsScript.Money -= BuyYellowGTIIIPrice;
        }
        else
        {
            Debug.Log("not enough money");
            ConfirmCanvas.SetActive(false);
        }
    }

    public void BuyPinkGTIBuy()
    {
        if(SellingMaterialsScript.Money >= BuyPinkGTIPrice)
        {
            Debug.Log("Bought pink geode Tier I");
            BuyPinkGTINum += 1;
            SellingMaterialsScript.Money -= BuyPinkGTIPrice;
        }
        else
        {
            Debug.Log("not enough money");
            ConfirmCanvas.SetActive(false);
        }
    }

    public void BuyPinkGTIIBuy()
    {
        if(SellingMaterialsScript.Money >= BuyPinkGTIIPrice)
        {
            Debug.Log("Bought pink geode Tier II");
            BuyPinkGTIINum += 1;
            SellingMaterialsScript.Money -= BuyPinkGTIIPrice;
        }
        else
        {
            Debug.Log("not enough money");
            ConfirmCanvas.SetActive(false);
        }
    }

    public void BuyPinkGTIIIBuy()
    {
        if(SellingMaterialsScript.Money >= BuyPinkGTIIIPrice)
        {
            Debug.Log("Bought pink geode Tier III");
            BuyPinkGTIIINum += 1;
            SellingMaterialsScript.Money -= BuyPinkGTIIIPrice;
        }
        else
        {
            Debug.Log("not enough money");
            ConfirmCanvas.SetActive(false);
        }
    }

}
