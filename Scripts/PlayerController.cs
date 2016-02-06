using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D rb;

	public float runSpeed;
	public float jumpSpeed;
	
	private bool canJump = true;
	
	void Start () 
	{
		rb.GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
		float running = Input.GetAxis ("Horizontal") * runSpeed * Time.deltaTime; //Horizontal movement
		rb.AddForce(transform.right * running, ForceMode2D.Force);
		
		if (Input.GetButtonDown ("Jump") && canJump == true) //Jumps if able to
		{
			rb.AddForce (transform.up * jumpSpeed, ForceMode2D.Force);
			canJump = false;
		}
		
	}
	void OnCollisionEnter2D (Collision2D other) //Resets jump
	{
		if (other.collider.CompareTag("Boundary"))
			canJump = true;
	}



}
