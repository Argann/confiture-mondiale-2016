using UnityEngine;
using System.Collections;

public class AttackManager : MonoBehaviour {

    public GameObject fireBall;

    public float cooldown = 1f;
    [HideInInspector] // Hides var below
    public float cooldownT;

	public int myIdAttack ;
    void Start()
    {
        cooldownT = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
		int idAttack  = GameObject.Find("JoueurPrefab").GetComponent<JoueurManager>().idAttack ;
		if (myIdAttack == idAttack) {
			this.transform.position = GameObject.FindGameObjectWithTag ("Player").transform.position;
			cooldownT -= Time.deltaTime;
			if (cooldownT <= 0 && Input.GetMouseButtonDown (0)) {
				cooldownT = cooldown;
				Instantiate (fireBall, transform.position, transform.rotation);
			}
		}
    }
}