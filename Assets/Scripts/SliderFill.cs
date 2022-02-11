using UnityEngine;
 using System.Collections;
 using UnityEngine.UI;
 
 [RequireComponent(typeof(Slider))]
 public class SliderFill : MonoBehaviour {
 
     public float fillSpeed = 1.0f;
 
     [HideInInspector]public Slider slider;
     private RectTransform fillRect;
     [HideInInspector]public float targetValue = 0f;
     [HideInInspector]public float curValue = 0f;
     [HideInInspector]public bool sliderOn = false;
 
     void Awake () {
         slider = GetComponent<Slider>();
 
         //Adds a listener to the main slider and invokes a method when the value changes.
         slider.onValueChanged.AddListener (delegate {ValueChange ();});
 
         fillRect = slider.fillRect;
         targetValue = curValue = slider.value;
     }
 
     // Invoked when the value of the slider changes.
     public void ValueChange()
     {
         targetValue = slider.value;
     }

     public void ResetSlider()
     {
        sliderOn = false;
        curValue = 0;
     }
         
     // Update is called once per frame
     void Update () 
     {
         if(sliderOn)
         {

            curValue = Mathf.MoveTowards(curValue, targetValue, Time.deltaTime * fillSpeed);
 
            Vector2 fillAnchor = fillRect.anchorMax;
            fillAnchor.x = Mathf.Clamp01(curValue/slider.maxValue);
            fillRect.anchorMax = fillAnchor;
         }


     }
 }
 