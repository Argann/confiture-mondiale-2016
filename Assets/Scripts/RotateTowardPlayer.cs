using UnityEngine;
using System.Collections;

public class RotateTowardPlayer : MonoBehaviour {

	public GameObject player;
	public float speed;
	
	// Update is called once per frame
	void Update () {

		Vector3 dir = player.transform.position - transform.position;
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);


	}
}
