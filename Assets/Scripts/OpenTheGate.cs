using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheGate : MonoBehaviour
{
    public GameObject yo_Yo;
    public GameObject firstButton; 
    public GameObject secondButton;
    public LayerMask yoYoLayer;
    public GameObject bridge1;
    public GameObject bridge2;
    public bool isActive = false;
    public float speed = 0.1f;
    public Quaternion from;
    public Quaternion secondTo;
    public Quaternion firstTo;
    public SpriteRenderer buttonPicture;
    private float timeCount = 0.0f;
    public OnCollsione Oc;



    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.layer ==  8)
        {
            timeCount = 0;
            isActive = !isActive;
        }

    }

    private void FixedUpdate()
    {
        
        // if(Oc.bottomButtonActive == true)
        // {
        //     timeCount = 0;
        //     isActive = !isActive;
        // }

        if (isActive)
        {
            openBridge();

        }                                       
        else 
        {
            closeBridge();
        }
    
    }

    private void openBridge()
    {
        bridge1.transform.rotation = Quaternion.Slerp(from, firstTo, timeCount);
        bridge2.transform.rotation =  Quaternion.Slerp(from, secondTo, timeCount); 
        timeCount = timeCount + Time.deltaTime * speed;   
    }
    private void closeBridge()
    {
        bridge1.transform.rotation = Quaternion.Slerp(firstTo, from, timeCount);
        bridge2.transform.rotation =  Quaternion.Slerp(secondTo, from, timeCount); 
        timeCount = timeCount + Time.deltaTime * speed;     
    }
}
