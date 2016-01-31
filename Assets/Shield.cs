using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	public int myIdAttack ;

	public int shield ;
	public float cooldown = 5f;
	[HideInInspector] // Hides var below
	public float cooldownT ;

	// Use this for initialization
	void Start () {
		cooldownT = cooldown;
	}
	
	// Update is called once per frame
	void Update () {
		Player player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		this.transform.position = player.gameObject.transform.position;
		int idAttack = GameObject.Find("JoueurPrefab").GetComponent<JoueurManager>().idAttack ;
		cooldownT -= Time.deltaTime;
		if (myIdAttack == idAttack) {

			gameObject.GetComponent<Animator>().SetBool ("isShielding", true);
			if (Input.GetMouseButtonDown (0) && cooldownT <= 0) {
				cooldownT = cooldown;
				player.shield = shield;
			}
		}
		if (cooldownT <= 0) {
			player.shield = 0;
			gameObject.GetComponent<Animator>().SetBool ("isShielding", false);
		}
	}
}
