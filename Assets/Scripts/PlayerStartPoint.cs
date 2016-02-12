using UnityEngine;
using System.Collections;

public class PlayerStartPoint : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		GameObject go = GameObject.Find("Player");
		go.transform.position = this.transform.position;
	}
}
