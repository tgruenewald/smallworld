using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_movement : MonoBehaviour {
	public float speed;
	public float strength;

	// members needed for animation
	private Animator animator;
	public bool grounded = true;
	private CircleCollider2D groundCheck;
	public LayerMask whatIsGround;
	private bool facingRight = false;

	void Awake(){
		DontDestroyOnLoad (this.gameObject);

	}
	// Use this for initialization
	void Start () {
		groundCheck = GetComponent<CircleCollider2D>();
		Physics.gravity = new Vector3 (0.0f, 0.0f, 0.0f);
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
//		float face = transform.rotation.z;
//		float x = transform.position.x;
//		float y = transform.position.y;
//		float direction = face + 90.0f;
//		if (Input.GetKey(KeyCode.D)) 
//		{
//			
//			float newX = x + direction * .001f;
//			transform.position = new Vector2 (newX, y);
//		}

		if (Input.GetKey(KeyCode.D)) 
		{
			transform.position += transform.right * speed;
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
		if (Input.GetKey (KeyCode.A)) 
		{
			transform.position -= transform.right * speed;
		}
		if (Input.GetKey (KeyCode.W)) 
		{
			transform.position += transform.up * strength;
		}

		// animation control
		grounded = groundCheck.IsTouchingLayers (whatIsGround);
		if (grounded) {
			animator.SetBool("isJumping", false);		
		} else {
			animator.SetBool("isJumping", true);
		}
		if (GetComponent<Rigidbody2D>().velocity.x != 0)
		{
			animator.SetBool("isWalking", true);

		}
		else
		{
			animator.SetBool("isWalking", false);
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
