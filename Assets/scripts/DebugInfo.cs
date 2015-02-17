using UnityEngine;
using System.Collections;

public class DebugInfo : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("position: " + transform.GetComponent<PlayerAgentController>().myPosition +
		           ", heading: " + transform.GetComponent<PlayerAgentController>().myHeading + "\n" +
				   transform.GetComponent<RaySensor>().returnWallSensorInfo() + " | " +
				   transform.GetComponent<AdjacentSensor>().returnAdjacentSensorInfo() + " | " +
		           transform.GetComponent<PieSliceSensor>().returnPieSensorInfo() );
	}
}
