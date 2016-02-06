using UnityEngine;
using System.Collections;

public class PPlatformController : MonoBehaviour {
	
	public float platformDistanceX;
	public float platformDistanceY;	
	public GameObject platform;
	
	private GameObject thisPlatform;
	private Vector2 platformPosition;
	private float rotationAngle;
	
	void Start () 
	{
		platform.GetComponent<GameObject>();
		thisPlatform = (GameObject)Instantiate(platform,new Vector2(transform.position.x + platformDistanceX, transform.position.y + platformDistanceY),Quaternion.identity); //sets up platform
	}
	
	void Update () 
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Finds where the mouse is
		Vector3 rayPoint = ray.GetPoint(10);
		Vector2 mousePosition = new Vector2(rayPoint.x,rayPoint.y);
		
		float angleToMouse = Mathf.Atan2(mousePosition.y,mousePosition.x); //Finds the angle between the character and the mouse
		rotationAngle = angleToMouse;
		
		float xPlatformPos = platformDistanceX * Mathf.Cos (angleToMouse); 
		float yPlatformPos = platformDistanceY * Mathf.Sin (angleToMouse);
		//Debug.Log(xPlatformPos);
		//Debug.Log(yPlatformPos);
		
		platformPosition = new Vector2(xPlatformPos,yPlatformPos); // sets the platform where it should go rotation wise
	}
	void FixedUpdate()
	{
		Vector2 playerTransform2D = new Vector2(transform.position.x,transform.position.y); //converts transform.postion to Vector2
		thisPlatform.transform.position = platformPosition + playerTransform2D;
		
		float platformRotation = rotationAngle * 180 / Mathf.PI; //Rotates the platform so that a face is always facing the player
		Vector3 rotation = new Vector3(0.0f,0.0f,platformRotation);
		thisPlatform.transform.rotation = Quaternion.Euler(rotation);
	}
}
