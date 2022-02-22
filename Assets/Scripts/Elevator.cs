using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    public float lastGT;
    public GameObject elevator;
    public float speed;
    public Vector2 topPlatform;
    public Vector2 bottomPlatform;
    private float step;
    private Animator anim;
    public PlayerMovementImproved Pmi;
    private bool inRange;
    public bool buttonDownPressed = false;
    public bool buttonUpPressed = false;

    void Awake()
    {
        anim = elevator.GetComponent<Animator>();
    }


    void Update()
    {
        float step =  Time.deltaTime;
        if(Pmi.lastGroundedTime > lastGT && inRange || buttonDownPressed  || buttonUpPressed)
        {
            if(Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow) || buttonDownPressed)
            {
                anim.Play("elevatorIdle");
                elevator.transform.position = Vector2.MoveTowards(transform.position, bottomPlatform, step * speed);
            }
            else if(Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow) || buttonUpPressed)
            {
                anim.Play("elevatorIdle");
                elevator.transform.position = Vector2.MoveTowards(transform.position, topPlatform, step * speed);
            }
            else
            {
                anim.Play("elevatorNoAnim");
            }
        }
        if(!inRange && !buttonDownPressed && !buttonUpPressed)anim.Play("elevatorNoAnim");
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            inRange = true;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            inRange = false;
        }
    }
}
