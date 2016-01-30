using UnityEngine;
using System.Collections;

public class AttackPlayer : MonoBehaviour {

	public GameObject attackCollider;

	public bool ennemyOnSight;

	public void Start(){
		this.ennemyOnSight = false;
	}

	void OnTriggerEnter2D(Collider2D coll){

		Debug.Log ("Entrée de...");

		if (coll.gameObject.CompareTag ("Player")) {
			Debug.Log("Joueur !");
			this.ennemyOnSight = true;
			this.attackCollider.SetActive(true);
		}
	}

	void OnTriggerExit2D(Collider2D coll){
		Debug.Log ("Sortie de...");

		if (coll.gameObject.CompareTag ("Player")) {
			Debug.Log ("Joueur ! ");

			this.ennemyOnSight = false;
			this.attackCollider.SetActive(false);
		}
	}
}
