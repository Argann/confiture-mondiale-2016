using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterSpawner : MonoBehaviour {
	
	public Player player;
	
	private float aquacreep_cooldown;
	private float groundcreep_cooldown;
	private float darkcreep_cooldown;
	
	public GameObject aquacreep_prefab;
	public GameObject groundcreep_prefab;
	public GameObject darkcreep_prefab;
	
	public Dictionary<int, float> frequency_aquacreep;
	public Dictionary<int, float> frequency_groundcreep;
	public Dictionary<int, float> frequency_darkcreep;
	
	void Start(){
		Debug.Log ("Start 1");
		frequency_aquacreep = new Dictionary<int, float> ();
		frequency_darkcreep = new Dictionary<int, float> ();
		frequency_groundcreep = new Dictionary<int, float> ();
		
		
		for (int i=100; i > 90; i--) {
			frequency_aquacreep.Add(i, 1f);
			frequency_darkcreep.Add(i, 0f);
			frequency_groundcreep.Add(i, 0f);
		}
		for (int i=90; i > 80; i--) {
			frequency_aquacreep.Add(i, 1f);
			frequency_darkcreep.Add(i, 0f);
			frequency_groundcreep.Add(i, 2f);
		}
		for (int i=80; i > 70; i--) {
			frequency_aquacreep.Add(i, 0.8f);
			frequency_darkcreep.Add(i, 1.5f);
			frequency_groundcreep.Add(i, 2f);
		}
		for (int i=70; i > 60; i--) {
			frequency_aquacreep.Add(i, 1f);
			frequency_darkcreep.Add(i, 1f);
			frequency_groundcreep.Add(i, 2f);
		}
		for (int i=60; i > 50; i--) {
			frequency_aquacreep.Add(i, 1f);
			frequency_darkcreep.Add(i, 1f);
			frequency_groundcreep.Add(i, 2f);
		}
		for (int i=50; i > 40; i--) {
			frequency_aquacreep.Add(i, 1f);
			frequency_darkcreep.Add(i, 1f);
			frequency_groundcreep.Add(i, 2f);
		}
		for (int i=40; i > 30; i--) {
			frequency_aquacreep.Add(i, 1f);
			frequency_darkcreep.Add(i, 1f);
			frequency_groundcreep.Add(i, 2f);
		}
		for (int i=30; i > 20; i--) {
			frequency_aquacreep.Add(i, 1f);
			frequency_darkcreep.Add(i, 1f);
			frequency_groundcreep.Add(i, 2f);
		}
		for (int i=20; i > 10; i--) {
			frequency_aquacreep.Add(i, 1f);
			frequency_darkcreep.Add(i, 1f);
			frequency_groundcreep.Add(i, 2f);
		}
		for (int i=10; i > 0; i--) {
			frequency_aquacreep.Add(i, 1f);
			frequency_darkcreep.Add(i, 1f);
			frequency_groundcreep.Add(i, 2f);
		}

		
		this.aquacreep_cooldown = frequency_aquacreep[player.level];
		this.darkcreep_cooldown = frequency_darkcreep[player.level];
		this.groundcreep_cooldown = frequency_groundcreep[player.level];
		
	}
	
	void Update(){
		
		int current_level = player.level;
		//Debug.Log (this.frequency_aquacreep);
		
		this.aquacreep_cooldown -= Time.deltaTime;
		this.darkcreep_cooldown -= Time.deltaTime;
		this.groundcreep_cooldown -= Time.deltaTime;
		
		
		if (this.aquacreep_cooldown <= 0 && frequency_aquacreep [current_level] != 0.0f) {
			GameObject go = Instantiate(this.aquacreep_prefab);
			go.transform.position = this.transform.position;
			this.aquacreep_cooldown = frequency_aquacreep[current_level];
		}
		
		if (this.groundcreep_cooldown <= 0 && frequency_groundcreep [current_level] != 0.0f) {
			GameObject go = Instantiate(this.groundcreep_prefab);
			go.transform.position = this.transform.position;
			this.groundcreep_cooldown = frequency_groundcreep[current_level];
		}
		
		if (this.darkcreep_cooldown <= 0 && frequency_darkcreep [current_level] != 0.0f) {
			GameObject go = Instantiate(this.darkcreep_prefab);
			go.transform.position = this.transform.position;
			this.darkcreep_cooldown = frequency_darkcreep[current_level];
		}
		
	}
}
