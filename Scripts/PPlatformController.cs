using UnityEngine;
using System.Collections;

public class PPlatformController : MonoBehaviour {

	public float platformDistanceX;
	public float platformDistanceY;	
	public GameObject platform;

	private GameObject thisPlatform;
	private Vector2 platformPosition;
	
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
		
		float xPlatformPos = platformDistanceX * Mathf.Cos (angleToMouse); 
		float yPlatformPos = platformDistanceY * Mathf.Sin (angleToMouse);
		Debug.Log(xPlatformPos);
		Debug.Log(yPlatformPos);
		
		platformPosition = new Vector2(xPlatformPos,yPlatformPos);
	}
	void FixedUpdate()
	{
		thisPlatform.transform.position = platformPosition;
	}
}
