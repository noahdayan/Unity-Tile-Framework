using UnityEngine;
using System.Collections;

public class ArrowKeysMove : MonoBehaviour {

	public float speed = 20.0f;
	public float scrollSpeed = 100.0f;
	public Vector2 xRange;
	public Vector2 yRange;
	public Vector2 zRange;
	
	int mDelta = 10; // Pixels. The width border at the edge in which the movement work	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		Vector3 tempPos = transform.position;
		float temp;
		
		// Time.deltaTime corrects for errors with the framerate, otherwise it's a pain.
		temp = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		tempPos.x += temp;
		tempPos.z += temp;
		
		//Checking range.
		if(xRange.y < tempPos.x && tempPos.x < xRange.x)
		{
			newPosition.x += temp;
		}
		if(zRange.y < tempPos.z && tempPos.z < zRange.x)
		{
			newPosition.z += temp;
		}
		temp = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		tempPos.z += temp;
		tempPos.x -= temp;
		if(zRange.y < tempPos.z && tempPos.z < zRange.x)
		{
			newPosition.z += temp;
		}
		if(xRange.y < tempPos.x && tempPos.x < xRange.x)
		{
			newPosition.x -= temp;
		}
		temp = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime;
		tempPos.z += temp;
		tempPos.x -= temp;
		if(zRange.y < tempPos.z && tempPos.z < zRange.x)
		{
			newPosition.z += temp;
		}
		if(xRange.y < tempPos.x && tempPos.x < xRange.x)
		{
			newPosition.x -= temp;
		}
		temp = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime;
		tempPos.y -= temp;
		if(yRange.y < tempPos.y && tempPos.y < yRange.x)
		{
			newPosition.y -= temp;
		}
		transform.position = newPosition;
			
		//MOUSE MOVEMENT
		//~~~HORIZONTAL~~~
		//Move Camera Right, and check if it's in range
		if ( Input.mousePosition.x >= Screen.width - mDelta 
			/*&& xRange.y < transform.position.x*/ && transform.position.x < xRange.x
			/*&& zRange.y < transform.position.z*/ && transform.position.z < zRange.x)
	    {
        	// Move the camera
        	transform.position += (Vector3.forward + Vector3.right) * Time.deltaTime * speed;
		}
		//Move Camera Left, and check if it's in range
		if (Input.mousePosition.x <= mDelta 
			&& xRange.y < transform.position.x /*&& transform.position.x < xRange.x*/
			&& zRange.y < transform.position.z /*&& transform.position.z < zRange.x*/)
		{
			transform.position += (Vector3.back + Vector3.left) * Time.deltaTime * speed;
		}
		//~~~VERTICAL~~~
		//Move Camera Up, and check if it's in range
		if (Input.mousePosition.y >= Screen.height - mDelta
			/*&& zRange.y < transform.position.z*/ && transform.position.z < zRange.x 
			&& xRange.y < transform.position.x /*&& transform.position.x < xRange.x*/
			)
		{
			transform.position += (Vector3.forward + Vector3.left) * Time.deltaTime * speed;
		}
		//Move Camera Down, and check if it's in range
		if (Input.mousePosition.y < mDelta
			&& zRange.y < transform.position.z /*&& transform.position.z < zRange.x*/
			/*&& xRange.y < transform.position.x*/ && transform.position.x < xRange.x)
		{
			transform.position += (Vector3.back + Vector3.right) * Time.deltaTime * speed;
		}	
	}
}
