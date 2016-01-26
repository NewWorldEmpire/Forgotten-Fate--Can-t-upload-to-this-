using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	//NOTE: If the public float, speed, is too high, the player may experience some serious turbulance! Player may 
	//fly through solid objects or other objects not otherwise meant to be passable.
	
	public float speed;
	private Vector3 targetPosition;
	private bool isMoving;
	//const int LEFT_MOUSE_BUTTON = 0;
	void start()
	{
		targetPosition = transform.position;
		isMoving = false;
	}
	
	// Character controller - the mouse will always override the keypad. Also, this control type does not
	// apply to X and Y cordinates but X and Z coordinates. To change, switch the "forward" function to 
	// "up" and the "back" function to "down." Rotation of camera may also affect the control. 
	
	void Update()
	{
		
		// Only when left mouse button is not clicked, will the WSAD controls work.
		//if (!Input.GetKey(KeyCode.Mouse0)) 
		if (isMoving == false)
		{
			//WSAD control
			if (Input.GetKey(KeyCode.D))
			{
				//GetComponent<Rigidbody>().AddForce(Vector2.right * speed);

				transform.Translate(Vector3.forward * speed * Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.A))
			{
				//GetComponent<Rigidbody>().AddForce(Vector2.left * speed);
				transform.Translate(Vector3.back * speed * Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.W))
			{
				//GetComponent<Rigidbody>().AddForce(Vector3.forward * speed);
				transform.Translate(Vector2.left * speed * Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.S))
			{
				//GetComponent<Rigidbody>().AddForce(Vector3.back * speed);
				transform.Translate(Vector2.right * speed * Time.deltaTime);
			}
		}
		if (Input.GetKey (KeyCode.Mouse0)) 
			//if (Input.GetMouseButton (LEFT_MOUSE_BUTTON))
		{
			SetTargetPosition();  
			
			if (isMoving)
				movePlayer(); 
		}  
		if (!Input.GetKey (KeyCode.Mouse0)) 
		{
			isMoving = false;
		}
	}
	
	void SetTargetPosition()
	{
		Plane plane = new Plane (Vector3.up, transform.position);
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
		float point = 0f;
		
		if (plane.Raycast (ray, out point))
			targetPosition = ray.GetPoint(point); 
		
		isMoving = true;
	}
	
	void movePlayer()
	{
		//GetComponent<Rigidbody> ().AddForce (transform.positin, targetPosition * speed * Time.deltaTime);
		
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); 
		
		//once player reaches the target position, the player will stop moving, and the WASD controls will once again work 
		if (transform.position == targetPosition)    
			isMoving = false;
		
		Debug.DrawLine (transform.position, targetPosition, Color.red); 
	}
}

