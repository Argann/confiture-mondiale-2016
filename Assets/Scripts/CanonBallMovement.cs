using UnityEngine;
using System.Collections;

public class CanonBallMovement : MonoBehaviour {
	private int timeout, timer, rotation;
	// Use this for initialization
	void Start () {
		timeout = 300;
		timer = 0;
		rotation = 0;
	}
	
	// Update is called once per frame
	void Update () {
		rotation = (rotation + 1) % 10;
		if (rotation == 0) {
			transform.localScale = new Vector3 (transform.localScale.x, -transform.localScale.y, transform.localScale.z);
		}
		transform.localPosition = new Vector3 (transform.localPosition.x +0.1f, transform.localPosition.y, 0f);
		timer++;
		if (timer > timeout) {
			Destroy (this.gameObject, 0f);
		}
	}
}
