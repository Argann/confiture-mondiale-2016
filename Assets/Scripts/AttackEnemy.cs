using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackEnemy : MonoBehaviour {

    public int damageAttack;
    public float cooldown = 1f;
    private float cooldownT ;


    private List<GameObject> ennemy_list;
	private Player player;



	void Start(){
		this.ennemy_list = new List<GameObject> ();
		this.player = this.transform.parent.gameObject.GetComponent<Player>();
        cooldownT = cooldown;
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
        cooldownT -= Time.deltaTime;

		if (Input.GetMouseButtonDown (0) && cooldownT <= 0) {
            cooldownT = cooldown;
            List<GameObject> ennemy_list2 = new List<GameObject>(this.ennemy_list);

            foreach (GameObject enemy in ennemy_list2){
                if(enemy != null){
                    enemy.GetComponent<Ennemy>().Blesser(damageAttack);
                } else {
                    this.ennemy_list.Remove(enemy);
                }
			}
		}
	}
}
