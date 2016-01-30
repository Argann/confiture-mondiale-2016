using UnityEngine;
using System.Collections;

public class RotateTowardPlayer : MonoBehaviour {

	private GameObject player;
	private GameObject parent;
	private bool go;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		parent = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (go) {
			Vector3 dir = player.transform.position - parent.transform.position;
			float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			parent.transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
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
