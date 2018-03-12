using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterPhysics : MonoBehaviour {

	public Rigidbody2D ballRigidBody;

	public float gravityConst;
	public float maxSpeed;

	void Start () 
	{
		ballRigidBody = GetComponent<Rigidbody2D> ();
	}

	void Update () 
	{
	}
	void FixedUpdate()
	{
		checkMaxSpeed ();
		accelerationGravity ();
	}

	//fissa una velocità massima orizzontale
	void checkMaxSpeed()
	{
		Vector2 newVel = new Vector2 ();
		newVel = ballRigidBody.velocity;

		if (Mathf.Abs(newVel.x) > maxSpeed) 
		{
			newVel.x = maxSpeed*Mathf.Sign(newVel.x);
			ballRigidBody.velocity = newVel;	
		}
	}

	void accelerationGravity()
	{
		Vector2 newSpeed = new Vector2 ();
		newSpeed = ballRigidBody.velocity;
		if (newSpeed.y < 0) 
		{
			newSpeed.y = newSpeed.y - gravityConst * Time.deltaTime;
			ballRigidBody.velocity = newSpeed;
			Debug.Log ("accelerating down");
		}
	}
}
