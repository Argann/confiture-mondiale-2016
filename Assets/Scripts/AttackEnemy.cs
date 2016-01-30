using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackEnemy : MonoBehaviour {

    public int damageAttack; 

	private List<GameObject> ennemy_list;
	private Player player;



	void Start(){
		this.ennemy_list = new List<GameObject> ();
		this.player = this.transform.parent.gameObject.GetComponent<Player>();
	}

	void OnTriggerEnter2D(Collider2D coll){
      

        if (coll.gameObject.tag == "Ennemy" && coll.gameObject.transform.GetComponent<Ennemy>() != null) {
			this.ennemy_list.Add (coll.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D coll){
		if (coll.gameObject.tag == "Ennemy" && coll.gameObject.transform.GetComponent<Ennemy>() != null) {
			this.ennemy_list.Remove (coll.gameObject);
		}

	}

	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log("LELEL");
			foreach(GameObject enemy in this.ennemy_list){
				/*if(enemy == null){
					this.ennemy_list.Remove(enemy);
				} else {
					enemy.GetComponent<Ennemy>().Blesser(damageAttack);
				}*/
                if(enemy != null){
                    enemy.GetComponent<Ennemy>().Blesser(damageAttack);
                }
			}
		}
	}
}
