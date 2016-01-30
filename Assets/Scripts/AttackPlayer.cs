using UnityEngine;
using System.Collections;

public class AttackPlayer : MonoBehaviour {

	void OnTriggerStay2D(Collider2D coll){
		if (coll.gameObject.CompareTag ("Player")) {
			coll.gameObject.GetComponent<Player>().Touched(5);
		}
	}
}
