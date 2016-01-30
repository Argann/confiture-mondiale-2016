using UnityEngine;
using System.Collections;

public class FixedCamera : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate () {
		if (this.transform.position != null && Camera.main.gameObject.transform.position != null) {
			Camera.main.gameObject.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, -10.0f);
		}
	}
}
