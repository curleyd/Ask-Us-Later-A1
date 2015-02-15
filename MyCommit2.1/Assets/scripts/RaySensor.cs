using UnityEngine;
using System.Collections;

public class RaySensor : MonoBehaviour {

	public float maxDistance = 5f;
	public bool debug = true;

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
			Debug.Log("HitUp = " + hitUp.distance + " " + "HitLeft = " + hitLeft.distance + " " + "HitRight = " + hitRight.distance);
		}

		collider2D.enabled = true;

	}

	public string returnWallSensorInfo() {
		return "HitUp = " + hitUp.distance + " " + "HitLeft = " + hitLeft.distance + " " + "HitRight = " + hitRight.distance;
	}
}
