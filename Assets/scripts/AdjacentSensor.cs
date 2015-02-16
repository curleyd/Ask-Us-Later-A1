using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AdjacentSensor : MonoBehaviour {
	
	public float thisDist;
	public float maxRange; // Pie slice
	public float maxDistance; // Adjacent
	public bool debug;
	
	//private RaycastHit2D myHit;
	private Vector3 myDirection;
	//private List<GameObject> hitList; 
	private List<float> distanceList;
	private List<float> angleList; // Adjacent
	private List<float> angleListPie; // Pie slice

	private GameObject[] nonSubjectAgents;

	void Start() {
		maxRange = transform.GetComponent<PieSliceSensor>().maxRange;
		maxDistance = 5f;
		debug = false;
	}

	// Update is called once per frame
	void Update () {

		float yFactor;
		float xFactor;
		float tempAngle, tempDist;
		//hitList = new List<GameObject>();
		distanceList = new List<float>();
		angleList = new List<float>();
		angleListPie = new List<float>();
		//Debug.Log(nonSubjectAgents); 
	
		collider2D.enabled = false;

		// For each degree around the player
		for (int i = 0; i < 360; i++) {

			nonSubjectAgents = GameObject.FindGameObjectsWithTag("Agent");

			// Change x and y factors
			yFactor = Mathf.Sin(i);
			xFactor = Mathf.Cos(i);

			// Turn ray by one degree
			myDirection = (yFactor * transform.up) + (xFactor * transform.right);
			myDirection.Normalize();

			// Determine varrying distance for pie slice
			thisDist = transform.GetComponent<PieSliceSensor>().pieRayDistance(i);

			// Cast ray in this direction
			//myHit = Physics2D.Raycast(transform.position, myDirection, maxDistance);
			Debug.DrawRay(transform.position, maxDistance * myDirection, Color.cyan);

			// Loop over them and determine if their distance is within the radars
			for (int j = 0; j < nonSubjectAgents.Length; j++) {

				// Determine distance and angle from this agent to the player
				tempDist = Vector3.Distance(transform.position, nonSubjectAgents[j].transform.position);
				tempAngle = angleBetween(transform.up, nonSubjectAgents[j].transform.position - transform.position);

				// If we have not checked this agent yet
				if (!angleList.Contains(tempAngle) && !distanceList.Contains(tempDist)) {

					// If within adjacent radar, add it to the list
					if (tempDist <= maxDistance) {
						distanceList.Add( tempDist );
						angleList.Add( tempAngle );
					}

					// If within the pie slice radar, record its angle
					if (tempDist <= thisDist) {
						angleListPie.Add( tempAngle );
					}
				}
			} // end of for j

			// If ray hit something, check if it is a new agent, and if so add it
		/*	if (myHit.collider != null && myHit.collider.gameObject.tag.Equals("Agent")) {
				if (myHit.collider.gameObject.GetComponent<StaticAgentController>().getID() >= 0) {
					if (!hitList.Contains(myHit.collider.gameObject)) {

						hitList.Add( myHit.collider.gameObject );
						distanceList.Add( myHit.distance );
						tempAngle = angleBetween(transform.up, myHit.transform.position);
						angleList.Add( tempAngle );

						// If this agent is also within the pie slice, record its angle
						//Debug.Log("checking if " + myHit.distance + " less than " + thisDist);
						if (myHit.distance <= thisDist) {
							angleListPie.Add( tempAngle );
						}
					}
				}
			} // end of outer if
*/
		} // end of for i

		collider2D.enabled = true;
	
	} // end of Update

	public List<float> getPieAngles() {
		return angleListPie;
	}

	public string returnAdjacentSensorInfo() {

		if (angleList.Count == 0) {
			return "Adjacent = (Empty)";
		}

		string ret = "Adjacent = [";

		for (int i = 0; i < angleList.Count; i++) {
			ret += "(";
			ret += Round(angleList[i], 2); // angle
			ret += ",";
			ret += Round(distanceList[i], 2); // distance
			ret += ")";
			if (i != angleList.Count - 1) {
				ret += ", ";
			}
		}
		ret += "]";

		return ret;
	}

	public float angleBetween(Vector3 from, Vector3 to) {

		float angle = Mathf.DeltaAngle(Mathf.Atan2(from.y, from.x) * Mathf.Rad2Deg,
		                               Mathf.Atan2(to.y, to.x) * Mathf.Rad2Deg);

		if (angle < 0f) {
			angle += 360f;
		}

		return angle;
	}

	public float Round(float value, int digits) {
		float mult = Mathf.Pow(10.0f, (float)digits);
		return Mathf.Round(value * mult) / mult;
	}
}
