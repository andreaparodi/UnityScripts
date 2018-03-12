	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class BetterPhysics : MonoBehaviour {

		public Rigidbody2D ballRigidBody;
		public BallController bc;

		public float gravityConst;
		public float maxSpeed;
		public float friction;

		void Start () 
		{
			ballRigidBody = GetComponent<Rigidbody2D> ();
			bc = ballRigidBody.GetComponent<BallController> ();
		}

		void Update () 
		{
			
		}
		void FixedUpdate()
		{
			checkMaxSpeed ();
			accelerationGravity ();
			applyFriction ();
		}

		//fissa una velocità massima orizzontale
		void checkMaxSpeed()
		{
			Vector2 newSpeed = new Vector2 ();
			newSpeed = ballRigidBody.velocity;

			if (Mathf.Abs(newSpeed.x) > maxSpeed) 
			{
				newSpeed.x = maxSpeed*Mathf.Sign(newSpeed.x);
				ballRigidBody.velocity = newSpeed;	
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
				//Debug.Log ("accelerating down");
			}
		}
		//serve ad applicare più forza d'attrito, il gameobject scivola troppo altrimenti
		void applyFriction()
		{
			Vector2 speed = new Vector2 ();
			speed = ballRigidBody.velocity;
			//if (Mathf.Abs (speed.x) > 0) 
			//{
			if (!bc.isPressingA && speed.x<0) 
				{
				speed.x = speed.x + friction;
				}
			if (!bc.isPressingD && speed.x>0) 
				{
				speed.x = speed.x - friction;
				}
			ballRigidBody.velocity = speed;
			//}
		}
	}
