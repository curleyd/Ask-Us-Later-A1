using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PieSliceSensor : MonoBehaviour {

	public float maxRange = 5f;
	public float forwardBoundaryAngle;
	public float sideBoundaryAngle;

	public float upPie; // activation levels
	public float downPie;
	public float leftPie;
	public float rightPie;

	public int upCount; // number in each slice
	public int downCount;
	public int leftCount;
	public int rightCount;

	private List<float> anglesList;

	// Use this for initialization
	void Start () {
		upPie = 0f;  downPie = 0f;  leftPie = 0f;  rightPie = 0f;
		upCount = 0;  downCount = 0;  leftCount = 0;  rightCount = 0;
		forwardBoundaryAngle = 90f;
		sideBoundaryAngle = 180f - forwardBoundaryAngle;
	}
	
	// Update is called once per frame
	void Update () {

		upPie = 0f;  downPie = 0f;  leftPie = 0f;  rightPie = 0f;
		upCount = 0;  downCount = 0;  leftCount = 0;  rightCount = 0;
		/*
		float temp1 = forwardBoundaryAngle / 2f;
		float temp2 = 90f + (sideBoundaryAngle/2f);
		float temp3 = 180f + (forwardBoundaryAngle / 2f);
		float temp4 = 270f + (sideBoundaryAngle / 2f);

		Quaternion p1 = Quaternion.AngleAxis(temp1, transform.up);
		Quaternion p2 = Quaternion.AngleAxis(temp2, transform.up);
		Quaternion p3 = Quaternion.AngleAxis(temp3, transform.up);
		Quaternion p4 = Quaternion.AngleAxis(temp4, transform.up);

		Vector3 pie1 = new Vector3 (p1[0], p1[1], 0);
		Vector3 pie2 = new Vector3 (p2[0], p2[1], 0);
		Vector3 pie3 = new Vector3 (p3[0], p3[1], 0);
		Vector3 pie4 = new Vector3 (p4[0], p4[1], 0);

		Debug.DrawRay(transform.position, maxRange * pie1, Color.magenta);
		Debug.DrawRay(transform.position, maxRange * pie2, Color.magenta);
		Debug.DrawRay(transform.position, maxRange * pie3, Color.magenta);
		Debug.DrawRay(transform.position, maxRange * pie4, Color.magenta);
		*/
		// First get angles list from the adjacent sensor
		anglesList = transform.GetComponent<AdjacentSensor>().getPieAngles();

		// Then loop over all angles and determine activaion level for each quadrant
		if (anglesList != null) {
			for (int i = 0; i < anglesList.Count; i++) {

				//Debug.Log("checking: " + anglesList[i] + " ...");

				// left quadrant
				if (anglesList[i] >= (forwardBoundaryAngle / 2f) &&
				    anglesList[i] < 90f + (sideBoundaryAngle / 2f)) {
					leftCount++;
					//Debug.Log(anglesList[i] + " is between " + temp1 + " and " + temp2);
				}

				// down quadrant
				else if (anglesList[i] >= 90f + (sideBoundaryAngle / 2f) &&
				         anglesList[i] < 180f + (forwardBoundaryAngle / 2f)) {
					downCount++;
					//Debug.Log(anglesList[i] + " is between " + temp2 + " and " + temp3);
				}

				// right quadrant
				else if (anglesList[i] >= 180f + (forwardBoundaryAngle / 2f) &&
				         anglesList[i] < 270f + (sideBoundaryAngle / 2f)){
					rightCount++;
					//Debug.Log(anglesList[i] + " is between " + temp3 + " and " + temp4);
				}

				// up quadrant
				else {
					upCount++;
					//Debug.Log(anglesList[i] + " is between " + temp4 + " and " + temp1);
				}

			} // end of for i

			// Determine activation levels based on number of agents in each slice
			if (anglesList.Count > 0) {
				upPie = ((float)upCount) / anglesList.Count;
				downPie = ((float)downCount) / anglesList.Count;
				leftPie = ((float)leftCount) / anglesList.Count;
				rightPie = ((float)rightCount) / anglesList.Count;
			}

		} // end of if anglesList != null

	} // end of Update

	// Given the angle, determine how long the raycast should be
	public float pieRayDistance(float angle) {

		float discreteAngle, myAngle, temp;
		float saveAngle = angle;
		angle = angle % 180f;


		if ( (angle >= 0f && angle < sideBoundaryAngle / 2f) ||
		     (angle >= 90f + (forwardBoundaryAngle / 2f) && angle < 180f) ){
			myAngle = 90f - (sideBoundaryAngle / 2f);
			discreteAngle = saveAngle % (sideBoundaryAngle / 2f);
		}

		else {
			myAngle = 90f - (forwardBoundaryAngle / 2f);
			discreteAngle = saveAngle % (forwardBoundaryAngle / 2f);
		}

		temp = Mathf.Abs( maxRange *  Mathf.Sin(myAngle) / Mathf.Sin(180f - (myAngle + discreteAngle)) );
		return Mathf.Min(temp, maxRange) ;

	}

	public string returnPieSensorInfo() {
		return "Pie = Right " + rightPie + ", Up " + upPie + ", Left " + leftPie + ", Down " + downPie;
	}
}
