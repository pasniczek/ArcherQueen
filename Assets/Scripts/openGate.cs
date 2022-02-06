using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openGate : MonoBehaviour
{

    private bool playerInRange;
    private bool doorDown = true;
    public GameObject door;
    private float step;
    public Vector2 top;
    public Vector2 bottom;
    public float speed;
    private float timeCount = 0.0f;

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
        }
    }

    void Update()
    {
        if(playerInRange && Input.GetKeyDown("e"))
        {
            doorDown = !doorDown;
            timeCount = 0;
        }

        if(doorDown)
        {
            DoorDown();
        }
        else
        {
            DoorUp();
        }
    }

    void DoorDown()
    {
        door.transform.position = Vector2.MoveTowards(door.transform.position, bottom, timeCount);
        timeCount = timeCount + Time.deltaTime * speed;   
    }

    void DoorUp()
    {
        door.transform.position = Vector2.MoveTowards(door.transform.position, top, timeCount);
        timeCount = timeCount + Time.deltaTime * speed;   
    }
}
