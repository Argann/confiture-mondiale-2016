﻿using UnityEngine;
using System.Collections;

public class MoveTowardPlayer : MonoBehaviour {

	public float speed;

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
			float step = speed * Time.deltaTime;
			parent.transform.position = Vector3.MoveTowards (parent.transform.position, player.transform.position, step);
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
