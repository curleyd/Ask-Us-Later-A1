using UnityEngine;
using System.Collections;

public class SpawnAgent : MonoBehaviour {

	public GameObject nonsub;
	public int staticCounter;

	void Start() {
		staticCounter = 0;
	}

	// Update is called once per frame
	void Update () {
	
		// Check for input: Left-mouse click
		if (Input.GetButtonDown("Fire1")) {
			//Debug.Log("Pressed Fire1");
			SpawnMyAgent(0);
		}

		// Check for input: Right-mouse click
		if (Input.GetButtonDown("Fire2")) {
			//Debug.Log("Pressed Fire2");
			SpawnMyAgent(1);
		}

	} // end of Update()

	// Create a non-moving agent at mouse location
	void SpawnMyAgent(int type) {

		// Get the mouse position
		Vector3 mousePos = Input.mousePosition;
		Vector3 objectPos = GetWorldPositionOnPlane(mousePos, 0);

		// Create gameobject at objectPos (0 = static, 1 = dynamic)
		//Instantiate(yourObjectPrefab, objectPos, Quaternion.identity);
		if (type == 0) {
			staticCounter++;
			Instantiate(nonsub, objectPos, Quaternion.identity);
		}
		else {
			//Instantiate(DynamicAgentPrefab, objectPos, Quaternion.identity);
		}

	} // end of SpawnMyAgent

	public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
		Ray ray = Camera.main.ScreenPointToRay(screenPosition);
		Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
		float distance;
		xy.Raycast(ray, out distance);
		return ray.GetPoint(distance);
	}
}
