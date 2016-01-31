using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackEnemy : MonoBehaviour {

    public int damageAttack;
    public float cooldown = 1f;
    [HideInInspector] // Hides var below
    public float cooldownT ;
    public float cooldowncac = 0.2f;
    [HideInInspector] // Hides var below
    public float cooldowncacT;

    private List<GameObject> ennemy_list;
	private Player player;



	void Start(){
		this.ennemy_list = new List<GameObject> ();
		this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        cooldownT = cooldown;
        cooldowncacT = cooldowncac;
    }

	void OnTriggerEnter2D(Collider2D coll){
		//int idAttack = GameObject.Find("JoueurPrefab").GetComponent<JoueurManager>().idAttack ;
        if (coll.gameObject.tag == "Ennemy" && coll.gameObject.transform.GetComponent<Ennemy>() != null) {
			this.ennemy_list.Add (coll.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D coll){
		//int idAttack = GameObject.Find("JoueurPrefab").GetComponent<JoueurManager>().idAttack ;
		if (coll.gameObject.tag == "Ennemy" && coll.gameObject.transform.GetComponent<Ennemy>() != null) {
			this.ennemy_list.Remove (coll.gameObject);
		}
	}

	void Update(){
		this.transform.position = GameObject.FindGameObjectWithTag ("Player").transform.position;
		int idAttack = GameObject.Find("JoueurPrefab").GetComponent<JoueurManager>().idAttack ;
		cooldownT -= Time.deltaTime;
        cooldowncacT -= Time.deltaTime;

        if (Input.GetMouseButtonDown (1) && cooldownT <= 0) {
			if (idAttack == 0)
                this.player.arms_animator.SetBool("isAttackingCac", true);
            else if (idAttack == 2)
				this.player.arms_animator.SetBool ("isAttackingCircle", true);

            cooldownT = cooldown;
			List<GameObject> ennemy_list2 = new List<GameObject> (this.ennemy_list);
			foreach (GameObject enemy in ennemy_list2) {
				if (enemy != null) {
					enemy.GetComponent<Ennemy> ().Blesser (damageAttack);
				} else {
					this.ennemy_list.Remove (enemy);
				}
			}

		}
        else if (cooldowncacT <= 0 && Input.GetMouseButtonDown(0))
        {
            this.player.arms_animator.SetBool("isAttackingCac", true);
            cooldowncacT = cooldowncac;

            List<GameObject> ennemy_list2 = new List<GameObject>(this.ennemy_list);
            foreach (GameObject enemy in ennemy_list2)
            {
                if (enemy != null)
                {
                    enemy.GetComponent<Ennemy>().Blesser(damageAttack);
                }
                else
                {
                    this.ennemy_list.Remove(enemy);
                }
            }
        }
		if ((cooldownT <= cooldown - 0.2f || Input.GetMouseButtonUp (1)) && (cooldowncacT <= cooldowncac - 0.2f || Input.GetMouseButtonUp(0))) {
			this.player.arms_animator.SetBool ("isAttackingCac", false);
			this.player.arms_animator.SetBool ("isAttackingCircle", false);
		}
    }
}
