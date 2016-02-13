using UnityEngine;
using System.Collections;

public class PPlatformController : MonoBehaviour {
	
	public float platformDistanceX;
	public float platformDistanceY;	
	public GameObject platform;
	public GameObject placedPlatform;
	
	private GameObject thisPlatform;
	private Vector2 platformPosition;
	private bool canPlacePlatform = true; //true only for testing purposes

	
	void Start () 
	{
		platform.GetComponent<GameObject>();
		thisPlatform = (GameObject)Instantiate(platform,new Vector2(transform.position.x + platformDistanceX, transform.position.y + platformDistanceY),Quaternion.identity); //sets up platform
	}
	void FixedUpdate()
	{	
		Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Debug.Log(mousePosition);
		float angleToMouse = Vector2.Angle(transform.position,mousePosition); //Finds the angle between the character and the mouse
		//Debug.Log(angleToMouse);

		float xPlatformPos = platformDistanceX * Mathf.Cos (angleToMouse); 
		float yPlatformPos = platformDistanceY * Mathf.Sin (angleToMouse);
		//Debug.Log(xPlatformPos);
		//Debug.Log(yPlatformPos);
		
		platformPosition = new Vector2(xPlatformPos,yPlatformPos); // sets the platform where it should go rotation wise
		Vector2 playerTransform2D = new Vector2(transform.position.x,transform.position.y); //converts transform.postion to Vector2
		thisPlatform.transform.position = platformPosition + playerTransform2D;
		
		float platformRotation = angleToMouse * 180 / Mathf.PI; //Rotates the platform so that a face is always facing the player
		Vector3 rotation = new Vector3(0.0f,0.0f,platformRotation);
		thisPlatform.transform.rotation = Quaternion.Euler(rotation);
		
		if ((canPlacePlatform) && (Input.GetMouseButtonDown(0)))
		{
			Instantiate(placedPlatform,thisPlatform.transform.position,thisPlatform.transform.rotation);
		}
	}
}
