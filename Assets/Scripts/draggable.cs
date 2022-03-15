using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.
using TMPro;

public class draggable : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector2 mousePosition;
    private CanvasGroup canvasGroup;
    public GameObject[] itemsSlot;

    public int location;
    public bool isG1;
    public bool isG2;
    public bool isG3;
    public bool isR1;
    public bool isR2;
    public bool isR3;
    public bool isB1;
    public bool isB2;
    public bool isB3;
    public bool isY1;
    public bool isY2;
    public bool isY3;
    public bool isP1;
    public bool isP2;
    public bool isP3;
    public bool tools;
    public bool weapon;
    public bool armor;
    public bool acc;
    public bool keys;
    private numOfLevelPointsItem Nol;
    public Tools T;
    public Weapon W;
    public Armor A;
    public Addings D;
    public Keys K;
    public GameObject slotOWeapon;
    public GameObject slotOArmor;
    public GameObject slotOKeys;
    private bool toolOToggle = true;
    private bool toolTToggle = true;
    private bool toolFToggle = true;
    private bool accIToggle = true;
    private bool accIIToggle = true;
    private bool accIIIToggle = true;
    private bool accIVToggle = true;
    private bool accVToggle = true;
    private bool Weapontoggle = true;
    private bool Armortoggle = true;
    private bool Keystoggle = true;
    public bool notGeode;
    public int slotYoureIn;
    private GameObject blanket;
    public TextMeshProUGUI Info;
    public TextMeshProUGUI Name;
    public Slider UpgSlid;
    public GameObject UpgButt;
    public TextMeshProUGUI pointsD;
    public TextMeshProUGUI levelD;




 

    private void Start()
    {
        if(notGeode)
        {
            Nol = GetComponent<numOfLevelPointsItem>();
            location = -1;
        }

        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData) 
    {

        if(!notGeode)
        {
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData) 
    {    
        if(!notGeode)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData) 
    {
        if(!notGeode)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }
    }  


    void Upgrade()
    {
        Nol.upgrade = true;
        UpgButt.SetActive(false);
        Nol.overworked = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(notGeode && Info != null && Name != null && UpgSlid != null)
        {    
            if(Nol.level == 0)
            {
                UpgSlid.maxValue = Nol.frstNum;
                levelD.text = "O";
                pointsD.text = string.Format(Nol.points + "/" + Nol.frstNum);
            }
            else if(Nol.level == 1)
            {
                UpgSlid.maxValue = Nol.scndNum;
                levelD.text = "I";
                pointsD.text = string.Format(Nol.points + "/" + Nol.scndNum);
                if(Nol.points >=  Nol.scndNum)
                {
                    Nol.overworked = true;
                }
            }
            else if(Nol.level == 2)
            {
                UpgSlid.maxValue = Nol.thrdNum;
                levelD.text = "II";
                pointsD.text = string.Format(Nol.points + "/" + Nol.thrdNum);
                if(Nol.points >=  Nol.thrdNum)
                {
                    Nol.overworked = true;
                }
            }
            else if(Nol.level == 3)
            {
                UpgSlid.maxValue = Nol.forthNum;
                levelD.text = "III";
                pointsD.text = string.Format(Nol.points + "/" + Nol.forthNum);
                if(Nol.points >=  Nol.forthNum)
                {
                    Nol.overworked = true;
                }
            }
            UpgSlid.value = Nol.points;

            if(!Nol.stuck)
            {
                Info.text = Nol.Description;
                Name.text = Nol.Name;
            }
            else
            {
                Info.text = "???";
                Name.text = "???";
            }
        }

        if(Nol.overworked)
        {
            UpgButt.SetActive(true);
            UpgButt.GetComponent<Button>().onClick.RemoveAllListeners();
            UpgButt.GetComponent<Button>().onClick.AddListener(Upgrade);
        }
        else if(!Nol.overworked)
        {
            UpgButt.SetActive(false);
        }


        if(notGeode && weapon)
        {
            if(Input.GetKey("left shift") || Input.GetKey("right shift"))
            {
                if(Weapontoggle && !W.slotTaken && !Nol.stuck)
                {
                    Weapontoggle = false;
                    transform.position = slotOWeapon.transform.position;
                    W.slotTaken = true;
                    W.WeaponImageI.SetActive(true);
                    W.WeaponImageI.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                    W.selectedWeapon = Nol.IDNum;
                }
                else if(!Weapontoggle && W.slotTaken)
                {
                    W.selectedWeapon = 0;
                    Weapontoggle = true;
                    transform.localPosition = Vector2.zero;
                    W.slotTaken = false;
                }
            }
        }
    
        if(notGeode && armor)
            {
                if(Input.GetKey("left shift") || Input.GetKey("right shift"))
                {
                    if(Armortoggle && !A.slotTaken && !Nol.stuck)
                    {
                        Armortoggle = false;
                        transform.position = slotOArmor.transform.position;
                        A.slotTaken = true;
                        A.ArmorImageI.SetActive(true);
                        A.ArmorImageI.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                        A.selectedArmor = Nol.IDNum;
                    }
                    else if(!Armortoggle && A.slotTaken)
                    {
                        A.selectedArmor = 0;
                        Armortoggle = true;
                        transform.localPosition = Vector2.zero;
                        A.slotTaken = false;
                    }
                }
            }

        if(notGeode && keys)
            {
                if(Input.GetKey("left shift") || Input.GetKey("right shift"))
                {
                    if(Keystoggle && !K.slotTaken && !Nol.stuck)
                    {
                        Keystoggle = false;
                        transform.position = slotOKeys.transform.position;
                        K.slotTaken = true;
                        K.KeysImageI.SetActive(true);
                        K.KeysImageI.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                        K.selectedKeys = Nol.IDNum;
                    }
                    else if(!Keystoggle && K.slotTaken)
                    {
                        K.selectedKeys = 0;
                        Keystoggle = true;
                        transform.localPosition = Vector2.zero;
                        K.slotTaken = false;
                    }
                }
            }
            if(notGeode && tools  && !Nol.stuck)
            {
                if(Input.GetKey("left shift") || Input.GetKey("right shift"))
                {
                    if(toolOToggle && !T.slotOTaken)
                    {
                        location = 0;
                        T.numOfWeapons = 0;
                        T.image2GO.SetActive(true);
                        T.ScndSprite = GetComponent<Image>().sprite;
                        T.InventoryImage1GO.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                        T.slotONum = Nol.IDNum;
                        transform.position = T.chestImage1GO.transform.position;
                        T.slotOTaken = true;
                        toolOToggle = false;
                        return;
                    }

                    else if(!toolOToggle && T.slotOTaken && !T.slotTTaken && !T.slotFTaken)
                    {
                        location = -1;
                        T.numOfWeapons = -1;
                        T.image1GO.SetActive(false);
                        T.slotONum = 0;
                        transform.localPosition = Vector2.zero;
                        T.slotOTaken = false;
                        toolOToggle = true;
                    }


                    if(toolOToggle && toolTToggle && T.slotOTaken && !T.slotTTaken)
                    {   
                        location = 1;
                        T.numOfWeapons = 1; 
                        T.image3GO.SetActive(true);
                        T.FrstSprite = GetComponent<Image>().sprite;
                        T.InventoryImage2GO.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                        T.slotTNum = Nol.IDNum;
                        transform.position = T.chestImage2GO.transform.position;
                        T.slotTTaken = true;
                        toolTToggle = false;
                        return;
                    }
                    else if(!toolTToggle && T.slotOTaken && T.slotTTaken && !T.slotFTaken)
                    {                
                        location = -1;
                        T.numOfWeapons = 0;
                        T.image3GO.SetActive(false);
                        T.slotTNum = 0;
                        transform.localPosition = Vector2.zero;
                        T.slotTTaken = false;
                        toolTToggle = true;
                    }


                    if(toolOToggle && toolTToggle && toolFToggle && T.slotOTaken && T.slotTTaken  && !T.slotFTaken)
                    {
                        location = 2;
                        T.numOfWeapons = 2; 
                        T.image1GO.SetActive(true);
                        T.ThrdSprite = GetComponent<Image>().sprite;
                        T.InventoryImage3GO.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                        T.slotFNum = Nol.IDNum;
                        transform.position = T.chestImage3GO.transform.position;
                        T.slotFTaken = true;
                        toolFToggle = false;
                    }
                    else if(!toolFToggle && T.slotOTaken && T.slotTTaken && T.slotFTaken)
                    {
                        location = -1;
                        T.numOfWeapons = 1; 
                        T.image1GO.SetActive(false);
                        T.slotFNum = 0;
                        transform.localPosition = Vector2.zero;
                        T.slotFTaken = false;
                        toolFToggle = true;
                    }
                }
            }

             if(notGeode && acc  && !Nol.stuck)
            {
                if(Input.GetKey("left shift") || Input.GetKey("right shift"))
                {
                    //one on
                    if(accIToggle && accIIToggle && accIIIToggle && accIVToggle && accVToggle && !D.slotITaken)
                    {
                        D.invImage1GO.SetActive(true);
                        D.invImage1GO.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                        transform.parent = D.chestImage1GO.transform;
                        D.slotINum = Nol.IDNum; 
                        transform.position = D.chestImage1GO.transform.position;
                        D.slotITaken = true;
                        accIToggle = false;
                        return;
                    }
                    else
                    {  
                        //one off
                        if(!accIToggle && accIIToggle && accIIIToggle && accIVToggle && accVToggle && D.slotITaken)
                        {
                            D.invImage1GO.SetActive(false);
                            transform.parent = D.windows[Nol.IDNum - 1].transform;
                            D.slotINum = 0;
                            transform.localPosition = Vector2.zero;
                            D.slotITaken = false;
                            accIToggle = true;
                            return;
                        }
                        
                        //two on
                        if(accIToggle && accIIToggle && accIIIToggle && accIVToggle && accVToggle && !D.slotIITaken)
                        {   
                            D.invImage2GO.SetActive(true);
                            D.invImage2GO.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                            transform.parent = D.chestImage2GO.transform;
                            D.slotIINum = Nol.IDNum;
                            transform.position = D.chestImage2GO.transform.position;
                            D.slotIITaken = true;
                            accIIToggle = false;
                            return;
                        }
                        else
                        {
                            //two off
                            if(accIToggle && !accIIToggle && accIIIToggle && accIVToggle && accVToggle &&  D.slotIITaken)
                            {
                                D.invImage2GO.SetActive(false);
                                transform.parent = D.windows[Nol.IDNum - 1].transform;
                                D.slotIINum = 0;
                                transform.localPosition = Vector2.zero;
                                D.slotIITaken = false;
                                accIIToggle = true;
                                return;
                            }

                            //three on
                            if(accIToggle && accIIToggle && accIIIToggle && accIVToggle && accVToggle && !D.slotIIITaken)
                            {
                                D.invImage3GO.SetActive(true);
                                D.invImage3GO.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                                transform.parent = D.chestImage3GO.transform;
                                D.slotIIINum = Nol.IDNum;
                                transform.position = D.chestImage3GO.transform.position;
                                D.slotIIITaken = true;
                                accIIIToggle = false;
                                return;
                            }
                            else
                            {
                                //three off
                                if(accIToggle && accIIToggle && !accIIIToggle && accIVToggle && accVToggle &&  D.slotIIITaken)
                                {
                                    D.invImage3GO.SetActive(false);
                                    transform.parent = D.windows[Nol.IDNum - 1].transform;
                                    D.slotIIINum = 0;
                                    transform.localPosition = Vector2.zero;
                                    D.slotIIITaken = false;
                                    accIIIToggle = true;
                                    return;
                                }

                                //four on
                                if(accIToggle && accIIToggle && accIIIToggle && accIVToggle && accVToggle && !D.slotIVTaken)
                                {
                                    D.invImage4GO.SetActive(true);
                                    D.invImage4GO.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                                    transform.parent = D.chestImage4GO.transform;
                                    D.slotIVNum = Nol.IDNum;
                                    transform.position = D.chestImage4GO.transform.position;
                                    D.slotIVTaken = true;
                                    accIVToggle = false;
                                    return;
                                }
                                else
                                {
                                    //four off
                                    if(accIToggle && accIIToggle && accIIIToggle && !accIVToggle && accVToggle &&  D.slotIVTaken)
                                    {
                                        D.invImage4GO.SetActive(false);
                                        transform.parent = D.windows[Nol.IDNum - 1].transform;
                                        D.slotIVNum = 0;
                                        transform.localPosition = Vector2.zero;
                                        D.slotIVTaken = false;
                                        accIVToggle = true;
                                        return;
                                    }

                                    //five on
                                    if(accIToggle && accIIToggle && accIIIToggle && accIVToggle && accVToggle && !D.slotVTaken)
                                    {
                                        D.invImage5GO.SetActive(true);
                                        D.invImage5GO.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                                        transform.parent = D.chestImage5GO.transform;
                                        D.slotVNum = Nol.IDNum;
                                        transform.position = D.chestImage5GO.transform.position;
                                        D.slotVTaken = true;
                                        accVToggle = false;
                                        return;
                                    }
                                    else
                                    {
                                        //five off
                                        if(accIToggle && accIIToggle && accIIIToggle && accIVToggle && !accVToggle &&  D.slotVTaken)
                                        {
                                            D.invImage5GO.SetActive(false);
                                            transform.parent = D.windows[Nol.IDNum - 1].transform;
                                            D.slotVNum = 0;
                                            transform.localPosition = Vector2.zero;
                                            D.slotVTaken = false;
                                            accVToggle = true;
                                            return;
                                        }

                                        //not enough slots
                                        if(accIToggle && accIIToggle && accIIIToggle && accIVToggle && accVToggle && D.slotVTaken)
                                        {
                                            Debug.LogWarning("not enough slots");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
    }
}
