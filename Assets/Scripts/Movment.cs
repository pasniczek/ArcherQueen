using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [Header("Refrences")]
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer Sr;

    [Header("Floats")]
    public float speed;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;
    public float fallingSpeed;
    public float checkRadius;
    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float wallSlidingSpeed;

   
    [Header("Layers")]
    public LayerMask whatIsGround;
    public LayerMask Platform;

    [Header("Bools")]
    private bool isTouchingBack;
    private bool isTouchingFront;
    private bool wallSliding;
    private bool isJumping;
    private bool isGrounded;
    private bool isPlatform;
    private bool wallJumping;
    private bool turnedRight = true;
    private bool jumpRequest;
    
    [Header("Transforms")]
    public Transform frontCheck;
    public Transform backCheck;
    public Transform groundCheck;

    [Header("Layers")]
    public ParticleSystem Ps;

    [Header("Scripts")]
    public Car carScript;
    public Hair hairAnchor;



    [Header("Hair Offsets")]
    public Vector2 idleOffset = new Vector2(-0.01f, -0.1f);
    public Vector2 runOffset = new Vector2(-0.1f, -0.01f);
    public Vector2 jumpOffset = new Vector2(-0.01f, -0.1f);
    public Vector2 fallVerticlyOffset = new Vector2(-0.01f, 0.1f);
    public Vector2 fallOffset = new Vector2(-0.01f, 0.1f);
  
    

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Sr = GetComponent<SpriteRenderer>();
    }
    

    private void Update() 
    {


        // // if (DialogueManager.GetInstance().dialogueIsPlaying || touchingSpikes == true)
        // {
        //     return;
        // }

        if(carScript.inCar)
        {  
            if(!turnedRight)
            {
                Flip();
            }
            anim.SetBool("peed", false);
            anim.SetBool("wall", false);
            anim.SetBool("glide", false);
            anim.SetBool("falling", false);
            anim.SetBool("jump", false);
            rb.velocity = new Vector2(0, 0);
            return;
        }

        isPlatform = Physics2D.OverlapCircle(groundCheck.position, checkRadius, Platform);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);
        isTouchingBack = Physics2D.OverlapCircle(backCheck.position, checkRadius, whatIsGround);
    
            Animations();

            UpdateHairOffset();
        
            Jumping();
 
            WallSliding();

            Walking();

    }

       
    private void Walking(){
        float input = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
        fallingSpeed = rb.velocity.y;

    }

    private void Jumping(){
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true || Input.GetKeyDown(KeyCode.Space) && isPlatform == true )
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            Ps.Play();
        }
        if(Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    private void WallSliding(){
        float input = Input.GetAxisRaw("Horizontal");

        if (wallSliding) {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }


        if (isTouchingFront == true | isTouchingBack == true && isGrounded == false && input != 0) {
            wallSliding = true;
        }


        else {
            wallSliding = false;
        }


           if (Input.GetKeyDown(KeyCode.Space) && wallSliding == true) {
            wallJumping = true;
            StartCoroutine(WaitWallJump());
        }


        if (wallJumping == true) {
            rb.velocity = new Vector2(xWallForce * -input, yWallForce);
        }


        IEnumerator WaitWallJump() 
        {
            yield return new WaitForSeconds(wallJumpTime);
            wallJumping = false;
        }


    }

    private void Animations(){
        float input = Input.GetAxisRaw("Horizontal");
        if(isGrounded == false && wallJumping == false && isPlatform == false)
        {
            anim.SetBool("jump", true);
        }
        else 
        {
            anim.SetBool("jump", false);
        }

        if(rb.velocity.y < -35 && isGrounded == false && isJumping == false && wallJumping == false && wallSliding == false && isPlatform == false)
        {
            anim.SetBool("falling", true);
        }
        else
        {
            anim.SetBool("falling", false);
        }

        if (input != 0 && isGrounded == true || input != 0 && isPlatform == true) 
        {
            anim.SetBool("peed", true);
        }
        else 
        {
            anim.SetBool("peed", false);
        }

        if (turnedRight && rb.velocity.x < 0.01f)
        {
            Flip();
        }

        else if(!turnedRight && rb.velocity.x > 0.01f)
        {
            Flip();
        }

        if (wallSliding) 
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
            anim.SetBool("wall", true);
        }
        else 
        {
             anim.SetBool("wall", false);
        }

    }


    void UpdateHairOffset()
    {
        Vector2 currentOffset = Vector2.zero;

        // idle
        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            currentOffset = idleOffset;
        }
        // jump
        else if (rb.velocity.y > 0 && !isGrounded)
        {
            currentOffset = jumpOffset;
        }
        // fall
        else if (rb.velocity.y < 0 && rb.velocity.x == 0 && !isGrounded)  
        {
            currentOffset = fallOffset;
        }
        //fall verticly
        else if (rb.velocity.y < 0 && rb.velocity.x != 0 && !isGrounded)
        {
            currentOffset = fallVerticlyOffset;
        }
        // run
        else if (rb.velocity.x != 0)
        {
            currentOffset = runOffset;
        }

        // flip x offset direction if we're facing left
        if (!turnedRight)
        {
            currentOffset.x = currentOffset.x * -1;
        }

        hairAnchor.partOffset = currentOffset;
    }
    void Flip()
    {
        turnedRight = !turnedRight;
        transform.Rotate(0.0f, 180.0f, 0);
    }
}
    // private void OnCollisionStay2D(Collision2D collison){
    //     if (collison.gameObject.CompareTag("Spikes")){
    //         touchingSpikes = true;
    //     }
    //     else {
    //         touchingSpikes = false;
    //     }
    // }


    // private void Gliding(){
    //         if(Input.GetKey(KeyCode.LeftShift) && isGrounded()){
    //             speed = glidingSpeed;
    //             anim.SetBool("glide", true);
    //             slideCollider.enabled = slideCollider.enabled;
    //             playerCollider.enabled = !playerCollider.enabled;

    //             // playerCollider.size = new Vector3(xSize, 1f);
    //         }
    //         else {
    //             anim.SetBool("glide", false);
    //             speed = 17;
    //             playerCollider.enabled = playerCollider.enabled;
    //             slideCollider.enabled = slideCollider.enabled;
    //             // playerCollider.size = new Vector3(xSize, 3.4f);
    //         }
    

    // private void OnMouseEnter(Circle)

