using UnityEngine;
using System.Collections;

public class CoolDownManager : MonoBehaviour {
    private SpriteRenderer cooldownBar;
    private float coolDown, coolDownT;

    // Use this for initialization
    void Start () {
        cooldownBar = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		int idAttack = GameObject.Find ("JoueurPrefab").GetComponent<JoueurManager> ().idAttack;
		GameObject attack = GameObject.FindGameObjectsWithTag ("Attack") [idAttack];
        if (attack.GetComponentInChildren<AttackEnemy>() != null)
        {
			coolDown = attack.GetComponentInChildren<AttackEnemy>().cooldown;
			coolDownT = attack.GetComponentInChildren<AttackEnemy>().cooldownT;
        }
        else
        {
			coolDown = attack.GetComponent<AttackManager>().cooldown;
			coolDownT = attack.GetComponent<AttackManager>().cooldownT;
        }
        if (this.coolDownT <= 0) coolDownT = 0;

        Vector3 position = GameObject.FindGameObjectWithTag("Player").transform.position;
        this.cooldownBar.transform.position = new Vector3(position.x,position.y-0.7f);
        this.cooldownBar.transform.localScale = new Vector3(coolDownT / coolDown, 1);

        
    }
}
