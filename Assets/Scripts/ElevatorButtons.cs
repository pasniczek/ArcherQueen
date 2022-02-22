using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButtons : MonoBehaviour
{
    private bool inRange;
    public bool goUp;
    public bool goDown;
    public Elevator E;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            inRange = true;
            E.buttonUpPressed = false;
            E.buttonDownPressed = false;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            inRange = false;
            E.buttonDownPressed = false;
            E.buttonUpPressed = false;
        }
    }

    void Update()
    {
        if(inRange && goUp && Input.GetKey("e"))E.buttonUpPressed = true;
        if(inRange && goDown && Input.GetKey("e"))E.buttonDownPressed = true;
        if(Input.GetKeyUp("e"))
        {
            E.buttonUpPressed = false;
            E.buttonDownPressed = false;
        }
    }
}
