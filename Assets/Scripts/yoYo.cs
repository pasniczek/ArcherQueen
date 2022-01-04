using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yoYo : MonoBehaviour
{
    public Weapons Weapons;
    public GameObject blanket;
    public GameObject yo_Yo;
    public GameObject followMouse; // get the player transform, or w/e object you want to limit in a circle    public LineRenderer ropeRenderer;
    public LineRenderer lineRenderer;


    private void Awake()
    {
        resetRope();
    }
    
    private void Update()
    {      
        if(Weapons.activatedYoYo == false)
        {
            resetRope();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
           resetRope();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            yo_Yo.transform.position = blanket.transform.position;
        }
            
    }

    private void LateUpdate()
    {
        if(Weapons.activatedYoYo == true)
        {             
            if (Input.GetKey(KeyCode.Mouse0))
            {
                activeRope();
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                followMouse.transform.position = new Vector2(mousePosition.x, mousePosition.y);
            }
        } 
    }

    private void resetRope()
    {
        GetComponent<LineRenderer>().enabled = false;
        yo_Yo.SetActive(false);
        followMouse.SetActive(false);
        
    }
    

    private void activeRope()
    {
        GetComponent<LineRenderer>().enabled = true;
        yo_Yo.SetActive(true);
        followMouse.SetActive(true);
        lineRenderer.SetPosition(0, blanket.transform.localPosition);
        lineRenderer.SetPosition(1, yo_Yo.transform.localPosition);
        
    }

    public void ActivateYoYo()
    {
        if(Weapons.activatedYoYo == true)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                lineRenderer.SetPosition(0, blanket.transform.localPosition);
                lineRenderer.SetPosition(1, yo_Yo.transform.localPosition);
            }
        }
    } 
}
