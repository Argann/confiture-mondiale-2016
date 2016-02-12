using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ennemy : MonoBehaviour {

	public int attackPower;
	public int maxHealth;
	protected int health;
	public float visionRange;
	public float attackRange;
	public GameObject healthslider;

	protected GameObject parent;

	protected GameObject player;

	// Use this for initialization
	void Start () {
		this.player = GameObject.FindGameObjectWithTag ("Player");
		this.health = maxHealth;
		GameObject attacktrigger = this.transform.Find ("AttackTrigger").gameObject;
		attacktrigger.GetComponent<BoxCollider2D> ().size = new Vector2 (attackRange, 0.7f);
		GameObject followtrigger = this.transform.Find ("FollowTrigger").gameObject;
		followtrigger.GetComponent<BoxCollider2D> ().size = new Vector2 (visionRange, visionRange);

		this.parent = this.transform.parent.gameObject;
	}

	void FixedUpdate() {
		this.healthslider.transform.position = new Vector3(transform.position.x, transform.position.y + 0.7f);
		this.healthslider.transform.localScale = new Vector3((float)health / maxHealth, 1); 

		if (this.health <= 0) {
			this.player.GetComponent<Player>().KillEnemies(100);
			Destroy(this.parent);
		}
	}

	public void Blesser(int degats){
		this.health -= degats;
		Debug.Log ("T'as perdu : "+ degats);
	}
	
}
