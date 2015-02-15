using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AdjacentSensor : MonoBehaviour {

	public float maxDistance = 10f;
	public bool debug = true;
	
	private RaycastHit2D myHit;
	private Vector3 myDirection;
	private List<GameObject> hitList; 
	private List<float> distanceList;

	// Update is called once per frame
	void Update () {

		float yFactor;
		float xFactor;
		hitList = new List<GameObject>();
		distanceList = new List<float>();
	
		collider2D.enabled = false;

		for (int i = 0; i < 360; i++) {

			// Change x and y factors
			yFactor = Mathf.Sin(i);
			xFactor = Mathf.Cos(i);

			// Turn ray by one degree
			myDirection = (yFactor * transform.up) + (xFactor * transform.right);

			// Cast ray in this direction
			myHit = Physics2D.Raycast(transform.position, myDirection, maxDistance);
			Debug.DrawRay(transform.position, myDirection, Color.cyan);

			// If ray hit something, check if it is a new agent, and if so add it
			if (myHit.collider != null) {
				if (myHit.collider.gameObject.GetComponent<StaticAgentController>().getID() >= 0) {
					if (!hitList.Contains(myHit.collider.gameObject)) {
						hitList.Add(myHit.collider.gameObject);
						distanceList.Add(myHit.distance);
					}
				}
			}

		}

		collider2D.enabled = true;
	}

	public string returnAdjacentSensorInfo() {

		if (hitList.Count == 0) {
			return " | Adjacent = (Empty)";
		}

		string ret = " | Adjacent = [";

		for (int i = 0; i < hitList.Count; i++) {
			ret += "(";
			ret += Round(angleBetween(transform.up, hitList[i].transform.position), 2); // angle
			ret += ",";
			ret += Round(distanceList[i], 2); // distance
			ret += ")";
			if (i != hitList.Count - 1) {
				ret += ", ";
			}
		}
		ret += "]";

		return ret;
	}

	public float angleBetween(Vector3 from, Vector3 to) {

		float angle = Mathf.DeltaAngle(Mathf.Atan2(from.y, from.x) * Mathf.Rad2Deg,
		                               Mathf.Atan2(to.y, to.x) * Mathf.Rad2Deg);
		//angle -= 90f;

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
