using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ennemy : MonoBehaviour {

	public int attackPower;
	public int health;
	public float visionRange;
	public float attackRange;
	public Slider healthslider;

	// Use this for initialization
	void Start () {
		GameObject attacktrigger = this.transform.Find ("AttackTrigger").gameObject;
		attacktrigger.GetComponent<BoxCollider2D> ().size = new Vector2 (attackRange, 0.7f);
		GameObject followtrigger = this.transform.Find ("FollowTrigger").gameObject;
		followtrigger.GetComponent<BoxCollider2D> ().size = new Vector2 (visionRange, visionRange);
	}

	void Update() {
		this.healthslider.value = this.health;
	}

	void OnGUI(){
		Vector3 screenPosition = Camera.current.WorldToScreenPoint (transform.position);
		screenPosition.y += 50;
		this.healthslider.transform.position = screenPosition;
	}
}
