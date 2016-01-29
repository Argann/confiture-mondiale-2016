using UnityEngine;
using System.Collections;

public class MoveTowardPlayer : MonoBehaviour {

	public GameObject player;

	public float speed;


	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, player.transform.position, step);
	}
}
