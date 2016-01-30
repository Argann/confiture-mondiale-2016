using UnityEngine;
using System.Collections;

public class RotateTowardPlayer : MonoBehaviour {

	private GameObject player;
	public float speed;
	private bool go;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (go) {
			Vector3 dir = player.transform.position - transform.position;
			float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.CompareTag ("Player")) {
			go = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll){
		if (coll.gameObject.CompareTag ("Player")) {
			go = false;
		}
	}
}
