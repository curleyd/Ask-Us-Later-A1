using UnityEngine;
using System.Collections;

public class RaySensor : MonoBehaviour {

	public float maxDistance = 5f;
	public bool debug = false;

	private RaycastHit2D hitUp;
	private RaycastHit2D hitLeft;
	private RaycastHit2D hitRight;

	// Update is called once per frame
	void Update () {

		collider2D.enabled = false;

		hitUp = Physics2D.Raycast(transform.position, transform.up, maxDistance);
		hitLeft = Physics2D.Raycast(transform.position, transform.up + -1 * transform.right, maxDistance);
		hitRight = Physics2D.Raycast(transform.position, transform.up + transform.right, maxDistance);

		if (debug && (hitUp.collider != null || hitLeft.collider != null || hitRight.collider != null)) {
			Debug.DrawRay(transform.position, transform.up, Color.green);
			Debug.DrawRay(transform.position, transform.up + -1 * transform.right, Color.green);
			Debug.DrawRay(transform.position, transform.up + transform.right, Color.green);
			Debug.Log("HitUp = " + hitUp.distance + " " + "HitLeft = " + hitLeft.distance + " " + "HitRight = " + hitRight.distance);
		}

		collider2D.enabled = true;

	}

	public string returnWallSensorInfo() {
		float upDist = Round(hitUp.distance, 2);
		float leftDist = Round(hitLeft.distance, 2);
		float rightDist = Round(hitRight.distance, 2);
		return "HitUp = " + upDist + " " + "HitLeft = " + leftDist + " " + "HitRight = " + rightDist;
	}

	public float Round(float value, int digits) {
		float mult = Mathf.Pow(10.0f, (float)digits);
		return Mathf.Round(value * mult) / mult;
	}
}
