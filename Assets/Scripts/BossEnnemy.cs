using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossEnnemy : Ennemy {


	// Use this for initialization
	void Start () {
		this.player = GameObject.FindGameObjectWithTag ("Player");
		this.maxHealth = player.GetComponent<Player> ().level * 100;
		this.health = maxHealth;
		GameObject attacktrigger = this.transform.Find ("AttackTrigger").gameObject;
		attacktrigger.GetComponent<BoxCollider2D> ().size = new Vector2 (attackRange, 0.7f);
		GameObject followtrigger = this.transform.Find ("FollowTrigger").gameObject;
		followtrigger.GetComponent<BoxCollider2D> ().size = new Vector2 (visionRange, visionRange);

		this.parent = this.transform.parent.gameObject;
	}

}
