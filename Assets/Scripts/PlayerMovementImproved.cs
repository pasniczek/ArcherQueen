using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovementImproved : MonoBehaviour
{
	[Header("References")]
	private Rigidbody2D rb;

	[Header("Movement")]
	public float moveSpeed;
	public float acceleration;
	public float deceleration;
	public float airAccel; //multiplier when player in air
	public float airDecel; //multiplier when player in air
	public float velPower;
	[Space(10)]
	public float frictionAmount;
	[Space(10)]
	private Vector2 moveInput;
	private Vector2 lastMoveInput;
	public bool canMove = true;
	public bool canWallJump = true;
	public bool canClimb = true;

	[Header("Jump")]
	public float jumpForce;
	public Vector2 wallJumpForce;
	[Range(0, 1)]
	public float jumpCutMultiplier;
	public float wallJumpStopRunTime;
	[Space(5)]
	public float fallGravityMultiplier;
	private float gravityScale;
	[Space(5)]
	private bool isJumping;
	private bool jumpInputReleased;

	[Header("Climb & Slide")]
	public float slideForce;
	private bool isSliding;
	public float climbSpeed;

	[Header("Checks")]
	public Transform groundCheckPoint;
	public Vector2 groundCheckSize;
	[Space(5)]
	public Transform frontWallCheckPoint;
	public Transform backWallCheckPoint;
	public Vector2 wallCheckSize;
	[Space(10)]
	public float jumpCoyoteTime;
	private float lastGroundedTime;
	[Space(5)]
	public float jumpBufferTime;
	private float lastJumpTime;
	[Space(5)]
	public float wallJumpCoyoteTime;
	private float lastOnFrontWallTime;
	private float lastOnBackWallTime;
	[Space(10)]
	private bool isFacingRight = true; //sometimes I like to make a ReadOnly attribute to display private varibles like this, allowing for info to be layed out nicer in the inspector

	[Header("Layers & Tags")]
	public LayerMask groundLayer;

	public Hair hairAnchor;
	private Animator anim;

	[Header("Hair Offsets")]
    public Vector2 idleOffset = new Vector2(-0.01f, -0.1f);
    public Vector2 runOffset = new Vector2(-0.1f, -0.01f);
    public Vector2 jumpOffset = new Vector2(-0.01f, -0.1f);
    public Vector2 fallVerticlyOffset = new Vector2(-0.01f, 0.1f);
    public Vector2 fallOffset = new Vector2(-0.01f, 0.1f);

	[Header("Animations")]	
	const string Player_run = "RunBlanket";
	const string Player_jump = "jumpBlanket";
	const string Player_idle = "IdleBlanket";

	private PhotonView view;

	private void Start()
	{
		/*
		 - retrieves rigidbody
		 - if you want the player to have more functionality in future eg: combat, more movement options, etc. 
		 - I would recommend creating a seperate Player Class and using that to hold all player info such as the rigidbody and make seperate movement, combat, classes for specific functions
		 - Highly recommed looking into abstacrtion, decoupling and inheritance if you're working on a large project
		*/
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();

		gravityScale = rb.gravityScale;

	}

	void Awake()
	{
		if(view.IsMine)
		{
			jumpInputReleased = true;
			lastJumpTime = 0;
		}
		view = GetComponent<PhotonView>();
	}

	private void Update()
	{
		
		if(view.IsMine)
		{
			Animations();

			UpdateHairOffset();

			#region Inputs
			moveInput.x = Input.GetAxisRaw("Horizontal");
			moveInput.y = Input.GetAxisRaw("Vertical");

			if (Input.GetButton("Jump"))
			{
				lastJumpTime = jumpBufferTime;
			}

			if(Input.GetButtonUp("Jump"))
			{
				OnJumpUp();
			}
			#endregion

			#region Run
			if (moveInput.x != 0)
				lastMoveInput.x = moveInput.x;
			if (moveInput.y != 0)
				lastMoveInput.y = moveInput.y;

			if ((lastMoveInput.x > 0 && !isFacingRight) || (lastMoveInput.x < 0 && isFacingRight))
			{
				Turn();
				isFacingRight = !isFacingRight;
			}
			#endregion

			#region Ground
			//checks if set box overlaps with ground
			if (Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer) && !isJumping) 
			{
				//resets countdown timer
				lastGroundedTime = jumpCoyoteTime; 
			}
			#endregion

			#region Wall
			//checks if set box overlaps with wall in front of player
			if (lastGroundedTime <= 0)
			{
				if (Physics2D.OverlapBox(frontWallCheckPoint.position, wallCheckSize, 0, groundLayer))
				{
					//resets countdown timer
					lastOnFrontWallTime = wallJumpCoyoteTime;
					lastOnBackWallTime = 0;
				}
				else if (Physics2D.OverlapBox(backWallCheckPoint.position, wallCheckSize, 0, groundLayer))
				{
					//resets countdown timer
					lastOnBackWallTime = wallJumpCoyoteTime;
					lastOnFrontWallTime = 0;
				}
			}

			if (lastOnFrontWallTime > 0 || lastOnBackWallTime > 0)
				isSliding = true;
			else
				isSliding = false;
			#endregion

			#region Jump
			//checks if the player is grounded or falling and that they have released jump
			if (rb.velocity.y <= 0)
			{
				//if so we are no longer jumping and could jump again
				isJumping = false;
			}

			//checks if was last grounded within coyoteTime and that jump has been pressed within bufferTime
			if (lastJumpTime > 0 && !isJumping && jumpInputReleased)
			{
				if (lastGroundedTime > 0)
				{
					lastGroundedTime = 0;
					Jump(jumpForce);
				}
				else if (lastOnFrontWallTime > 0 && canWallJump)
				{
					lastOnFrontWallTime = 0;
					WallJump(wallJumpForce.x, wallJumpForce.y);
					StopMovement(wallJumpStopRunTime);
				}
				else if(lastOnBackWallTime > 0 && canWallJump)
				{
					lastOnBackWallTime = 0;
					WallJump(-wallJumpForce.x, wallJumpForce.y);
					StopMovement(wallJumpStopRunTime);
				}
			}

			#endregion

			#region Timer
			lastGroundedTime -= Time.deltaTime;
			lastOnFrontWallTime -= Time.deltaTime;
			lastOnBackWallTime -= Time.deltaTime;
			lastJumpTime -= Time.deltaTime;
			#endregion
		}
	}

	private void FixedUpdate()
	{
		#region Run
		if(view.IsMine)
		{
		if (canMove)
		{
			//calculate the direction we want to move in and our desired velocity
			float targetSpeed = moveInput.x * moveSpeed;
			//calculate difference between current velocity and desired velocity
			float speedDif = targetSpeed - rb.velocity.x;

			//change acceleration rate depending on situation
			float accelRate;
			if (lastGroundedTime > 0)
			{
				accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : deceleration;
			}
			else
			{
				accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration * airAccel : deceleration * airDecel;
			}

			//applies acceleration to speed difference, the raises to a set power so acceleration increases with higher speeds
			//finally multiplies by sign to reapply direction
			float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);

			//applies force force to rigidbody, multiplying by Vector2.right so that it only affects X axis 
			rb.AddForce(movement * Vector2.right);
		}
		
		#endregion

		#region Friction
		//check if we're grounded and that we are trying to stop (not pressing forwards or backwards)
		if (lastGroundedTime > 0 && !isJumping && Mathf.Abs(moveInput.x) < 0.01f) 
		{
			//then we use either the friction amount (~ 0.2) or our velocity
			float amount = Mathf.Min(Mathf.Abs(rb.velocity.x), Mathf.Abs(frictionAmount));
			//sets to movement direction
			amount *= Mathf.Sign(rb.velocity.x);
			//applies force against movement direction
			rb.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);
		}
		#endregion

		#region Climb & Slide
		//check if we're grounded and that we are trying to stop (not pressing forwards or backwards)
		if ((lastOnBackWallTime > 0 || lastOnFrontWallTime > 0) && canClimb)
		{
			float amount = Mathf.Min(Mathf.Abs(rb.velocity.y), Mathf.Abs(slideForce));
			amount *= Mathf.Sign(rb.velocity.y);
			rb.AddForce(Vector2.up * -amount, ForceMode2D.Impulse);

			if(Input.GetKey(KeyCode.Z))
			{
				rb.velocity = new Vector2(rb.velocity.x, climbSpeed * moveInput.x);
			}
		}
		#endregion

		#region Jump Gravity
		if (rb.velocity.y < 0 && lastGroundedTime <= 0 && !isSliding)
		{
			rb.gravityScale = gravityScale * fallGravityMultiplier;
		}
		else
		{
			rb.gravityScale = gravityScale;
		}
		#endregion
		}
	}

	#region Jump
	private void Jump(float jumpForce)
	{
		//apply force, using impluse force mode
		rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		lastJumpTime = 0;
		isJumping = true;
		jumpInputReleased = false;
	}

	private void WallJump(float jumpForceX, float jumpForceY)
	{
		//flips x force if facing other direction, since when we Turn() our player the CheckPoints swap around
		if (!isFacingRight)
			jumpForceX *= -1;

		float momentumForce = rb.velocity.x * Mathf.Sign(jumpForceX);

		//apply force, using impluse force mode
		rb.AddForce(new Vector2(jumpForceX + momentumForce, jumpForceY), ForceMode2D.Impulse);
		//rb.velocity = new Vector2(jumpForceX, jumpForceY);
		lastJumpTime = 0;
		isJumping = true;
		jumpInputReleased = false;

		Debug.Log("Wall Jump: Facing Right - " + isFacingRight + " Force - " + jumpForceX + ", " + jumpForceY);
	}

	public void OnJump()
	{
		lastJumpTime = jumpBufferTime;
		jumpInputReleased = false;
	}

	public void OnJumpUp()
	{
		if (rb.velocity.y > 0 && isJumping)
		{
			//reduces current y velocity by amount (0 - 1)
			rb.AddForce(Vector2.down * rb.velocity.y * (1 - jumpCutMultiplier), ForceMode2D.Impulse);
		}

		jumpInputReleased = true;
		lastJumpTime = 0;
	}
	#endregion

	private IEnumerator StopMovement(float duration)
	{
		canMove = false;
		yield return new WaitForSeconds(duration);
		canMove = true;
	}

	private void Turn()
	{
		//stores scale and flips x axis, flipping the entire gameObject (could also rotate the player)
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(groundCheckPoint.position, groundCheckSize);
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube(frontWallCheckPoint.position, wallCheckSize);
		Gizmos.DrawWireCube(backWallCheckPoint.position, wallCheckSize);
	}

	  private void Animations(){

        if(isJumping)
			{
				anim.Play(Player_jump);
			}

        if (moveInput.x != 0 && !isJumping) 
			{
				anim.Play(Player_run);
			}
		if(moveInput.x == 0 && !isJumping)
			{
				anim.Play(Player_idle);
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
        else if (rb.velocity.y > 0 && lastGroundedTime > 0.6f)
        {
            currentOffset = jumpOffset;
        }
        // fall
        else if (rb.velocity.y < 0 && rb.velocity.x == 0 && lastGroundedTime < 0.6f)  
        {
            currentOffset = fallOffset;
        }
        //fall verticly
        else if (rb.velocity.y < 0 && rb.velocity.x != 0 && lastGroundedTime < 0.6f)
        {
            currentOffset = fallVerticlyOffset;
        }
        // run
        else if (rb.velocity.x != 0)
        {
            currentOffset = runOffset;
        }

        // flip x offset direction if we're facing left
        if (!isFacingRight)
        {
            currentOffset.x = currentOffset.x * -1;
        }

        hairAnchor.partOffset = currentOffset;
    }
}