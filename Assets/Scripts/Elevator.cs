using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    public float speed;
    private bool playerOnPlatform;
    private float PosX;
    public float halfPlatform;
    public Vector2 topPlatform;
    public Vector2 bottomPlatform;
    private float step;
    private Animator anim;
    private bool courotineOn;
    public float leaveCooldown;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        float step =  Time.deltaTime;
        if(playerOnPlatform)
        {
            if(PosX > halfPlatform && Input.GetKey("e"))
            {
                anim.Play("elevatorIdle");
                transform.position = Vector2.MoveTowards(transform.position, bottomPlatform, step * speed);
            }
            else if(PosX < halfPlatform && Input.GetKey("e"))
            {
                anim.Play("elevatorIdle");
                transform.position = Vector2.MoveTowards(transform.position, topPlatform, step * speed);
            }
            else
            {
                anim.Play("elevatorNoAnim");
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other) 
    {
        if (other.gameObject.layer ==  9)
        {
            Vector3 linePos = other.transform.position;
            PosX = other.transform.position.x;
            playerOnPlatform = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        if(courotineOn)
        {
            StartCoroutine(leavePlatform());
        }
    }

    IEnumerator leavePlatform()
    {
        courotineOn = false;
        yield return new WaitForSeconds(leaveCooldown);
        playerOnPlatform = false;
        courotineOn = true;
    }
}
