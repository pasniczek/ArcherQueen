using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.

public class draggable : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{

    public GameObject canvasGO;
    public GameObject anvil;
    public GameObject Bg;
    private Vector2 mousePosition;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public bool DneedAnvil;
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





    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
       
        if(canvasGO == null)
        {
            canvasGO =  GameObject.FindWithTag("Canvas");
        }

        if(anvil == null && DneedAnvil == false)
        {
            anvil =  GameObject.FindWithTag("Pc");
        }

        if(Bg == null  && DneedAnvil == false)
        {
            Bg =  GameObject.FindWithTag("Comp");
        }
    }

    public void OnBeginDrag(PointerEventData eventData) 
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) 
    {
        rectTransform.anchoredPosition += eventData.delta  / canvasGO.GetComponent<Canvas>().scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) 
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }  

    public void OnPointerDown(PointerEventData eventData) 
    {
        if(isG1) 
        {
            anvil.GetComponent<anvilScript>().OpenGT1();
            Bg.GetComponent<buyingGeodes>().BuyGreenGTINum -= 1;
        }
        if(isG2) 
        {
            anvil.GetComponent<anvilScript>().OpenGT2();
            Bg.GetComponent<buyingGeodes>().BuyGreenGTIINum -= 1;
        }
        if(isG3) 
        {
            anvil.GetComponent<anvilScript>().OpenGT3();
            Bg.GetComponent<buyingGeodes>().BuyGreenGTIIINum -= 1;
        }


        if(isR1) 
        {
            anvil.GetComponent<anvilScript>().OpenRT1();
            Bg.GetComponent<buyingGeodes>().BuyRedGTINum -= 1;
        }
        if(isR2) 
        {
            anvil.GetComponent<anvilScript>().OpenRT2();
            Bg.GetComponent<buyingGeodes>().BuyRedGTIINum -= 1;
        }
        if(isR3) 
        {
            anvil.GetComponent<anvilScript>().OpenRT3();
            Bg.GetComponent<buyingGeodes>().BuyRedGTIIINum -= 1;
        }



        if(isB1) 
        {
            anvil.GetComponent<anvilScript>().OpenBT1();
            Bg.GetComponent<buyingGeodes>().BuyBlueGTINum -= 1;
        }
        if(isB2) 
        {
            anvil.GetComponent<anvilScript>().OpenBT2();
            Bg.GetComponent<buyingGeodes>().BuyBlueGTIINum -= 1;
        }
        if(isB3) 
        {
            anvil.GetComponent<anvilScript>().OpenBT3();
            Bg.GetComponent<buyingGeodes>().BuyBlueGTIIINum -= 1;
        }

        if(isY1) 
        {
            anvil.GetComponent<anvilScript>().OpenYT1();
            Bg.GetComponent<buyingGeodes>().BuyYellowGTINum -= 1;
        }
        if(isY2) 
        {
            anvil.GetComponent<anvilScript>().OpenYT2();
            Bg.GetComponent<buyingGeodes>().BuyYellowGTIINum -= 1;
        }
        if(isY3) 
        {
            anvil.GetComponent<anvilScript>().OpenYT3();
            Bg.GetComponent<buyingGeodes>().BuyYellowGTIIINum -= 1;
        }



        if(isP1) 
        {
            anvil.GetComponent<anvilScript>().OpenPT1();
            Bg.GetComponent<buyingGeodes>().BuyPinkGTINum -= 1;
        }
        if(isP2) 
        {
            anvil.GetComponent<anvilScript>().OpenPT2();
            Bg.GetComponent<buyingGeodes>().BuyPinkGTIINum -= 1;
        }
        if(isP3) 
        {
            anvil.GetComponent<anvilScript>().OpenPT3();
            Bg.GetComponent<buyingGeodes>().BuyPinkGTIIINum -= 1;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
