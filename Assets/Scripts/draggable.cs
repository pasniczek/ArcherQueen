using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.

public class draggable : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Vector2 mousePosition;
    private CanvasGroup canvasGroup;
    public GameObject[] itemsSlot;

    private GameObject Info;
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
    public Keys K;
    public GameObject slotOWeapon;
    public GameObject slotOArmor;
    public GameObject slotOKeys;
    private bool toolOToggle = true;
    private bool toolTToggle = true;
    private bool toolFToggle = true;
    private bool Weapontoggle = true;
    private bool Armortoggle = true;
    private bool Keystoggle = true;
    public bool notGeode;
    public int slotYoureIn;
    private GameObject blanket;




 

    private void Awake()
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(notGeode)
        {
            if(Info == null)
            {
                Info = GameObject.FindWithTag("Info");
            }
        // Info.SetActive(true);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if(notGeode)
        {
            if(Info == null)
            {
                Info = GameObject.FindWithTag("Info");
            }
        // Info.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(notGeode && weapon)
        {
            if(Input.GetKey("left shift") || Input.GetKey("right shift"))
            {
                if(Weapontoggle && !W.slotTaken && !Nol.stuck)
                {
                    Weapontoggle = false;
                    transform.position = slotOWeapon.transform.position;
                    W.slotTaken = true;
                    W.WeaponImage.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
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
                        A.ArmorImage.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
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
                        K.KeysImage.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
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
                    if(toolOToggle && !T.slotOTaken)
                    {
                        location = 0;
                        T.numOfWeapons = 0;
                        T.image2GO.SetActive(true);
                        T.ScndSprite = GetComponent<Image>().sprite;
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
    }
}
