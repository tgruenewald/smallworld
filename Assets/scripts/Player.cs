using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UI;

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

    public PointEffector2D gravityEffector;
	public float initialGravityForce;
	public float WHAT_IS_GRAVITY_X;
	public float WHAT_IS_GRAVITY_Y;

    private GameObject spawnPoint;
    private Vector3 startingPosition;

    public string NextTargetSpawnPoint { get; set; }
	GameObject planetSizeDisplay;


    private HashSet<AlienPickup.AlienBodyPartType> alienBodyParts;
    public HashSet<AlienPickup.AlienBodyPartType> GetAlienBodyParts() { return alienBodyParts; }
    public void PickedUpAlienBodyPart(AlienPickup.AlienBodyPartType part)
    {
        alienBodyParts.Add(part);
		Debug.Log ("ADDED ANOTHER BODY PART");
        if (alienBodyParts.Count == 3)
            SwitchLevel.SwitchToLevel(this.gameObject, "Ending", string.Empty, null);
    }

    // Use this for initialization
    void Start ()
    {
		Debug.Log ("STARTING TESTYYYY ----------------------------");
		planetSizeDisplay = GameObject.Find ("PlanetSize");
		planetSizeDisplay.GetComponent<Text> ().text = "SIZE";
		GroundCheck = GetComponent<CircleCollider2D>();
        Camera.main.GetComponent<SmoothCamera>().target = gameObject;
		animator = GetComponent<Animator>();
        gravityEffector = GetComponent<PointEffector2D>();
        initialGravityForce = gravityEffector.forceMagnitude;
        alienBodyParts = new HashSet<AlienPickup.AlienBodyPartType>();
    }
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

	void updatePlanetSize() {
		if (planetSizeDisplay == null) {
			planetSizeDisplay = GameObject.Find ("PlanetSize");
		}
		if (planetSizeDisplay != null) {
			planetSizeDisplay.GetComponent<Text> ().text = currentPlanet.GetComponentInParent<Planet> ().getPlanetSizeText ();
		}

	}

    // Update is called once per frame
    void Update ()
    {
		if (GameState.freeze)
			return;
        PerformGroundCheck();
		DEBUG_GROUNDED = IsGrounded;
		WHAT_IS_GRAVITY_X = Physics2D.gravity.x;
		WHAT_IS_GRAVITY_Y = Physics2D.gravity.y;
		animator.SetBool("isWalking", false);
		if (currentPlanet != null) {
			updatePlanetSize ();
			this.transform.up = -(currentPlanet.transform.position - this.transform.position);
			PlanetGravity currentPlanetGravity = currentPlanet.GetComponentInChildren<PlanetGravity> ();
			if (!float.IsNaN(currentPlanetGravity.ForceScale) && currentPlanetGravity != null) {
				this.gravityEffector.forceMagnitude = initialGravityForce * currentPlanetGravity.ForceScale;
			} else {
				this.gravityEffector.forceMagnitude = initialGravityForce;
			}

			//Vector3 directionToCurrentPlanetCenter = currentPlanet.transform.position - this.transform.position;
			//Quaternion lookAtQuat = Quaternion.LookRotation(directionToCurrentPlanetCenter);
			////this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this)
			//this.transform.rotation = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, (lookAtQuat * Quaternion.Euler(0, 0, 90)).z, this.transform.rotation.w);
		} else {
			Debug.Log ("Can't find planet." + initialGravityForce);
			//this.gravityEffector.forceMagnitude = initialGravityForce;
		}
        
        if (Input.GetKey(KeyCode.D))
        {
            //GetComponent<Rigidbody2D>().AddForce(transform.right * Speed);
            transform.position += transform.right * (Speed * Time.deltaTime);
			if (!facingRight)
            {
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
			if (facingRight)
            {
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
		if (IsGrounded)
        {
			animator.SetBool("isJumping", false);		
		}
        else
        {
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
		Debug.Log ("Colliding");
        if (collision.gameObject.GetComponent<Planet>() == null)
            return;
        if (isGrounded && currentPlanet != null)
            return;
		Debug.Log ("Found a planet");
        currentPlanet = collision.gameObject;
        isGrounded = true;
        //nextJumpTime = Time.time + 0.5f;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == currentPlanet)
        {
			Debug.Log ("OnCollisionExit2D - currentPlanet set to null");
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

    public void SpawnAt(GameObject spawnPoint)
    {
        Camera.main.GetComponent<SmoothCamera>().target = gameObject;
        transform.position = spawnPoint.transform.position;
        this.spawnPoint = spawnPoint;
        this.startingPosition = spawnPoint.transform.position;
    }

    public void Respawn()
    {
        if (spawnPoint == null)
        {
            var spawnPointScript = GameObject.FindObjectOfType<SpawnPoint>();
            if (spawnPoint == null)
            {
                Debug.Log("Unable to find spawn point in level!  Picking arbitrary place.");
                var crystals = GameObject.FindObjectsOfType<crystal>();
                if (crystals.Length > 0)
                {
                    spawnPoint = crystals[0].gameObject;
                }
                else
                {
                    //well, we're screwed.
                }
            }
            else
            {
                spawnPoint = spawnPointScript.gameObject;
            }
        }

        this.transform.position = (spawnPoint == null) ? startingPosition : spawnPoint.transform.position;
        //if (OnPlayerSpawned != null)
        //    OnPlayerSpawned();
    }
}
