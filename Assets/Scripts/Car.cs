using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    
    public Rigidbody2D backTire;
    public Rigidbody2D frontTire;
    public GameObject frontTireCollider;
    public GameObject backTireCollider;
    public Rigidbody2D carTwerk;
    public float speed;
    public GameObject player;
    public Vector3 playerInCarOffset;
    public Vector3 playerGettingOffset;
    
    public bool inCar = false;
    private float movment;
    private bool theEnterZoneBool;


    private void Start()
    {
        inCar = false;

       
    }

    private void Update()
    {   
        if(theEnterZoneBool)
        {
            if(Input.GetKeyDown("e"))
            {
                inCar = !inCar;
            }
        }
        
        if(inCar)
        {
            playerInCar();
        }
        else
        {
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), frontTireCollider.GetComponent<Collider2D>(), false);
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), backTireCollider.GetComponent<Collider2D>(), false);
            player.GetComponent<SpriteRenderer>().sortingOrder = 100;
            
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            theEnterZoneBool = true;
        }   
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            theEnterZoneBool = false;
        }   
    }

    private void playerInCar()
    {
        movment = Input.GetAxis("Horizontal");
        backTire.AddTorque(-movment * speed * Time.deltaTime);
        frontTire.AddTorque(-movment * speed * Time.deltaTime);
        player.transform.position = transform.position + playerInCarOffset;
        player.GetComponent<SpriteRenderer>().sortingOrder = -1;
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), frontTireCollider.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), backTireCollider.GetComponent<Collider2D>());
    }
}
