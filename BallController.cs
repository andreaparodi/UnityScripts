using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public GameObject ball;
	public Rigidbody2D ballRigidBody;

	public float horSpeed;
	public float vertSpeed;

	private int horMovDir;

	public bool onGround;

	public Transform ballBottomPoint;
	public float radius;
	public LayerMask groundLevel;

	void Start () 
	{
		horMovDir = 0;
		ballRigidBody=GetComponent<Rigidbody2D>();
	}
	void Update () 
	{
		
	}
	void FixedUpdate()
	{
		checkControls ();
		groundCheck ();
	}

void checkControls()
	{
		//Vector2 newVel = new Vector2 ();
		//newVel = ballRigidBody.velocity;
		Vector2 force = new Vector2();
		if (Input.GetKey (KeyCode.Space)) 
		{
			//Debug.Log ("jump");
			if (onGround) 
			{
				force.y = vertSpeed;
				ballRigidBody.AddForce (force);
				force.y = 0;
			}
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			//Debug.Log ("left");
			horMovDir = -1;
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			//Debug.Log ("right");
			horMovDir = 1;
		}
		force.x = horSpeed * horMovDir;
		ballRigidBody.AddForce (force);
		//newVel.x = horSpeed * horMovDir;
		//ballRigidBody.velocity = newVel;
		horMovDir = 0;
	}
	void groundCheck()
	{
		onGround = Physics2D.OverlapCircle (ballBottomPoint.position, radius, groundLevel);
	}
	//altri metodi utlizzati in precedenza per controllare se la pallina è per terra o meno 
	/*
	void groundCheck()
	{
		Vector2 ballSpeed = new Vector2 ();
		ballSpeed = ballRigidBody.velocity;
		if (ballSpeed.y == 0) {
			onGround = true;
		} 
		else 
		{
			onGround = false;
		}
	}
	*/
	/*
	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Ground") 
		{
			onGround = true;
			//Debug.Log ("Per terra");
		}
	}
	void OnCollisionExit2D (Collision2D col)
	{
		if (col.gameObject.tag == "Ground") 
		{
			//Debug.Log ("Per aria");
			onGround = false;
		}
	}
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Ground") 
		{
			onGround = true;
			//Debug.Log ("Per terra");
		}
	}
	*/
}



	//Per far ruotare lo sprite occorre togliere la spunta "freeze Z rotation" dal rigid body di "Ball", in quel caso però ruota anche la camera.


