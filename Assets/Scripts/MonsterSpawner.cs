using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterSpawner : MonoBehaviour {
	
	private Player player;

	private bool activate;
	
	private float aquacreep_cooldown;
	private float groundcreep_cooldown;
	private float darkcreep_cooldown;
	
	public GameObject aquacreep_prefab;
	public GameObject groundcreep_prefab;
	public GameObject darkcreep_prefab;
	
	public Dictionary<int, float> frequency_aquacreep;
	public Dictionary<int, float> frequency_groundcreep;
	public Dictionary<int, float> frequency_darkcreep;

	void Awake(){
		GameObject go = GameObject.FindGameObjectWithTag ("PlayerPrefab");
		this.player = go.transform.Find ("playerLogic").GetComponent<Player> ();
	}
	
	void Start(){

		frequency_aquacreep = new Dictionary<int, float> ();
		frequency_darkcreep = new Dictionary<int, float> ();
		frequency_groundcreep = new Dictionary<int, float> ();
		
		
		for (int i=100; i > 90; i--) {
			frequency_aquacreep.Add(i, 0f);
			frequency_darkcreep.Add(i, 6f);
			frequency_groundcreep.Add(i,8f);
		}

		for (int i=90; i > 80; i--) {
			frequency_aquacreep.Add(i, 30f);
			frequency_darkcreep.Add(i, 15f);
			frequency_groundcreep.Add(i, 6f);
		}

		for (int i=80; i > 70; i--) {
			frequency_aquacreep.Add(i, 20f);
			frequency_darkcreep.Add(i, 15f);
			frequency_groundcreep.Add(i, 8f);
		}

		for (int i=70; i > 60; i--) {
			frequency_aquacreep.Add(i, 9f);
			frequency_darkcreep.Add(i, 22f);
			frequency_groundcreep.Add(i, 9f);
		}
		for (int i=60; i > 50; i--) {
			frequency_aquacreep.Add(i, 5f);
			frequency_darkcreep.Add(i, 30f);
			frequency_groundcreep.Add(i, 10f);
		}
		for (int i=50; i > 40; i--) {
			frequency_aquacreep.Add(i, 4f);
			frequency_darkcreep.Add(i, 35f);
			frequency_groundcreep.Add(i, 12f);
		}
		for (int i=40; i > 30; i--) {
			frequency_aquacreep.Add(i, 4f);
			frequency_darkcreep.Add(i, 40f);
			frequency_groundcreep.Add(i, 15f);
		}
		for (int i=30; i > 20; i--) {
			frequency_aquacreep.Add(i, 4f);
			frequency_darkcreep.Add(i, 0f);
			frequency_groundcreep.Add(i, 15f);
		}
		for (int i=20; i > 10; i--) {
			frequency_aquacreep.Add(i, 4f);
			frequency_darkcreep.Add(i, 0f);
			frequency_groundcreep.Add(i, 0f);
		}
		for (int i=10; i > 0; i--) {
			frequency_aquacreep.Add(i, 8f);
			frequency_darkcreep.Add(i, 0f);
			frequency_groundcreep.Add(i, 0f);
		}

		
		this.aquacreep_cooldown = frequency_aquacreep[player.level];
		this.darkcreep_cooldown = frequency_darkcreep[player.level];
		this.groundcreep_cooldown = frequency_groundcreep[player.level];
		
	}
	
	void Update(){
		if (this.activate) {
			int current_level = player.level;
			//Debug.Log (this.frequency_aquacreep);
		
			this.aquacreep_cooldown -= Time.deltaTime;
			this.darkcreep_cooldown -= Time.deltaTime;
			this.groundcreep_cooldown -= Time.deltaTime;
		
		
			if (this.aquacreep_cooldown <= 0 && frequency_aquacreep [current_level] != 0.0f) {
				GameObject go = Instantiate (this.aquacreep_prefab);
				go.transform.position = this.transform.position;
				this.aquacreep_cooldown = frequency_aquacreep [current_level];
			}
		
			if (this.groundcreep_cooldown <= 0 && frequency_groundcreep [current_level] != 0.0f) {
				GameObject go = Instantiate (this.groundcreep_prefab);
				go.transform.position = this.transform.position;
				this.groundcreep_cooldown = frequency_groundcreep [current_level];
			}
		
			if (this.darkcreep_cooldown <= 0 && frequency_darkcreep [current_level] != 0.0f) {
				GameObject go = Instantiate (this.darkcreep_prefab);
				go.transform.position = this.transform.position;
				this.darkcreep_cooldown = frequency_darkcreep [current_level];
			}
		}
		
	}


	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.CompareTag ("Player")) {
			this.activate = true;
		}
	}

	void OnTriggerExit2D(Collider2D coll){
		if (coll.gameObject.CompareTag ("Player")) {
			this.activate = false;
		}
	}
}
