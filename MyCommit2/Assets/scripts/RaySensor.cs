using UnityEngine;
using System.Collections;

public class RaySensor : MonoBehaviour {

	public float maxDistance = 5f;

	// Update is called once per frame
	void Update () {

		collider2D.enabled = false;
		RaycastHit2D hitUp = Physics2D.Raycast(transform.position, transform.up, maxDistance);
		RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, transform.up + -1 * transform.right, maxDistance);
		RaycastHit2D hitRight = Physics2D.Raycast(transform.position, transform.up + transform.right, maxDistance);

		if (hitUp.collider != null || hitLeft.collider != null || hitRight.collider != null) {
			Debug.DrawRay(transform.position, transform.up, Color.green);
			Debug.Log("HitUp = " + hitUp.distance + " " + "HitLeft = " + hitLeft.distance + " " + "HitRight = " + hitRight.distance);

		}

		Debug.DrawRay(transform.position, Vector3.Normalize(transform.up)*(maxDistance+1), Color.green, 0);
		Debug.DrawRay(transform.position, Vector3.Normalize(transform.up + -1 * transform.right)*(maxDistance+1), Color.green, 0);
		Debug.DrawRay(transform.position, Vector3.Normalize(transform.up + transform.right)*(maxDistance+1), Color.green, 0);


		collider2D.enabled = true;


	}
}
