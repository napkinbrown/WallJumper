using UnityEngine;
using System.Collections;

public class PPlatformController : MonoBehaviour {
	
	public float radius;
	public GameObject platform;
	public GameObject placedPlatform;
	
	private GameObject thisPlatform;
	private bool canPlacePlatform = true; //true only for testing purposes

	
	void Start () 
	{
		Cursor.visible = false;
		platform.GetComponent<GameObject>();
		thisPlatform = (GameObject)Instantiate(platform,new Vector2(transform.position.x + radius, transform.position.y + radius),Quaternion.identity); //sets up platform
	}
	void FixedUpdate()
	{	
		//Finds where the player and the mouse is on the screen
		Vector2 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
		Vector2 playerPosition = Camera.main.WorldToViewportPoint(transform.position);
		float angleToMouse = Vector2.Angle(playerPosition,mousePosition); //Finds the angle between the character and the mouse
		
		Debug.Log(angleToMouse); //VECTOR2.ANGLE IS WRONG
		
		/* Vector2 platformPosition = new Vector2(xPlatformPos,yPlatformPos); // sets the platform where it should go rotation wise
		Vector2 playerTransform2D = new Vector2(transform.position.x,transform.position.y); //converts transform.postion to Vector2
		thisPlatform.transform.position = platformPosition + playerTransform2D;
		
		float platformRotation = angleToMouse * 180 / Mathf.PI; //Rotates the platform so that a face is always facing the player
		Vector3 rotation = new Vector3(0.0f,0.0f,platformRotation);
		thisPlatform.transform.rotation = Quaternion.Euler(rotation);
		
		if ((canPlacePlatform) && (Input.GetMouseButtonDown(0)))
		{
			Instantiate(placedPlatform,thisPlatform.transform.position,thisPlatform.transform.rotation);
		} */
	}
}
