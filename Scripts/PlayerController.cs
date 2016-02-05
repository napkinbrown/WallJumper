using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D rb;

	public float runSpeed;
	public float jumpSpeed;
	
	public float platformDistanceX;
	public float platformDistanceY;	
	public GameObject platform;
	
	private bool canJump = true;
	
	void Start () 
	{
		rb.GetComponent<Rigidbody2D> ();
		platform.GetComponent<GameObject>();
		
		Instantiate(platform,new Vector2(transform.position.x + platformDistanceX, transform.position.y + platformDistanceY),Quaternion.identity); //sets up platform
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
		
		PlatformUpdate();
	}
	void OnCollisionEnter2D (Collision2D other) //Resets jump
	{
		if (other.collider.CompareTag("Boundary"))
			canJump = true;
	}
	private void PlatformUpdate() //Takes the position of the mouse and sets the player platform to that position but on a set radius
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Finds where 
		//Debug.Log(ray);
	}


}
