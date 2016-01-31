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
        if (GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AttackEnemy>() != null)
        {
            coolDown = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AttackEnemy>().cooldown;
            coolDownT = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AttackEnemy>().cooldownT;
        }
        else
        {
            coolDown = GameObject.FindGameObjectWithTag("Player").GetComponent<AttackManager>().cooldown;
            coolDownT = GameObject.FindGameObjectWithTag("Player").GetComponent<AttackManager>().cooldownT;
        }
        if (this.coolDownT <= 0) coolDownT = 0;

        Vector3 position = GameObject.FindGameObjectWithTag("Player").transform.position;
        this.cooldownBar.transform.position = new Vector3(position.x,position.y-0.7f);
        this.cooldownBar.transform.localScale = new Vector3(coolDownT / coolDown, 1);

        
    }
}
