using UnityEngine;
using System.Collections;

public class SpawnAgent : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	
		// Check for input: Left-mouse click
		if (Input.GetButtonDown("Fire1")) {
			Debug.Log("Pressed Fire1");
			SpawnMyAgent(0);
		}

		// Check for input: Right-mouse click
		if (Input.GetButtonDown("Fire2")) {
			Debug.Log("Pressed Fire2");
			SpawnMyAgent(1);
		}

	} // end of Update()

	// Create a non-moving agent at mouse location
	void SpawnMyAgent(int type) {

		// Get the mouse position
		Vector3 mousePos = Input.mousePosition;
		Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);

		// Create gameobject at objectPos (0 = static, 1 = dynamic)
		//Instantiate(yourObjectPrefab, objectPos, Quaternion.identity);
		if (type == 0) {
			//Instantiate(StaticAgentPrefab, objectPos, Quaternion.identity);
		}
		else {
			//Instantiate(DynamicAgentPrefab, objectPos, Quaternion.identity);
		}

	} // end of SpawnMyAgent
}
