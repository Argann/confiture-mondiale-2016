using UnityEngine;
using System.Collections;

public class CanonBallMovement : MonoBehaviour {
	private int timeout, timer;
	// Use this for initialization
	void Start () {
		timeout = 100;
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = new Vector3 (transform.localPosition.x +0.1f, transform.localPosition.y, 0f);
		timer++;
		if (timer > timeout) {
			Destroy (this.gameObject, 0f);
		}
	}
}
