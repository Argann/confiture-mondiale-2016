using UnityEngine;
using System.Collections;

public class PlayerStartPoint : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		GameObject go = GameObject.FindGameObjectWithTag ("Player");
		go.transform.position = this.transform.position;
		Debug.Log ("Je suis là !");
	}
}
