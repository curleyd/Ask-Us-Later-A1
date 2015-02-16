using UnityEngine;
using System.Collections;

public class RaySensor : MonoBehaviour {

	public float maxDistance = 5f;
	public bool debug = false;

	private RaycastHit2D hitUp;
	private RaycastHit2D hitLeft;
	private RaycastHit2D hitRight;

	private Vector3 upDirection;
	private Vector3 leftDirection;
	private Vector3 rightDirection;

	// Update is called once per frame
	void Update () {

		upDirection = transform.up.normalized;
		leftDirection = transform.up.normalized + -1 * transform.right.normalized;
		leftDirection.Normalize();
		rightDirection = transform.up.normalized + transform.right.normalized;
		rightDirection.Normalize();

		collider2D.enabled = false;  hitUp = Physics2D.Raycast(transform.position, upDirection, maxDistance);
		collider2D.enabled = false;  hitLeft = Physics2D.Raycast(transform.position, leftDirection, maxDistance);
		collider2D.enabled = false;  hitRight = Physics2D.Raycast(transform.position, rightDirection, maxDistance);

		if (debug && (hitUp.collider != null || hitLeft.collider != null || hitRight.collider != null)) {
			Debug.DrawRay(transform.position, maxDistance * upDirection, Color.green);
			Debug.DrawRay(transform.position, maxDistance * leftDirection, Color.green);
			Debug.DrawRay(transform.position, maxDistance * rightDirection, Color.green);
			//Debug.Log("HitUp = " + hitUp.distance + " " + "HitLeft = " + hitLeft.distance + " " + "HitRight = " + hitRight.distance);
		}

		collider2D.enabled = true;

	}

	public string returnWallSensorInfo() {
		float upDist = Round(hitUp.distance, 2);  if (upDist == 0f) { upDist = maxDistance; }
		float leftDist = Round(hitLeft.distance, 2);  if (leftDist == 0f) { leftDist = maxDistance; }
		float rightDist = Round(hitRight.distance, 2);  if (rightDist == 0f) { rightDist = maxDistance; }
		return "Ray = Left " + leftDist + ", Up " + upDist + ", Right " + rightDist;
	}

	public float Round(float value, int digits) {
		float mult = Mathf.Pow(10.0f, (float)digits);
		return Mathf.Round(value * mult) / mult;
	}
}
