using UnityEngine;
using System.Collections;

public class DebugInfo : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		Debug.Log( transform.GetComponent<RaySensor>().returnWallSensorInfo() 
				 + transform.GetComponent<AdjacentSensor>().returnAdjacentSensorInfo() );
					// + returnPieSensorInfo
	}
}
