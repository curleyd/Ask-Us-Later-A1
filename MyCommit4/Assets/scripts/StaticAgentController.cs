using UnityEngine;
using System.Collections;

public class StaticAgentController : MonoBehaviour {

	public int myID;
	public Vector3 myPosition;
	public Vector3 myHeading;

	// Use this for initialization
	void Start () {
		myID = Camera.main.GetComponent<SpawnAgent>().staticCounter;
	}
	
	// Update is called once per frame
	void Update () {

		// Update heading and position
		myPosition = transform.position;
		myHeading = transform.up;

	}

	public int getID() {
		return myID;
	}
}
