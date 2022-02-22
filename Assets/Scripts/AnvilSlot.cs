using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnvilSlot : MonoBehaviour, IDropHandler
{

    public GameObject anvil;
    public GameObject Bg;

    void Awake()
    {
        if(anvil == null)
        {
            anvil =  GameObject.FindWithTag("Pc");
        }

        if(Bg == null)
        {
            Bg =  GameObject.FindWithTag("Comp");
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        RectTransform invPanel = transform as RectTransform;

        if(RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
        {

            if(eventData.pointerDrag.GetComponent<draggable>().isG1) 
            {
                anvil.GetComponent<anvilScript>().OpenGT1();
                Bg.GetComponent<buyingGeodes>().BuyGreenGTINum -= 1;
            }
            if(eventData.pointerDrag.GetComponent<draggable>().isG2) 
            {
                anvil.GetComponent<anvilScript>().OpenGT2();
                Bg.GetComponent<buyingGeodes>().BuyGreenGTIINum -= 1;
            }
            if(eventData.pointerDrag.GetComponent<draggable>().isG3) 
            {
                anvil.GetComponent<anvilScript>().OpenGT3();
                Bg.GetComponent<buyingGeodes>().BuyGreenGTIIINum -= 1;
            }


            if(eventData.pointerDrag.GetComponent<draggable>().isR1) 
            {
                anvil.GetComponent<anvilScript>().OpenRT1();
                Bg.GetComponent<buyingGeodes>().BuyRedGTINum -= 1;
            }
            if(eventData.pointerDrag.GetComponent<draggable>().isR2) 
            {
                anvil.GetComponent<anvilScript>().OpenRT2();
                Bg.GetComponent<buyingGeodes>().BuyRedGTIINum -= 1;
            }
            if(eventData.pointerDrag.GetComponent<draggable>().isR3) 
            {
                anvil.GetComponent<anvilScript>().OpenRT3();
                Bg.GetComponent<buyingGeodes>().BuyRedGTIIINum -= 1;
            }



            if(eventData.pointerDrag.GetComponent<draggable>().isB1) 
            {
                anvil.GetComponent<anvilScript>().OpenBT1();
                Bg.GetComponent<buyingGeodes>().BuyBlueGTINum -= 1;
            }
            if(eventData.pointerDrag.GetComponent<draggable>().isB2) 
            {
                anvil.GetComponent<anvilScript>().OpenBT2();
                Bg.GetComponent<buyingGeodes>().BuyBlueGTIINum -= 1;
            }
            if(eventData.pointerDrag.GetComponent<draggable>().isB3) 
            {
                anvil.GetComponent<anvilScript>().OpenBT3();
                Bg.GetComponent<buyingGeodes>().BuyBlueGTIIINum -= 1;
            }

            if(eventData.pointerDrag.GetComponent<draggable>().isY1) 
            {
                anvil.GetComponent<anvilScript>().OpenYT1();
                Bg.GetComponent<buyingGeodes>().BuyYellowGTINum -= 1;
            }
            if(eventData.pointerDrag.GetComponent<draggable>().isY2) 
            {
                anvil.GetComponent<anvilScript>().OpenYT2();
                Bg.GetComponent<buyingGeodes>().BuyYellowGTIINum -= 1;
            }
            if(eventData.pointerDrag.GetComponent<draggable>().isY3) 
            {
                anvil.GetComponent<anvilScript>().OpenYT3();
                Bg.GetComponent<buyingGeodes>().BuyYellowGTIIINum -= 1;
            }



            if(eventData.pointerDrag.GetComponent<draggable>().isP1) 
            {
                anvil.GetComponent<anvilScript>().OpenPT1();
                Bg.GetComponent<buyingGeodes>().BuyPinkGTINum -= 1;
            }
            if(eventData.pointerDrag.GetComponent<draggable>().isP2) 
            {
                anvil.GetComponent<anvilScript>().OpenPT2();
                Bg.GetComponent<buyingGeodes>().BuyPinkGTIINum -= 1;
            }
            if(eventData.pointerDrag.GetComponent<draggable>().isP3) 
            {
                anvil.GetComponent<anvilScript>().OpenPT3();
                Bg.GetComponent<buyingGeodes>().BuyPinkGTIIINum -= 1;
            }
        }
    }
}