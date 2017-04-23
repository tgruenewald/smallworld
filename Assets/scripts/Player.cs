using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpStrength;
    public LayerMask WhatIsGround;
    private bool isGrounded;
    public bool IsGrounded { get { return isGrounded; } }
    public Collider2D GroundCheck;

	// animation
	private bool facingRight = false;
	private Animator animator;
	public bool DEBUG_GROUNDED;
    //private float nextJumpTime = 0.0f;

    public GameObject CurrentPlanet { get { return currentPlanet; } }
    private GameObject currentPlanet;

    // Use this for initialization
    void Start ()
    {
		GroundCheck = GetComponent<CircleCollider2D>();
        Camera.main.GetComponent<SmoothCamera>().target = gameObject;
		animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        PerformGroundCheck();
		DEBUG_GROUNDED = IsGrounded;
		animator.SetBool("isWalking", false);
        if(currentPlanet != null)
        {
            this.transform.up = -(currentPlanet.transform.position - this.transform.position);
            //Vector3 directionToCurrentPlanetCenter = currentPlanet.transform.position - this.transform.position;
            //Quaternion lookAtQuat = Quaternion.LookRotation(directionToCurrentPlanetCenter);
            ////this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this)
            //this.transform.rotation = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, (lookAtQuat * Quaternion.Euler(0, 0, 90)).z, this.transform.rotation.w);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            //GetComponent<Rigidbody2D>().AddForce(transform.right * Speed);
            transform.position += transform.right * (Speed * Time.deltaTime);
			if (!facingRight) {
				Flip ();
			}
			animator.SetBool("isWalking", true);
            //			var V =  GetComponent<Rigidbody2D>();
            //			Vector3 direction = V.rotation * Vector3.right;
            //			//var direction = transform.rotation;
            //			//direction.z += 90;
            //
            //
            //			//V.AddForce(V.rotation * 0.001f);
            //
            //			GetComponent<Rigidbody2D> ().AddForce (transform.forward * 25);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //GetComponent<Rigidbody2D>().AddForce(-(transform.right) * Speed);
            transform.position -= transform.right * (Speed * Time.deltaTime);
			if (facingRight) {
				Flip ();
			}
			animator.SetBool("isWalking", true);
        }
        if (Input.GetKey(KeyCode.W) && IsGrounded /*&& nextJumpTime <= Time.time*/)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * JumpStrength);
            //transform.position += transform.up * JumpStrength;
        }
		// animation control
		if (IsGrounded) {
			animator.SetBool("isJumping", false);		
		} else {
			animator.SetBool("isJumping", true);
		}

    }

    private void PerformGroundCheck()
    {
        //if(GroundCheck == null)
        //{
        //    isGrounded = false;
        //    return;
        //}
        isGrounded = GroundCheck.IsTouchingLayers(WhatIsGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGrounded && currentPlanet != null)
            return;
        currentPlanet = collision.gameObject;
        isGrounded = true;
        //nextJumpTime = Time.time + 0.5f;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == currentPlanet)
        {
            currentPlanet = null;
            isGrounded = false;
        }
    }
	void Flip()
	{
		//Debug.Log("switching...");
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
