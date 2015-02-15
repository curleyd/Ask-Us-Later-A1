using UnityEngine;
using System.Collections;

public class PlayerAgentController : MonoBehaviour {
	
	public int myID;
	public float turnSpeed;
	public float moveSpeed;
	public Vector3 myPosition;
	public Vector3 myHeading;

	// Use this for initialization
	void Start () {
		myID = -1;
		turnSpeed = 100f;
		moveSpeed = 5f;
	}


	// Update is called once per frame
	void Update () {

		// Update heading and position
		myPosition = transform.position;
		myHeading = transform.up;

		// Check for key presses
		checkForInput ();

	} // end of Update()


	// Check for valid key presses (W,S,A,D) and move or turn accordingly
	void checkForInput() {

		// this is how to move
		//transform.Translate(+/- Vector3.up * moveSpeed * Time.deltaTime);
		
		// Check for input: W = Forwards
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
		}
		
		// Check for input: S = Backwards
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate(-Vector3.up * moveSpeed * Time.deltaTime);
		}

		// this is how to rotate in 2D
		//transform.Rotate(Vector3.forward, +/- turnSpeed * Time.deltaTime);
		
		// Check for input: A = Turn left
		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
		}
		
		// Check for input: D = Turn right
		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
		}
	
	} // end of checkForInput()

	public Vector3 GetHeading() {
		return myHeading;
	}
}
