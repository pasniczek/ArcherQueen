using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.Rendering.Universal;


public class buyingGeodes : MonoBehaviour
{
    private bool tic;
    private bool pageOneOpen;
    public float flipPageTime;
    public GameObject pageOne;
    public GameObject pageTwo;
    public Animator bookAnim;
    public TextMeshProUGUI NameG;
    public TextMeshProUGUI TierG;
    public TextMeshProUGUI PriceG;
    public TextMeshProUGUI ChancesG;
    private bool playerInRange; 
    public GameObject WebsiteCanvas;
    public GameObject BackgroundCanvas;
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
    private Animator anim;
    private SpriteRenderer Sr;
    public Sprite openPcSprite;
    public Sprite closedPcSprite;
    public bool closeWeb;


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
            Sr.sprite = openPcSprite;
            GetComponent<Light2D>().enabled = true;
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if(other.tag == "Player")
        {
            Sr.sprite = closedPcSprite;
            GetComponent<Light2D>().enabled = false;
            playerInRange = false;
            webClosed = false;
        }
    }

    void Awake()
    {
        WebsiteCanvas.SetActive(false);
        anim = WebsiteCanvas.GetComponent<Animator>();
        Sr = GetComponent<SpriteRenderer>();
    }

    public void XButton()
    {
        webClosed = !webClosed;
    }

    public void flipPageRight()
    {
        StartCoroutine(flipPageR());
    }

    IEnumerator flipPageR()
    {
        pageOne.SetActive(false);
        pageTwo.SetActive(false);
        bookAnim.SetTrigger("PageRight");
        yield return new WaitForSeconds(flipPageTime);
        tic = true;
        pageOneOpen = !pageOneOpen;
    }

    public void flipPageLeft()
    {
        StartCoroutine(flipPageL());
    }

    IEnumerator flipPageL()
    {
        pageOne.SetActive(false);
        pageTwo.SetActive(false);
        bookAnim.SetTrigger("PageLeft");
        yield return new WaitForSeconds(flipPageTime);
        tic = true;
        pageOneOpen = !pageOneOpen;
    }

    void Update()
    {
        if(pageOneOpen && tic)
        {
            tic = false;
            pageOne.SetActive(true);
            pageTwo.SetActive(false);
        }
        else if(!pageOneOpen && tic)
        {
            tic = false;
            pageOne.SetActive(false);    
            pageTwo.SetActive(true);     
        }

        if(playerInRange && Input.GetKeyDown("e"))
        {
            webClosed = !webClosed;
        }

        if(webClosed)
        {
            closeWeb = false;
            WebsiteCanvas.SetActive(true);
            BackgroundCanvas.SetActive(true);


            foreach(GameObject other in otherCanvas)
            {
                other.SetActive(false);
            }
            Inventory.inventoryOpen = false;
            Tools.closeCanvas = true;
        }
        else
        {
            if(closeWeb == false) CloseWebsite();
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
        closeWeb = true;
        WebsiteCanvas.SetActive(false);
        ConfirmCanvas.SetActive(false);
        BackgroundCanvas.SetActive(false);

        foreach(GameObject other in otherCanvas)
        {
            other.SetActive(true);
        }
        Tools.closeCanvas = false;
    }

    public void BuyGreenGTI()
    {
        NameG.text = "Green Geode";
        TierG.text = "Tier I";
        PriceG.SetText(BuyGreenGTIPrice.ToString());
        ChancesG.text = "Chances of Getting a Green Item: 52%";
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
        NameG.text = "Green Geode";
        TierG.text = "Tier II";
        PriceG.SetText(BuyGreenGTIIPrice.ToString());
        ChancesG.text = "Chances of Getting a Green Item: 60%";
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
        NameG.text = "Green Geode";
        TierG.text = "Tier III";
        PriceG.SetText(BuyGreenGTIIIPrice.ToString());
        ChancesG.text = "Chances of Getting a Green Item: 70%";
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
        NameG.text = "Red Geode";
        TierG.text = "Tier I";
        PriceG.SetText(BuyRedGTIPrice.ToString());
        ChancesG.text = "Chances of Getting a Red Item: 52%";
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
        NameG.text = "Red Geode";
        TierG.text = "Tier II";
        PriceG.SetText(BuyRedGTIIPrice.ToString());
        ChancesG.text = "Chances of Getting a Red Item: 60%";
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
        NameG.text = "Red Geode";
        TierG.text = "Tier III";
        PriceG.SetText(BuyRedGTIIIPrice.ToString());
        ChancesG.text = "Chances of Getting a Red Item: 70%";
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
        NameG.text = "Blue Geode";
        TierG.text = "Tier I";
        PriceG.SetText(BuyBlueGTIPrice.ToString());
        ChancesG.text = "Chances of Getting a Blue Item: 52%";
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
        NameG.text = "Blue Geode";
        TierG.text = "Tier II";
        PriceG.SetText(BuyBlueGTIIPrice.ToString());
        ChancesG.text = "Chances of Getting a Blue Item: 60%";
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
        NameG.text = "Blue Geode";
        TierG.text = "Tier III";
        PriceG.SetText(BuyBlueGTIIIPrice.ToString());
        ChancesG.text = "Chances of Getting a Blue Item: 70%";
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
        NameG.text = "Yellow Geode";
        TierG.text = "Tier I";
        PriceG.SetText(BuyYellowGTIPrice.ToString());
        ChancesG.text = "Chances of Getting a Yellow Item: 52%";
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
        NameG.text = "Yellow Geode";
        TierG.text = "Tier II";
        PriceG.SetText(BuyYellowGTIIPrice.ToString());
        ChancesG.text = "Chances of Getting a Yellow Item: 60%";
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
        NameG.text = "Yellow Geode";
        TierG.text = "Tier III";
        PriceG.SetText(BuyYellowGTIIIPrice.ToString());
        ChancesG.text = "Chances of Getting a Yellow Item: 70%";
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
        NameG.text = "Pink Geode";
        TierG.text = "Tier I";
        PriceG.SetText(BuyPinkGTIPrice.ToString());
        ChancesG.text = "Chances of Getting a Pink Item: 52%";
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
        NameG.text = "Pink Geode";
        TierG.text = "Tier II";
        PriceG.SetText(BuyPinkGTIIPrice.ToString());
        ChancesG.text = "Chances of Getting a Pink Item: 60%";
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
        NameG.text = "Pink Geode";
        TierG.text = "Tier III";
        PriceG.SetText(BuyPinkGTIIIPrice.ToString());
        ChancesG.text = "Chances of Getting a Pink Item: 70%";
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
            int RN = Random.Range(1,3);
            if(RN == 1 )
            {
                FindObjectOfType<AudioManager>().Play("buySound1");
            }
            else 
            {
                FindObjectOfType<AudioManager>().Play("buySound2");
            }
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
            int RN = Random.Range(1,3);
            if(RN == 1 )
            {
                FindObjectOfType<AudioManager>().Play("buySound1");
            }
            else 
            {
                FindObjectOfType<AudioManager>().Play("buySound2");
            }
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
            int RN = Random.Range(1,3);
            if(RN == 1 )
            {
                FindObjectOfType<AudioManager>().Play("buySound1");
            }
            else 
            {
                FindObjectOfType<AudioManager>().Play("buySound2");
            }
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
            int RN = Random.Range(1,3);
            if(RN == 1 )
            {
                FindObjectOfType<AudioManager>().Play("buySound1");
            }
            else 
            {
                FindObjectOfType<AudioManager>().Play("buySound2");
            }
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
            int RN = Random.Range(1,3);
            if(RN == 1 )
            {
                FindObjectOfType<AudioManager>().Play("buySound1");
            }
            else 
            {
                FindObjectOfType<AudioManager>().Play("buySound2");
            }
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
            int RN = Random.Range(1,3);
            if(RN == 1 )
            {
                FindObjectOfType<AudioManager>().Play("buySound1");
            }
            else 
            {
                FindObjectOfType<AudioManager>().Play("buySound2");
            }
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
            int RN = Random.Range(1,3);
            if(RN == 1 )
            {
                FindObjectOfType<AudioManager>().Play("buySound1");
            }
            else 
            {
                FindObjectOfType<AudioManager>().Play("buySound2");
            }
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
            int RN = Random.Range(1,3);
            if(RN == 1 )
            {
                FindObjectOfType<AudioManager>().Play("buySound1");
            }
            else 
            {
                FindObjectOfType<AudioManager>().Play("buySound2");
            }
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
            int RN = Random.Range(1,3);
            if(RN == 1 )
            {
                FindObjectOfType<AudioManager>().Play("buySound1");
            }
            else 
            {
                FindObjectOfType<AudioManager>().Play("buySound2");
            }
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
            int RN = Random.Range(1,3);
            if(RN == 1 )
            {
                FindObjectOfType<AudioManager>().Play("buySound1");
            }
            else 
            {
                FindObjectOfType<AudioManager>().Play("buySound2");
            }
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
            int RN = Random.Range(1,3);
            if(RN == 1 )
            {
                FindObjectOfType<AudioManager>().Play("buySound1");
            }
            else 
            {
                FindObjectOfType<AudioManager>().Play("buySound2");
            }
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
            int RN = Random.Range(1,3);
            if(RN == 1 )
            {
                FindObjectOfType<AudioManager>().Play("buySound1");
            }
            else 
            {
                FindObjectOfType<AudioManager>().Play("buySound2");
            }
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
            int RN = Random.Range(1,3);
            if(RN == 1 )
            {
                FindObjectOfType<AudioManager>().Play("buySound1");
            }
            else 
            {
                FindObjectOfType<AudioManager>().Play("buySound2");
            }
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
            int RN = Random.Range(1,3);
            if(RN == 1 )
            {
                FindObjectOfType<AudioManager>().Play("buySound1");
            }
            else 
            {
                FindObjectOfType<AudioManager>().Play("buySound2");
            }
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
            int RN = Random.Range(1,3);
            if(RN == 1 )
            {
                FindObjectOfType<AudioManager>().Play("buySound1");
            }
            else 
            {
                FindObjectOfType<AudioManager>().Play("buySound2");
            }
        }
        else
        {
            Debug.Log("not enough money");
            ConfirmCanvas.SetActive(false);
        }
    }

}
